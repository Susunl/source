#pragma once

#include <stdio.h>
#include <windows.h>
#include <TlHelp32.h>
#include <Psapi.h>

class Process
{
public:
    Process();
    ~Process();
    Process(LPCWSTR lpName/*ProcessName/WindowTitle*/, BOOL bWindow = FALSE);

public:
    BYTE ReadByte(LPCVOID addr, BYTE* data);
    int ReadInt(LPCVOID addr, int* data);
    long ReadLong(LPCVOID addr, long* data);
    WORD ReadWord(LPCVOID addr, WORD* data);
    DWORD ReadDword(LPCVOID addr, DWORD* data);
    float ReadFloat(LPCVOID addr, float* data);
    double ReadDouble(LPCVOID addr, double* data);
    BYTE* ReadByteArray(LPCVOID addr, BYTE* data, size_t length);

    BOOL WriteByte(LPVOID addr, BYTE data);
    BOOL WriteInt(LPVOID addr, int data);
    BOOL WriteLong(LPVOID addr, long data);
    BOOL WriteWord(LPVOID addr, WORD data);
    BOOL WriteDword(LPVOID addr, DWORD data);
    BOOL WriteFloat(LPVOID addr, float data);
    BOOL WriteDouble(LPVOID addr, double data);
    BOOL WriteByteArray(LPVOID addr, BYTE* data, size_t length);

    HMODULE GetModuleAddr(LPCWSTR lpModuleName);

public:
    DWORD dwPid = 0;
    HANDLE hProcess = NULL;
};