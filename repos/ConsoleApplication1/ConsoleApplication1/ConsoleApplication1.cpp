//#include <windows.h>
//#include <time.h>
//#include <iostream>
//#include "Process.h"
//#include <TlHelp32.h>
//using namespace std;
//HANDLE GetProcessHandle(LPCWSTR lpName)
//{
//	DWORD dwPid = 0;
//	HANDLE hProcess = NULL;
//	HANDLE hProcessSnap;
//	PROCESSENTRY32 pe32;
//
//	// Take a snapshot of all processes in the system.
//	hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
//	if (hProcessSnap == INVALID_HANDLE_VALUE)
//	{
//		//printf("Error: CreateToolhelp32Snapshot (of processes)\r\n");
//		return NULL;
//	}
//
//	// Set the size of the structure before using it.
//	pe32.dwSize = sizeof(PROCESSENTRY32);
//
//	// Retrieve information about the first process,
//	 // and exit if unsuccessful
//	if (!Process32First(hProcessSnap, &pe32))
//	{
//		//printf("Error: Process32First\r\n"); // show cause of failure
//		CloseHandle(hProcessSnap);          // clean the snapshot object
//		return NULL;
//	}
//
//	// Now walk the snapshot of processes, and
//	 // display information about each process in turn
//	int namelen = 200;
//	char name[201] = { 0 };
//	do
//	{
//		if (!wcscmp(pe32.szExeFile, lpName)) {
//			dwPid = pe32.th32ProcessID;
//			hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, dwPid);
//			break;
//		}
//
//	} while (Process32Next(hProcessSnap, &pe32));
//
//	CloseHandle(hProcessSnap);
//	return hProcess;
//}
///*
//findMatchingCode() 参数说明：
//1) hProcess		要打开的进程句柄
//2) markCode		特征码,支持通配符（??），如: 55 8b ec ?? 56 83 ec 20 ?? ?? 08 d9 ee
//3) memBeginAddr		起始搜索地址
//4) memEndAddr		结束搜索地址
//5) retAddr[]		记录找到的地址,传入这个参数前一定要清0，如 DWORD retAddr[32] = {0};  或者 DWORD *retAddr = new DWORD[32]();
//6) deviation		特征码地址离目标地址的偏移距离，上负下正
//7) isCall		是否为找CALL的跳转地址，true 则 retAddr[] 返回的是CALL跳转的地址
//8) isAll		是否查找所有符合的地址，false找到第一个符合的地址后就结束搜索，true继续搜索，直到搜索地址大于结束地址（memEndAddr）
//return返回值		找到的地址总数
//*/
//DWORD findMatchingCode(HANDLE hProcess, string markCode, DWORD memBeginAddr, DWORD memEndAddr, DWORD retAddr[], int deviation, bool isCall, bool isAll = false);
//
//DWORD findMatchingCode(HANDLE hProcess, string markCode, DWORD memBeginAddr, DWORD memEndAddr, DWORD retAddr[], int deviation, bool isCall, bool isAll)
//{
//	//----------------------处理特征码----------------------//
//	//去除所有空格
//	if (!markCode.empty())
//	{
//		int index = 0;
//		while ((index = markCode.find(' ', index)) >= 0)
//		{
//			markCode.erase(index, 1);
//		}
//		index = 0;
//		while (true)
//		{
//			//删掉头部通配符
//			index = markCode.find("??", index);
//			if (index == 0) {
//				markCode.erase(index, 2);
//			}
//			else {
//				break;
//			}
//		}
//	}
//
//	//特征码长度不能为单数
//	if (markCode.length() % 2 != 0) return 0;
//
//	//特征码长度
//	int len = markCode.length() / 2;
//
//	//Sunday算法模板数组的长度
//	int nSundayLen = len;
//
//	//将特征码转换成byte型
//	BYTE* pMarkCode = new BYTE[len];
//	for (int i = 0; i < len; i++)
//	{
//		string tempStr = markCode.substr(i * 2, 2);
//		if (tempStr == "??") {
//			pMarkCode[i] = 0x3F;
//			if (nSundayLen == len) nSundayLen = i;
//		}
//		else {
//			pMarkCode[i] = strtoul(tempStr.c_str(), 0, 16);
//		}
//	}
//	//--------------------------end-------------------------//
//
//	//Sunday算法模板数组赋值，+1防止特征码出现FF时越界
//	int aSunday[0xFF + 1] = { 0 };
//	for (int i = 0; i < nSundayLen; i++) {
//		aSunday[pMarkCode[i]] = i + 1;
//	}
//
//	//起始地址
//	const DWORD dwBeginAddr = memBeginAddr;
//	//结束地址
//	const DWORD dwEndAddr = memEndAddr;
//	//当前读取的内存块地址
//	DWORD dwCurAddr = dwBeginAddr;
//	//存放内存数据的缓冲区
//	BYTE* pMemBuffer = NULL;
//	//计算参数retAddr[]数组的长度，该参数传入前一定要清0
//	int nArrayLength = 0;
//	for (int i = 0; ; i++) {
//		if (*(retAddr + i) != 0) {
//			nArrayLength = i;
//			break;
//		}
//	}
//	//偏移量
//	int nOffset;
//	//数组下标：内存、特征码、返回地址
//	int i = 0, j = 0, nCount = 0;
//
//	//内存信息
//	MEMORY_BASIC_INFORMATION mbi;
//
//	//记录起始搜索时间
//	clock_t nBeginTime = clock();
//
//	//扫描内存
//	while (dwCurAddr < dwEndAddr)
//	{
//		//查询地址空间中内存地址的信息
//		memset(&mbi, 0, sizeof(MEMORY_BASIC_INFORMATION));
//		if (::VirtualQueryEx(hProcess, (LPCVOID)dwCurAddr, &mbi, sizeof(mbi)) == 0) {
//			goto end;
//		}
//
//		//过滤内存空间, 根据内存的状态和保护属性进行过滤
//				//一般扫描（读写及执行）即可，速度极快，扫不到的话在尝试添加（读写）这一属性
//		if (MEM_COMMIT == mbi.State &&			//已分配的物理内存
//			//MEM_PRIVATE == mbi.Type ||		//私有内存，不被其他进程共享
//			//MEM_IMAGE == mbi.Type &&
//			//PAGE_READONLY == mbi.Protect ||	//只读
//			//PAGE_EXECUTE_READ == mbi.Protect ||	//读及执行
//			//PAGE_READWRITE == mbi.Protect ||	//读写
//			PAGE_EXECUTE_READWRITE == mbi.Protect)	//读写及执行
//		{
//			//申请动态内存
//			if (pMemBuffer) {
//				delete[] pMemBuffer;
//				pMemBuffer = NULL;
//			}
//			pMemBuffer = new BYTE[mbi.RegionSize];
//			//读取进程内存
//			ReadProcessMemory(hProcess, (LPCVOID)dwCurAddr, pMemBuffer, mbi.RegionSize, 0);
//			i = 0;
//			j = 0;
//			while (j < len)
//			{
//			nextAddr:
//				if (pMemBuffer[i] == pMarkCode[j] || pMarkCode[j] == 0x3F)
//				{
//					i++;
//					j++;
//				}
//				else
//				{
//					nOffset = i - j + nSundayLen;
//					//判断偏移量是否大于缓冲区
//					if (nOffset > (mbi.RegionSize - len)) break;
//					//判断 aSunday模板数组 里有没有 内存偏移后的值，有则回溯，否则+1
//					if (aSunday[pMemBuffer[nOffset]])
//					{
//						i = nOffset - aSunday[pMemBuffer[nOffset]] + 1;
//						j = 0;
//					}
//					else
//					{
//						i = nOffset + 1;
//						j = 0;
//					}
//				}
//			}
//
//			if (j == len)
//			{
//				//计算找到的目标地址：
//				//特征码地址 = 当前内存块基址 + i偏移 - 特征码长度
//				//目标地址 = 特征码地址 + 偏移距离
//				//CALL（E8）跳转的地址 = E8指令后面的4个字节地址 + 下一条指令地址(也就是目标地址 + 5)
//				retAddr[nCount] = dwCurAddr + i - len + deviation;
//				if (isCall) {
//					DWORD temp;
//					memcpy(&temp, &pMemBuffer[i - len + deviation + 1], 4);
//					retAddr[nCount] += 5;
//					retAddr[nCount] += temp;
//				}
//
//				if (++nCount >= nArrayLength)
//				{
//					//传入的数组下标越界就结束搜索
//					goto end;
//				}
//
//				if (isAll) {
//					i = i - len + 1;
//					j = 0;
//					goto nextAddr;
//				}
//				else {
//					goto end;
//				}
//			}
//			dwCurAddr += mbi.RegionSize; //取下一块内存地址
//		}
//		else
//		{
//			dwCurAddr += mbi.RegionSize;
//		}
//	}
//
//
//end:
//	//计算搜索用时(ms)
//	clock_t nEndTime = clock();
//	int nUseTime = (nEndTime - nBeginTime);
//	//释放内存
//	if (pMemBuffer) {
//		delete[] pMemBuffer;
//		pMemBuffer = NULL;
//	}
//	delete[] pMarkCode;
//	pMarkCode = NULL;
//	return nCount;
//}
//int main()
//{
//	GetProcessHandle(L"DNF");
//	DWORD retAddr[32] = { 0 };
//	findMatchingCode(GetProcessHandle(L"DNF.exe"),"46 00 00 00 E8 03 00 00 00 00 00 00 01 00 00 00 00 00 00 00",0x70000000, 0x7FFFFFFF, retAddr,0,FALSE, FALSE);
//	for(int i=0;i<32;i++)
//	{
//		cout << retAddr[i] << endl;
//	}
//	getchar();
//	return 0;
//
//}


