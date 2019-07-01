#include <windows.h>
#include <tchar.h>
#include <cstdio>

const TCHAR fileName[] = TEXT("text.txt");
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
    auto ptrMapView = (LPTSTR)MapViewOfFile(hMapFile,
                                            FILE_MAP_ALL_ACCESS,
                                            0,
                                            0,
                                            fileSize);
    if (ptrMapView == nullptr) {
        _tprintf(TEXT("%d \n"), GetLastError());
        CloseHandle(hMapFile);
        return -1;
    }

    _tprintf(TEXT("Waiting for message...\n"));

    while (ptrMapView[0] == '\0');

    _tprintf(ptrMapView);

    UnmapViewOfFile(ptrMapView);
    CloseHandle(hMapFile);
}