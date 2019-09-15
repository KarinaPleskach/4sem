#ifndef UNICODE
#define UNICODE
#endif
#pragma comment(lib, "mpr.lib")

#include <windows.h>
#include <stdio.h>
#include <winnetwk.h>

#include <wincon.h>
#include <stdlib.h>
#include <time.h>
#include <Winnetwk.h>

//#include "stdafx.h"
#include "nb30.h"
//#include "iostream.h"
#include "mbstring.h"
#include "NB30.h"
#pragma comment(lib,"Netapi32.lib")


void DisplayStruct(int i, LPNETRESOURCE lpnrLocal) {
    printf("NETRESOURCE[%d] Scope: ", i);
    switch (lpnrLocal->dwScope) {
    case (RESOURCE_CONNECTED):
        printf("connected\n");
        break;
    case (RESOURCE_GLOBALNET):
        printf("all resources\n");
        break;
    case (RESOURCE_REMEMBERED):
        printf("remembered\n");
        break;
    default:
        printf("unknown scope %d\n", lpnrLocal->dwScope);
        break;
    }

    printf("NETRESOURCE[%d] Type: ", i);
    switch (lpnrLocal->dwType) {
    case (RESOURCETYPE_ANY):
        printf("any\n");
        break;
    case (RESOURCETYPE_DISK):
        printf("disk\n");
        break;
    case (RESOURCETYPE_PRINT):
        printf("print\n");
        break;
    default:
        printf("unknown type %d\n", lpnrLocal->dwType);
        break;
    }

    printf("NETRESOURCE[%d] DisplayType: ", i);
    switch (lpnrLocal->dwDisplayType) {
    case (RESOURCEDISPLAYTYPE_GENERIC):
        printf("generic\n");
        break;
    case (RESOURCEDISPLAYTYPE_DOMAIN):
        printf("domain\n");
        break;
    case (RESOURCEDISPLAYTYPE_SERVER):
        printf("server\n");
        break;
    case (RESOURCEDISPLAYTYPE_SHARE):
        printf("share\n");
        break;
    case (RESOURCEDISPLAYTYPE_FILE):
        printf("file\n");
        break;
    case (RESOURCEDISPLAYTYPE_GROUP):
        printf("group\n");
        break;
    case (RESOURCEDISPLAYTYPE_NETWORK):
        printf("network\n");
        break;
    default:
        printf("unknown display type %d\n", lpnrLocal->dwDisplayType);
        break;
    }

    printf("NETRESOURCE[%d] Usage: 0x%x = ", i, lpnrLocal->dwUsage);
    if (lpnrLocal->dwUsage & RESOURCEUSAGE_CONNECTABLE)
        printf("connectable ");
    if (lpnrLocal->dwUsage & RESOURCEUSAGE_CONTAINER)
        printf("container ");
    printf("\n");

    printf("NETRESOURCE[%d] Localname: %S\n", i, lpnrLocal->lpLocalName);
    printf("NETRESOURCE[%d] Remotename: %S\n", i, lpnrLocal->lpRemoteName);
    printf("NETRESOURCE[%d] Comment: %S\n", i, lpnrLocal->lpComment);
    printf("NETRESOURCE[%d] Provider: %S\n", i, lpnrLocal->lpProvider);
    printf("\n");
}


BOOL WINAPI EnumerateFunc(HWND hwnd, HDC hdc, LPNETRESOURCE lpnr){//У каждого окна есть уникальный идентификатор HWND. // экземпляр контекста устройства HDC для нужной ориентации текста в окне //структура для информации о ресурсe

    DWORD dwResult, dwResultEnum;
    HANDLE hEnum; // указатель на перечислитель
    DWORD cbBuffer = 16384;
    DWORD cEntries = -1; // Искать все объекты
    LPNETRESOURCE lpnrLocal;
    DWORD i;

    // Вызов функции WNetOpenEnum для начала перечисления компьютеров.
    dwResult = WNetOpenEnum(RESOURCE_GLOBALNET, // все сетевые ресурсы
                            RESOURCETYPE_ANY, // все типы ресурсов
                            0, // перечислить все ресурсы
                            lpnrLocal, // равно NULL при первом вызове функции
                            &hEnum); // дескриптор ресурса

    if (dwResult != NO_ERROR) {
        // Обработка ошибок.
        //NetErrorHandler(hwnd, dwResult, (LPSTR)"WNetOpenEnum");
        return FALSE;
    }

    // Вызвов функции GlobalAlloc для выделения ресурсов.

    lpnrLocal = (LPNETRESOURCE) GlobalAlloc(GPTR, cbBuffer);

    if (lpnrLocal == NULL)
        return FALSE;

    do {
        // Инициализируем буфер.
        ZeroMemory(lpnrLocal, cbBuffer);

        // Вызов функции WNetEnumResource для продолжения перечисления доступных ресурсов сети.
        dwResultEnum = WNetEnumResource(hEnum,

                                        &cEntries, // Определено выше как -1

                                        lpnrLocal,

                                        &cbBuffer); // размер буфера

        // Если вызов был успешен, то структуры обрабатываются циклом.
        if (dwResultEnum == NO_ERROR) {

            for(i = 0; i < cEntries; i++) {

            // Вызов определенной в приложении функции для отображения содержимого структур NETRESOURCE.
            DisplayStruct((int)hdc, &lpnrLocal[i]);

            // Если структура NETRESOURCE является контейнером, то функция EnumerateFunc вызывается рекурсивно.
            if(RESOURCEUSAGE_CONTAINER == (lpnrLocal[i].dwUsage & RESOURCEUSAGE_CONTAINER))

                if(!EnumerateFunc(hwnd, hdc, &lpnrLocal[i]))
                    TextOut(hdc, 10, 10, (LPCWSTR)"EnumerateFunc returned FALSE.", 29);

            }

        }

        // Обработка ошибок.
        else if (dwResultEnum != ERROR_NO_MORE_ITEMS) {

                //NetErrorHandler(hwnd, dwResultEnum, (LPSTR)"WNetEnumResource");

                break;

            }

    }

    while(dwResultEnum != ERROR_NO_MORE_ITEMS);

        // Вызов функции GlobalFree для очистки ресурсов.
        GlobalFree((HGLOBAL)lpnrLocal);

    // Вызов WNetCloseEnum для остановки перечисления.
    dwResult = WNetCloseEnum(hEnum);

    if(dwResult != NO_ERROR) {
        // Обработка ошибок.
        //NetErrorHandler(hwnd, dwResult, (LPSTR)"WNetCloseEnum");

        return FALSE;
    }

    return TRUE;
}