#include <stdio.h>
#include <stdlib.h>
#include <windows.h>


union Base
{
    DWORD   address;
    BYTE    data[4];
};


/************************************************************************/
/* 函数说明：根据特征码扫描基址
/* 参数一：process 要查找的进程
/* 参数二：markCode 特征码字符串,不能有空格
/* 参数三：特征码离基址的距离，默认距离：1
/* 参数四：findMode 扫描方式，找到特征码后，默认为：1
/*                  0：往上找基址（特征码在基址下面）
/*                  1：往下找基址（特征码在基址上面）
/* 参数五：offset 保存基址距离进程的偏移，默认为：不保存
/************************************************************************/
DWORD ScanAddress(HANDLE process,const char* markCode,
    DWORD distinct = 1, DWORD findMode = 1,
    LPDWORD offset = NULL)
{
    //起始地址
    const DWORD beginAddr = 0x00400000;
    //结束地址
    const DWORD endAddr = 0x7FFFFFFF;
    //每次读取游戏内存数目的大小
    const DWORD pageSize = 4096;

    ////////////////////////处理特征码/////////////////////
    //特征码长度不能为单数
    if (strlen(markCode) % 2 != 0) return 0;
    //特征码长度
    int len = strlen(markCode) / 2;
    //将特征码转换成byte型
    BYTE* m_code = new BYTE[len];
    for (int i = 0; i < len; i++) {
        char c[] = { markCode[i * 2], markCode[i * 2 + 1], '\0' };
        m_code[i] = (BYTE)::strtol(c, NULL, 16);
    }

    /////////////////////////查找特征码/////////////////////
    BOOL _break = FALSE;
    //用来保存在第几页中的第几个找到的特征码
    int curPage = 0;
    int curIndex = 0;
    Base base;
    //每页读取4096个字节
    BYTE page[pageSize];
    DWORD tmpAddr = beginAddr;
    while (tmpAddr <= endAddr - len) {
        ::ReadProcessMemory(process, (LPCVOID)tmpAddr, &page, pageSize, 0);
        //在该页中查找特征码
        for (int i = 0; i < pageSize; i++) {
            for (int j = 0; j < len; j++) {
                //只要有一个与特征码对应不上则退出循环
                if (m_code[j] != page[i + j])break;
                //找到退出所有循环
                if (j == len - 1) {
                    _break = TRUE;
                    if (!findMode) {
                        curIndex = i;
                        base.data[0] = page[curIndex - distinct - 4];
                        base.data[1] = page[curIndex - distinct - 3];
                        base.data[2] = page[curIndex - distinct - 2];
                        base.data[3] = page[curIndex - distinct - 1];
                    }
                    else {
                        curIndex = i + j;
                        base.data[0] = page[curIndex + distinct + 1];
                        base.data[1] = page[curIndex + distinct + 2];
                        base.data[2] = page[curIndex + distinct + 3];
                        base.data[3] = page[curIndex + distinct + 4];
                    }
                    break;
                }
            }
            if (_break) break;
        }
        if (_break) break;
        curPage++;
        tmpAddr += pageSize;
    }
    if (offset != NULL) {
        *offset = curPage * pageSize + curIndex + beginAddr;
    }
    return base.address;
}


