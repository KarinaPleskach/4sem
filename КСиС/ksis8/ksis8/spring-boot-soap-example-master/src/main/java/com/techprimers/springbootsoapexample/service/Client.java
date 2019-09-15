package com.techprimers.springbootsoapexample.service;

import ChatSystem.clientcontents.SocketClient;
import ChatSystem.servercontents.NetworkListener;
import ChatSystem.servercontents.SocketServer;
import com.techprimers.spring_boot_soap_example.GetUserRequest;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;

public class Client implements NetworkListener {



    private static final String SERVER_ADDRESS = "127.0.0.1";
    private SocketClient socketClient;

    public SocketClient getSocketClient() {
        return socketClient;
    }

    public void sendToServer(GetUserRequest text) {
        try {
            socketClient = new SocketClient(SERVER_ADDRESS, SocketServer.SERVER_PORT);
            socketClient.addNetworkListener(this);
        } catch (Exception e) {
            System.out.println(e);
        }
        sendMsg(text);
    }

    private String getDate() {

        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        Calendar cal = Calendar.getInstance();
        return dateFormat.format(cal.getTime());
    }

    private void sendMsg(GetUserRequest text) {
        String msg = text.getFileName() + "\n" + text.getOffset() + "\n" + text.getText();
         String date = getDate();
        socketClient.sendMsg(msg+"\n"+date);

    }

    @Override
    public void messageReceived(String msg) {
       // String date = getDate();
       // socketClient.sendMsg(date);
    }
}
