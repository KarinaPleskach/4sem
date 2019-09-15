package ChatSystem.clientcontents;


import ChatSystem.servercontents.NetworkListener;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.Socket;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class SocketClient {

    private PrintWriter pr;
    private Socket socket;
    private boolean recieved;
    private List<NetworkListener> listeners = new ArrayList<>();
    private String dataRecieved;

    public String getDataRecieved() {
        return dataRecieved;
    }


    public SocketClient(String serverAddress, int serverPort) throws IOException {

        socket = new Socket(serverAddress, serverPort);//will automatic send request to servercontents
        System.out.println("Client Connected To The Server ");
        OutputStream os = socket.getOutputStream();//output stream to write a msg to servercontents
        pr = new PrintWriter(os);

        new Thread(() -> {
            try {
                InputStream is = socket.getInputStream();
                Scanner sc = new Scanner(is);
                dataRecieved="";
                while (sc.hasNextLine()) {
                    String s = sc.nextLine();
                    recieved = (s != null) ? true : false;
                    if (check(s)) {
                        dataRecieved += s + "\n";
                        //break;
                    }else{
                        dataRecieved += s + "\n";
                    }
                    System.out.println(s);
                    for (NetworkListener l : listeners) {
                        l.messageReceived(s);
                    }
                }

                sc.close();

            } catch (IOException e) {
                System.out.println(e);
            }

        }).start();

    }
    private boolean check(String s) {
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        try {
            dateFormat.parse(s.trim());
        } catch (ParseException pe) {
            return false;
        }
        return true;
    }

    public void sendMsg(String msg) {
        pr.println(msg);
        pr.flush();
    }

    public void addNetworkListener(NetworkListener l) {
        if (!listeners.contains(l)) {
            listeners.add(l);
        }
    }


}
