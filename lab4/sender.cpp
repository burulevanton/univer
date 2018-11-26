#include <windows.h>
#include <stdio.h>
#include <thread>
#include <tchar.h>
#include <string>

int main(){
    DWORD lpNumberOfBytesWritten;

    HANDLE hNamedPipe = CreateNamedPipe(
            TEXT("\\\\.\\pipe\\pipe"),
            PIPE_ACCESS_DUPLEX,
            PIPE_TYPE_MESSAGE | PIPE_READMODE_MESSAGE | PIPE_WAIT,
            PIPE_UNLIMITED_INSTANCES,
            512,
            512,
            10000,
            NULL
            );

    if(hNamedPipe == INVALID_HANDLE_VALUE){
        _tprintf(TEXT("%d \n"), GetLastError());
        return -1;
    }
    _tprintf(TEXT("Trying to connect...\n"));
    BOOL isConnected = ConnectNamedPipe(hNamedPipe, NULL);
    if(!isConnected){
        _tprintf(TEXT("Connection error"));
        CloseHandle(hNamedPipe);
        return -1;
    }
    _tprintf(TEXT("Connected\n"));
    for(int i=0;i<10;i++){
        WriteFile(hNamedPipe, std::to_string(i).c_str(), DWORD(std::to_string(i).size()+1), &lpNumberOfBytesWritten, NULL);
        std::this_thread::sleep_for(std::chrono::seconds(2));
    }
    std::string exitMessage = "exit";
    WriteFile(hNamedPipe, exitMessage.c_str(), exitMessage.size()+1, &lpNumberOfBytesWritten, NULL);
    CloseHandle(hNamedPipe);
}