#include "pch.h"
#include "MemorySearch.h"
#include <cstddef>
#include <windows.h> 
#include <tlhelp32.h> 
#include <stdio.h> 
using namespace std;
#define EX_PORT __declspec(dllexport) 

//#pragma comment(linker,"/EXPORT:SearchMemory=_SearchMemory@12")
// 搜索内存
int bytesto_int4(BYTE* bytes)
{
	//turn bytes array to integer
	int num = bytes[0] & 0xFF;
	num |= ((bytes[1] << 8) & 0xFF00);
	num |= ((bytes[2] << 16) & 0xFF0000);
	num |= ((bytes[3] << 24) & 0xFF000000);
	return num;
}
char* wchar2char(const wchar_t* wchar)
{
	char* m_char;
	int len = WideCharToMultiByte(CP_ACP, 0, wchar, wcslen(wchar), NULL, 0, NULL, NULL);
	m_char = new char[len + 1];
	WideCharToMultiByte(CP_ACP, 0, wchar, wcslen(wchar), m_char, len, NULL, NULL);
	m_char[len] = '\0';
	return m_char;
}

extern "C" int __declspec(dllexport) SearchMemory(DWORD dwProcessId, PVOID pSearchBuffer, DWORD dwSearchBufferSize)
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
	int ret = 0;

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

extern "C" int __declspec(dllexport) SearchMemory2(DWORD dwProcessId, PVOID pSearchBuffer, DWORD dwSearchBufferSize)
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
	int ret = 0;

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
					BYTE z[4];
					::ReadProcessMemory(hProcess, (LPCVOID)((int)mbi.BaseAddress + i - 0x70), z, 4, 0);
					int X = bytesto_int4(z);
					if (X == 60000 || X == 10000)
					{
						ret = ((int)mbi.BaseAddress + i);
						break;
					}
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

extern "C" int __declspec(dllexport) ListProcessModules(DWORD dwPID ,char* name)
{
	HANDLE hModuleSnap = INVALID_HANDLE_VALUE;
	MODULEENTRY32 me32;

	//  Take a snapshot of all modules in the specified process. 
	hModuleSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, dwPID);
	if (hModuleSnap == INVALID_HANDLE_VALUE)
	{
		//printError("CreateToolhelp32Snapshot (of modules)");
		return(FALSE);
	}

	//  Set the size of the structure before using it. 
	me32.dwSize = sizeof(MODULEENTRY32);

	//  Retrieve information about the first module, 
	//  and exit if unsuccessful 
	if (!Module32First(hModuleSnap, &me32))
	{
		//printError("Module32First");  // Show cause of failure 
		CloseHandle(hModuleSnap);     // Must clean up the snapshot object! 
		return(FALSE);
	}
	//  Now walk the module list of the process, 
	//  and display information about each module 
	do
	{
		if (strcmp(wchar2char(me32.szModule), name) == 0)
		{
			return (UINT32)me32.modBaseAddr;
		}

	} while (Module32Next(hModuleSnap, &me32));

	//  Do not forget to clean up the snapshot object. 
	CloseHandle(hModuleSnap);
	return(TRUE);
}
