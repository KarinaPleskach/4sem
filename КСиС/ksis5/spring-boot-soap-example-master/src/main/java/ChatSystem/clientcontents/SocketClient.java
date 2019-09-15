package ChatSystem.clientcontents;


import ChatSystem.servercontents.NetworkListener;
import ChatSystem.servercontents.NetworkListener;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class SocketClient  {

    private  PrintWriter pr;
    private  Socket socket;
    private boolean recieved ;
    private List<NetworkListener> listeners = new ArrayList<>();

    public SocketClient(String serverAddress, int  serverPort ) throws IOException {

            socket = new Socket(serverAddress, serverPort);//will automatic send request to servercontents
            System.out.println("Client Connected To The Server ");
            OutputStream os = socket.getOutputStream();//output stream to write a msg to servercontents
            pr = new PrintWriter(os);

            new Thread(() -> {
                try {
                    InputStream is = socket.getInputStream();
                    Scanner sc = new Scanner(is);


                        while (sc.hasNextLine()){
                            String msg = sc.nextLine();
                            recieved = (msg!=null)? true:false;
                            System.out.println(msg);
                            for (NetworkListener l : listeners){
                                l.messageReceived(msg);
                            }
                        }

                    sc.close();

                } catch (IOException e) {
                    System.out.println(e);
                }

            }).start();

    }

    public void sendMsg(String msg){

        pr.println(msg);
        pr.flush();
    }

    public void addNetworkListener(NetworkListener l){
        if (!listeners.contains(l)){
            listeners.add(l);
        }
    }


}
