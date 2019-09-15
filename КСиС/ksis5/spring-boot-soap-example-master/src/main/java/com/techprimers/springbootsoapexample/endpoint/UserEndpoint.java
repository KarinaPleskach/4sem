package com.techprimers.springbootsoapexample.endpoint;

import com.techprimers.spring_boot_soap_example.GetUserRequest;
import com.techprimers.spring_boot_soap_example.GetUserResponse;
import com.techprimers.springbootsoapexample.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

import java.util.List;
//данный класс будет обрабатывать входящие запросы
@Endpoint
public class UserEndpoint {

    @Autowired
    public UserService userService ;


// при получении какого запроса будет вызван данный метод
    @PayloadRoot(namespace = "http://techprimers.com/spring-boot-soap-example",
            localPart = "getUserRequest")
    @ResponsePayload
    public GetUserResponse getUserRequest(@RequestPayload GetUserRequest text) {
        GetUserResponse getUserResponse = new GetUserResponse();
        getUserResponse=userService.getUsersData(text);
        //getUserResponse.getWords().add(userService.getUsers(text));
        return getUserResponse;
    }
}
