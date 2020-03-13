#pragma once
#ifndef _MEMORY_SEARCH_H_
#define _MEMORY_SEARCH_H_


#include <Windows.h>
#include <Psapi.h>
#pragma comment(lib, "Psapi.lib")

#pragma comment(linker,"/EXPORT:SearchMemory=_SearchMemory@12")
extern "C" int __stdcall SearchMemory(DWORD dwProcessId, PVOID pSearchBuffer, DWORD dwSearchBufferSize);
#endif