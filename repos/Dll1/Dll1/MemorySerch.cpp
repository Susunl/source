#include "pch.h"
#include "MemorySearch.h"
#include <cstddef>
using namespace std;
#define EX_PORT __declspec(dllexport) 

//#pragma comment(linker,"/EXPORT:SearchMemory=_SearchMemory@12")
// �����ڴ�
int bytesto_int4(BYTE* bytes)
{
	//turn bytes array to integer
	int num = bytes[0] & 0xFF;
	num |= ((bytes[1] << 8) & 0xFF00);
	num |= ((bytes[2] << 16) & 0xFF0000);
	num |= ((bytes[3] << 24) & 0xFF000000);
	return num;
}

extern "C" int __declspec(dllexport) SearchMemory(DWORD dwProcessId, PVOID pSearchBuffer, DWORD dwSearchBufferSize)
{
	// ����PID, �򿪽��̻�ȡ���̾��
	HANDLE hProcess = ::OpenProcess(PROCESS_ALL_ACCESS, FALSE, dwProcessId);
	if (NULL == hProcess)
	{
		//ShowError("OpenProcess");
		return FALSE;
	}
	// ��ȡ���̼��ػ�ַ
	HMODULE hModule = NULL;
	::EnumProcessModules(hProcess, &hModule, sizeof(HMODULE), NULL);
	// �Ѽ��ػ�ַ��Ϊ�����ڴ����ʼ��ַ, ��ʼ����
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
		// ��ѯ��ַ�ռ����ڴ��ַ����Ϣ
		::RtlZeroMemory(&mbi, sizeof(mbi));
		dwRet = ::VirtualQueryEx(hProcess, pSearchAddress, &mbi, sizeof(mbi));
		if (0 == dwRet)
		{
			break;
		}
		// �����ڴ�ռ�, �����ڴ��״̬�ͱ������Խ��й���
		if ((MEM_COMMIT == mbi.State) &&
			(PAGE_READONLY == mbi.Protect || PAGE_READWRITE == mbi.Protect ||
				PAGE_EXECUTE_READ == mbi.Protect || PAGE_EXECUTE_READWRITE == mbi.Protect))
		{
			// ���붯̬�ڴ�
			pBuf = new BYTE[mbi.RegionSize];
			::RtlZeroMemory(pBuf, mbi.RegionSize);
			// ��ȡ�����ڴ�
			bRet = ::ReadProcessMemory(hProcess, mbi.BaseAddress, pBuf, mbi.RegionSize, &dwRet);
			if (FALSE == bRet)
			{
				//ShowError("ReadProcessMemory");
				break;
			}
			// ƥ���ڴ�
			for (i = 0; i < (mbi.RegionSize - dwSearchBufferSize); i++)
			{
				pTemp = (BYTE*)pBuf + i;
				if (RtlEqualMemory(pTemp, pSearchBuffer, dwSearchBufferSize))
				{
					// ��ʾ�������ĵ�ַ
					//printf("0x%p\n", ((BYTE*)mbi.BaseAddress + i));
					ret = ((int)mbi.BaseAddress + i);
					break;
				}
			}
			// �ͷ��ڴ�
			delete[]pBuf;
			pBuf = NULL;
		}
		// ��������һ���ڴ�������б���
		pSearchAddress = pSearchAddress + mbi.RegionSize;
	}
	// �ͷ��ڴ�, �رվ��
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
	// ����PID, �򿪽��̻�ȡ���̾��
	HANDLE hProcess = ::OpenProcess(PROCESS_ALL_ACCESS, FALSE, dwProcessId);
	if (NULL == hProcess)
	{
		//ShowError("OpenProcess");
		return FALSE;
	}
	// ��ȡ���̼��ػ�ַ
	HMODULE hModule = NULL;
	::EnumProcessModules(hProcess, &hModule, sizeof(HMODULE), NULL);
	// �Ѽ��ػ�ַ��Ϊ�����ڴ����ʼ��ַ, ��ʼ����
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
		// ��ѯ��ַ�ռ����ڴ��ַ����Ϣ
		::RtlZeroMemory(&mbi, sizeof(mbi));
		dwRet = ::VirtualQueryEx(hProcess, pSearchAddress, &mbi, sizeof(mbi));
		if (0 == dwRet)
		{
			break;
		}
		// �����ڴ�ռ�, �����ڴ��״̬�ͱ������Խ��й���
		if ((MEM_COMMIT == mbi.State) &&
			(PAGE_READONLY == mbi.Protect || PAGE_READWRITE == mbi.Protect ||
				PAGE_EXECUTE_READ == mbi.Protect || PAGE_EXECUTE_READWRITE == mbi.Protect))
		{
			// ���붯̬�ڴ�
			pBuf = new BYTE[mbi.RegionSize];
			::RtlZeroMemory(pBuf, mbi.RegionSize);
			// ��ȡ�����ڴ�
			bRet = ::ReadProcessMemory(hProcess, mbi.BaseAddress, pBuf, mbi.RegionSize, &dwRet);
			if (FALSE == bRet)
			{
				//ShowError("ReadProcessMemory");
				break;
			}
			// ƥ���ڴ�
			for (i = 0; i < (mbi.RegionSize - dwSearchBufferSize); i++)
			{
				pTemp = (BYTE*)pBuf + i;
				if (RtlEqualMemory(pTemp, pSearchBuffer, dwSearchBufferSize))
				{
					// ��ʾ�������ĵ�ַ
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
			// �ͷ��ڴ�
			delete[]pBuf;
			pBuf = NULL;
		}
		// ��������һ���ڴ�������б���
		pSearchAddress = pSearchAddress + mbi.RegionSize;
	}
	// �ͷ��ڴ�, �رվ��
	if (pBuf)
	{
		delete[]pBuf;
		pBuf = NULL;
	}
	::CloseHandle(hProcess);

	return ret;
}
