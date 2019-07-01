#include <windows.h>
#include <tchar.h>
#include <thread>
#include <stdio.h>



const TCHAR fileName[] = TEXT("text.txt");
const TCHAR message[] = TEXT("Hello from first process");
DWORD fileSize = 256;

int main() {
    HANDLE hMapFile;
    hMapFile = CreateFileMapping(
            INVALID_HANDLE_VALUE,
            NULL,
            PAGE_READWRITE,
            0,
            fileSize,
            fileName
    );
    if (hMapFile == nullptr) {
        _tprintf(TEXT("%d \n"), GetLastError());
        return -1;
    }

    auto ptrMapView = MapViewOfFile(hMapFile,
                                    FILE_MAP_ALL_ACCESS,
                                    0,
                                    0,
                                    fileSize);
    if (ptrMapView == nullptr) {
        _tprintf(TEXT("%d \n"), GetLastError());
        CloseHandle(hMapFile);
        return -1;
    }
    _tprintf(TEXT("Sender is starting...\n"));

    std::this_thread::sleep_for(std::chrono::seconds(2));

    CopyMemory(ptrMapView, message, _tcsclen(message) * sizeof(TCHAR));
    _tprintf(TEXT("Message sent"));

    UnmapViewOfFile(ptrMapView);

    CloseHandle(hMapFile);
}