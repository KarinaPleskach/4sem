package ChatSystem.servercontents;

import java.io.IOException;

import java.net.ServerSocket;
import java.net.Socket;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * The Main Server
 * using for Create New Output Road to allow other Sockets clientcontents connect to him
 * when the server find any clientcontents the method return socket object throw socket
 * we get output stream then we put it into print writer method then we send to
 * the method send msg in server handler to handel it  and send back to server again
 */

public class SocketServer {
    public static  final  int SERVER_PORT = 5000;
    public static  boolean recieved = true ;
    private static final boolean CONTAIN_CLIENTS = true;
    private List<ConnectionHandler> handlers ;

    SocketServer()throws IOException{

        handlers = new ArrayList<>();
        ExecutorService service = Executors.newFixedThreadPool(10);// to add maximum 10 clients
        try{
            ServerSocket serverSocket = new ServerSocket(SERVER_PORT);//create server socket
            while (CONTAIN_CLIENTS) {
                Socket socket = serverSocket.accept(); // go and listen
                //if found clientcontents create new thread
                ConnectionHandler connectionHandler = new ConnectionHandler(this,socket);
                handlers.add(connectionHandler);//save all clientcontents to send broadcast
                service.execute(connectionHandler);
              }
        }catch(IOException e ){

            System.out.println(e);
        }

    }

    /**
     * @param msg main message for sharing
     * @param sender the clientcontents who send's the message
     */
     void broadcastMsg(String msg, ConnectionHandler sender) {
         if (recieved) {
             for (ConnectionHandler handler : handlers) {
                 if (!handler.equals(sender)) {
                     handler.sendMsg(msg);
                 } else {
                     handler.sendMsg("Server replied " + msg);
                 }
             }

         }
     }
}
