#include <windows.h>
#include <stdio.h>
#include <tchar.h>

int main(){
    HANDLE hNamedPipe = CreateFile(
            TEXT("\\\\.\\pipe\\pipe"),
            GENERIC_READ | GENERIC_WRITE,
            0,
            NULL,
            OPEN_EXISTING,
            0,
            NULL
            );
    if(hNamedPipe == INVALID_HANDLE_VALUE){
        _tprintf(TEXT("%d \n"), GetLastError());
        return -1;
    }
    char buffer[256];
    DWORD  lpNumberOfBytesRead;
    while(true){
        if(ReadFile(hNamedPipe, buffer, 512, &lpNumberOfBytesRead, NULL))
            _tprintf(TEXT("Received: %s\n"), buffer);
        else{
            _tprintf("Error");
            break;
        }
        if(!strcmp(buffer, "exit"))
            break;
    }

    CloseHandle(hNamedPipe);
}