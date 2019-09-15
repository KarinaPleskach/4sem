package com.techprimers.springbootsoapexample.endpoint;

import com.techprimers.spring_boot_soap_example.GetUserRequest;
import com.techprimers.spring_boot_soap_example.GetUserResponse;
import com.techprimers.springbootsoapexample.service.Client;
import com.techprimers.springbootsoapexample.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

import java.util.concurrent.ThreadLocalRandom;

@Endpoint
public class UserEndpoint {
    private static Client client=new Client();
    @Autowired
    public UserService userService;



    @PayloadRoot(namespace = "http://techprimers.com/spring-boot-soap-example",
            localPart = "getUserRequest")
    @ResponsePayload
    public GetUserResponse getUserRequest(@RequestPayload GetUserRequest text) throws InterruptedException {
        GetUserResponse getUserResponse = new GetUserResponse();
       // getUserResponse = userService.getUsersData(text);
        userService.serverHandleMessage(text,client);
        String data =client.getSocketClient().getDataRecieved();
        while (data ==null){
            Thread.sleep(ThreadLocalRandom.current().nextInt(1000,5000));
            data =client.getSocketClient().getDataRecieved();
        }
       // System.out.println(data+" end point");
        getUserResponse.setWords(data);
        return getUserResponse;
    }






}
