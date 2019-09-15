package ChatSystem.servercontents;

import com.techprimers.springbootsoapexample.service.FileHandler;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.Socket;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Scanner;

public class ConnectionHandler implements Runnable {

    private Socket socket;
    private SocketServer server;
    private PrintWriter pr;
    private FileHandler fileHandler;


    ConnectionHandler(SocketServer server, Socket socket) {
        this.server = server;
        this.socket = socket;
        try {
            OutputStream os = socket.getOutputStream();
            pr = new PrintWriter(os);

        } catch (IOException e) {
            System.out.println(e);
        }

    }

    @Override
    public void run() {

        try {
            InputStream is = socket.getInputStream();//get input from clientcontents
            Scanner sc = new Scanner(is);
            String msg = "";
            while (sc.hasNextLine()) {//while clientcontents send data keep reading and send to the screen
                String s = sc.nextLine();
                if (check(s)) {
                    break;
                }else{
                    msg += s + "\n";
                }
            }
            System.out.println(msg);
            String date = getDate();
            server.broadcastMsg(msg + "\n\t\t" + date, ConnectionHandler.this);
            fileHandler = new FileHandler(msg);
            sc.close();// close when clientcontents stop
            socket.close();

        } catch (IOException e) {
            System.out.println(e);
        }
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

    private String getDate() {

        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        Calendar cal = Calendar.getInstance();
        return dateFormat.format(cal.getTime());
    }

    void sendMsg(String msg) {

        pr.println(msg);
        pr.flush();
    }
}
