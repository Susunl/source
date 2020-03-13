#include "pch.h"
#include "MemorySearch.h"

#pragma comment(linker,"/EXPORT:SearchMemory=_SearchMemory@12")
// 搜索内存
extern "C" int __stdcall SearchMemory(DWORD dwProcessId, PVOID pSearchBuffer, DWORD dwSearchBufferSize)
{
	// 根据PID, 打开进程获取进程句柄
	HANDLE hProcess = ::OpenProcess(PROCESS_ALL_ACCESS, FALSE, dwProcessId);
	if (NULL == hProcess)
	{
		//ShowError("OpenProcess");
		return FALSE;
	}
	// 获取进程加载基址
	HMODULE hModule = NULL;
	::EnumProcessModules(hProcess, &hModule, sizeof(HMODULE), NULL);
	// 把加载基址作为遍历内存的起始地址, 开始遍历
	BYTE* pSearchAddress = (BYTE*)hModule;
	MEMORY_BASIC_INFORMATION mbi = { 0 };
	DWORD dwRet = 0;
	BOOL bRet = FALSE;
	BYTE* pTemp = NULL;
	DWORD i = 0;
	BYTE* pBuf = NULL;
	int ret;

	while (TRUE)
	{
		// 查询地址空间中内存地址的信息
		::RtlZeroMemory(&mbi, sizeof(mbi));
		dwRet = ::VirtualQueryEx(hProcess, pSearchAddress, &mbi, sizeof(mbi));
		if (0 == dwRet)
		{
			break;
		}
		// 过滤内存空间, 根据内存的状态和保护属性进行过滤
		if ((MEM_COMMIT == mbi.State) &&
			(PAGE_READONLY == mbi.Protect || PAGE_READWRITE == mbi.Protect ||
				PAGE_EXECUTE_READ == mbi.Protect || PAGE_EXECUTE_READWRITE == mbi.Protect))
		{
			// 申请动态内存
			pBuf = new BYTE[mbi.RegionSize];
			::RtlZeroMemory(pBuf, mbi.RegionSize);
			// 读取整块内存
			bRet = ::ReadProcessMemory(hProcess, mbi.BaseAddress, pBuf, mbi.RegionSize, &dwRet);
			if (FALSE == bRet)
			{
				//ShowError("ReadProcessMemory");
				break;
			}
			// 匹配内存
			for (i = 0; i < (mbi.RegionSize - dwSearchBufferSize); i++)
			{
				pTemp = (BYTE*)pBuf + i;
				if (RtlEqualMemory(pTemp, pSearchBuffer, dwSearchBufferSize))
				{
					// 显示搜索到的地址
					//printf("0x%p\n", ((BYTE*)mbi.BaseAddress + i));
					ret = ((int)mbi.BaseAddress + i);
					break;
				}
			}
			// 释放内存
			delete[]pBuf;
			pBuf = NULL;
		}
		// 继续对下一块内存区域进行遍历
		pSearchAddress = pSearchAddress + mbi.RegionSize;
	}
	// 释放内存, 关闭句柄
	if (pBuf)
	{
		delete[]pBuf;
		pBuf = NULL;
	}
	::CloseHandle(hProcess);

	return ret;
}