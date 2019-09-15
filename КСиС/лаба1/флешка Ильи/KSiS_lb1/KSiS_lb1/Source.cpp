#define _WINSOCK_DEPRECATED_NO_WARNINGS

#pragma comment(lib, "ws2_32.lib")

#include <iostream>
#include <winsock2.h>
#include <windows.h>

using namespace std;

int main(int argc, char* argv[])
{
	const int WSVer = MAKEWORD(2, 2);
	WSAData wsaData;
	hostent *h;
	char buf[128];

	if (WSAStartup(WSVer, &wsaData) == 0)
	{
		if (gethostname(buf, 128) == 0)
		{
			h = gethostbyname(buf);

			if (h != NULL)
				cout << inet_ntoa(*(reinterpret_cast<in_addr *>(*(h->h_addr_list)))) << endl;
			else
				cout << "You have not any IP." << endl;
		}
		WSACleanup();
	}

	system("pause");
	return 0;
}