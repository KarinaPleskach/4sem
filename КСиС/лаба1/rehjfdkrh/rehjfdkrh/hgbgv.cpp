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


BOOL WINAPI EnumerateFunc(HWND hwnd, HDC hdc, LPNETRESOURCE lpnr){//� ������� ���� ���� ���������� ������������� HWND. // ��������� ��������� ���������� HDC ��� ������ ���������� ������ � ���� //��������� ��� ���������� � ������e

    DWORD dwResult, dwResultEnum;
    HANDLE hEnum; // ��������� �� �������������
    DWORD cbBuffer = 16384;
    DWORD cEntries = -1; // ������ ��� �������
    LPNETRESOURCE lpnrLocal;
    DWORD i;

    // ����� ������� WNetOpenEnum ��� ������ ������������ �����������.
    dwResult = WNetOpenEnum(RESOURCE_GLOBALNET, // ��� ������� �������
                            RESOURCETYPE_ANY, // ��� ���� ��������
                            0, // ����������� ��� �������
                            lpnrLocal, // ����� NULL ��� ������ ������ �������
                            &hEnum); // ���������� �������

    if (dwResult != NO_ERROR) {
        // ��������� ������.
        //NetErrorHandler(hwnd, dwResult, (LPSTR)"WNetOpenEnum");
        return FALSE;
    }

    // ������ ������� GlobalAlloc ��� ��������� ��������.

    lpnrLocal = (LPNETRESOURCE) GlobalAlloc(GPTR, cbBuffer);

    if (lpnrLocal == NULL)
        return FALSE;

    do {
        // �������������� �����.
        ZeroMemory(lpnrLocal, cbBuffer);

        // ����� ������� WNetEnumResource ��� ����������� ������������ ��������� �������� ����.
        dwResultEnum = WNetEnumResource(hEnum,

                                        &cEntries, // ���������� ���� ��� -1

                                        lpnrLocal,

                                        &cbBuffer); // ������ ������

        // ���� ����� ��� �������, �� ��������� �������������� ������.
        if (dwResultEnum == NO_ERROR) {

            for(i = 0; i < cEntries; i++) {

            // ����� ������������ � ���������� ������� ��� ����������� ����������� �������� NETRESOURCE.
            DisplayStruct((int)hdc, &lpnrLocal[i]);

            // ���� ��������� NETRESOURCE �������� �����������, �� ������� EnumerateFunc ���������� ����������.
            if(RESOURCEUSAGE_CONTAINER == (lpnrLocal[i].dwUsage & RESOURCEUSAGE_CONTAINER))

                if(!EnumerateFunc(hwnd, hdc, &lpnrLocal[i]))
                    TextOut(hdc, 10, 10, (LPCWSTR)"EnumerateFunc returned FALSE.", 29);

            }

        }

        // ��������� ������.
        else if (dwResultEnum != ERROR_NO_MORE_ITEMS) {

                //NetErrorHandler(hwnd, dwResultEnum, (LPSTR)"WNetEnumResource");

                break;

            }

    }

    while(dwResultEnum != ERROR_NO_MORE_ITEMS);

        // ����� ������� GlobalFree ��� ������� ��������.
        GlobalFree((HGLOBAL)lpnrLocal);

    // ����� WNetCloseEnum ��� ��������� ������������.
    dwResult = WNetCloseEnum(hEnum);

    if(dwResult != NO_ERROR) {
        // ��������� ������.
        //NetErrorHandler(hwnd, dwResult, (LPSTR)"WNetCloseEnum");

        return FALSE;
    }

    return TRUE;
}