/************************************************************************/
/* 函数说明：根据特征码扫描call地址
/* 参数一：process 要查找的进程
/* 参数二：markCode 特征码字符串,不能有空格
/* 参数三：特征码离基址的距离，默认距离：1
/* 参数四：findMode 扫描方式，找到特征码后，默认为：1
/*                  0：往上找基址
/*                  1：往下找基址
/************************************************************************/
DWORD ScanCall(HANDLE process,const char* markCode,
    DWORD distinct = 1, DWORD findMode = 1)
{
    DWORD offset;
    DWORD call = ScanAddress(process, markCode, distinct, findMode, &offset);
    call += offset;
    if (findMode) call = call + 5 + distinct;
    else call = call - distinct;
    return call;
}


int main(int argc, char* argv[])
{
    //查找游戏窗口
    HWND hGame = ::FindWindow(L"DNF", NULL);
    if (hGame == NULL) return FALSE;

    DWORD processId;
    HANDLE process;
    ::GetWindowThreadProcessId(hGame, &processId);
    process = ::OpenProcess(PROCESS_ALL_ACCESS, false, processId);
    //83C404C3CCCCA1 1 人物基址往下搜索
    //C3CCCCCCCCCCCCCCCCCCCC8B442404A3ECA72001 0 人物基址往上搜索
    //5557535152C6400801E8 1 打怪call

    //基址在特征码下面
    DWORD addr = ScanAddress(process, "46000000E8030000000000000100000000000000");
    printf("人物基址：%X\n", addr);

    ////基址在特征码上面
    //DWORD addr = ScanAddress(process, "C3CCCCCCCCCCCCCCCCCCCC8B442404A3ECA72001", 3, 0);
    //printf("人物基址：%X\n", addr);

    //DWORD call = ScanCall(process, "5557535152C6400801E8");
    //printf("call基址：%X\n", call);
    ::CloseHandle(process);

    getchar();

    return 0;
}