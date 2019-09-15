package ChatSystem.jui;

import ChatSystem.clientcontents.SocketClient;
import ChatSystem.servercontents.NetworkListener;
import ChatSystem.servercontents.SocketServer;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;


class ClientGUI extends JFrame implements NetworkListener {

    private static final String SERVER_ADDRESS = "127.0.0.1";
    private  SocketClient socketClient;
    private JTextArea chatArea;


     ClientGUI() throws IOException {

         this.setLayout(new BorderLayout());
         chatArea = new JTextArea();

         try {

             socketClient = new SocketClient(SERVER_ADDRESS, SocketServer.SERVER_PORT);
             socketClient.addNetworkListener(this);
         }catch(Exception e){
             System.out.println(e);
         }


        JPanel panel = new JPanel();
        panel.setLayout(new BorderLayout());
        JTextField chatMsg = new JTextField();
        JButton sendBtn = new JButton("send");
        sendBtn.addActionListener(e -> {

            String msg = chatMsg.getText();
            chatArea.append(msg+"\n");
            chatMsg.setText("");
            socketClient.sendMsg(msg);

        });

        panel.add(chatMsg,BorderLayout.CENTER);
        panel.add(sendBtn,BorderLayout.EAST);

        this.add(chatArea,BorderLayout.CENTER);
        this.add(panel ,BorderLayout.SOUTH);

        Dimension dimension = new Dimension();
        dimension.height =400;
        dimension.width=400;
        this.setSize(dimension);

        this.setLocationRelativeTo(null);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(true);

    }


    @Override
    public void messageReceived(String msg) {

         chatArea.append(msg+"\n");

    }
}
