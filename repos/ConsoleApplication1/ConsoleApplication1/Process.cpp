#include "Process.h"


Process::Process()
{
}

Process::~Process()
{
    if (this->hProcess) {
        CloseHandle(this->hProcess);
    }
}

Process::Process(LPCWSTR lpName/*ProcessName/WindowTitle*/, BOOL bWindow)
{
    if (bWindow) {
        HWND hWnd = FindWindowW(NULL, lpName);
        if (hWnd == NULL) {
            return;
        }
        GetWindowThreadProcessId(hWnd, &(this->dwPid));
        this->hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, this->dwPid);
    }
    else {
        HANDLE hProcessSnap;
        PROCESSENTRY32 pe32;

        // Take a snapshot of all processes in the system.
        hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
        if (hProcessSnap == INVALID_HANDLE_VALUE)
        {
            //printf("Error: CreateToolhelp32Snapshot (of processes)\r\n");
            return;
        }

        // Set the size of the structure before using it.
        pe32.dwSize = sizeof(PROCESSENTRY32);

        // Retrieve information about the first process,
         // and exit if unsuccessful
        if (!Process32First(hProcessSnap, &pe32))
        {
            //printf("Error: Process32First\r\n"); // show cause of failure
            CloseHandle(hProcessSnap);          // clean the snapshot object
            return;
        }

        // Now walk the snapshot of processes, and
         // display information about each process in turn
        int namelen = 200;
        char name[201] = { 0 };
        do
        {
            if (!wcscmp(pe32.szExeFile, lpName)) {
                this->dwPid = pe32.th32ProcessID;
                this->hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, this->dwPid);
                break;
            }

        } while (Process32Next(hProcessSnap, &pe32));

        CloseHandle(hProcessSnap);
    }
}


BYTE Process::ReadByte(LPCVOID addr, BYTE* data)
{
    BYTE  ret;
    ReadProcessMemory(this->hProcess, addr, &ret, sizeof(BYTE), NULL);
    if (data != NULL)
        *data = ret;
    return ret;
}

int Process::ReadInt(LPCVOID addr, int* data)
{
    int  ret;
    ReadProcessMemory(this->hProcess, addr, &ret, sizeof(int), NULL);
    if (data != NULL)
        *data = ret;
    return ret;
}

long Process::ReadLong(LPCVOID addr, long* data)
{
    long  ret;
    return ReadProcessMemory(this->hProcess, addr, &ret, sizeof(long), NULL);
    if (data != NULL)
        *data = ret;
    return ret;
}

WORD Process::ReadWord(LPCVOID addr, WORD* data)
{
    WORD  ret;
    ReadProcessMemory(this->hProcess, addr, &ret, sizeof(WORD), NULL);
    if (data != NULL)
        *data = ret;
    return ret;
}

DWORD Process::ReadDword(LPCVOID addr, DWORD* data)
{
    DWORD  ret;
    ReadProcessMemory(this->hProcess, addr, &ret, sizeof(DWORD), NULL);
    if (data != NULL)
        *data = ret;
    return ret;
}

float Process::ReadFloat(LPCVOID addr, float* data)
{
    float  ret;
    ReadProcessMemory(this->hProcess, addr, &ret, sizeof(float), NULL);
    if (data != NULL)
        *data = ret;
    return ret;
}

double Process::ReadDouble(LPCVOID addr, double* data)
{
    double  ret;
    return ReadProcessMemory(this->hProcess, addr, &ret, sizeof(double), NULL);
    if (data != NULL)
        *data = ret;
    return ret;
}

BYTE* Process::ReadByteArray(LPCVOID addr, BYTE* data, size_t length)
{
    if (data == NULL)
        exit(-1);
    ReadProcessMemory(this->hProcess, addr, data, sizeof(BYTE) * length, NULL);
    return data;
}


BOOL Process::WriteByte(LPVOID addr, BYTE data)
{
    return WriteProcessMemory(this->hProcess, addr, &data, sizeof(BYTE), NULL);
}

BOOL Process::WriteInt(LPVOID addr, int data)
{
    return WriteProcessMemory(this->hProcess, addr, &data, sizeof(int), NULL);
}

BOOL Process::WriteLong(LPVOID addr, long data)
{
    return WriteProcessMemory(this->hProcess, addr, &data, sizeof(long), NULL);
}

BOOL Process::WriteWord(LPVOID addr, WORD data)
{
    return WriteProcessMemory(this->hProcess, addr, &data, sizeof(WORD), NULL);
}

BOOL Process::WriteDword(LPVOID addr, DWORD data)
{
    return WriteProcessMemory(this->hProcess, addr, &data, sizeof(DWORD), NULL);
}

BOOL Process::WriteFloat(LPVOID addr, float data)
{
    return WriteProcessMemory(this->hProcess, addr, &data, sizeof(float), NULL);
}

BOOL Process::WriteDouble(LPVOID addr, double data)
{
    return WriteProcessMemory(this->hProcess, addr, &data, sizeof(double), NULL);
}

BOOL Process::WriteByteArray(LPVOID addr, BYTE* data, size_t length)
{
    return WriteProcessMemory(this->hProcess, addr, data, sizeof(BYTE) * length, NULL);
}


HMODULE Process::GetModuleAddr(LPCWSTR lpModuleName)
{
    HANDLE hModuleSnap = INVALID_HANDLE_VALUE;
    MODULEENTRY32 me32;
    HMODULE hModule = 0;

    // Take a snapshot of all modules in the specified process.
    hModuleSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, this->dwPid);
    if (hModuleSnap == INVALID_HANDLE_VALUE)
    {
        //printf("Error: CreateToolhelp32Snapshot (of modules)\r\n");
        return NULL;
    }

    // Set the size of the structure before using it.
    me32.dwSize = sizeof(MODULEENTRY32);

    // Retrieve information about the first module,
     // and exit if unsuccessful
    if (!Module32First(hModuleSnap, &me32))
    {
        //printf("Error: Module32First\r\n");  // show cause of failure
        CloseHandle(hModuleSnap);     // clean the snapshot object
        return NULL;
    }

    // Now walk the module list of the process,
     // and display information about each module
    do
    {
        if (!wcscmp(lpModuleName, me32.szModule)) {
            hModule = (HMODULE)me32.modBaseAddr;
            CloseHandle(hModuleSnap);
            return hModule;
        }

    } while (Module32Next(hModuleSnap, &me32));

    CloseHandle(hModuleSnap);
    return NULL;
}