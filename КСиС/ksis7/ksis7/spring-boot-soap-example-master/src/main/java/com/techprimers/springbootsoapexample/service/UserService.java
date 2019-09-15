package com.techprimers.springbootsoapexample.service;

import com.techprimers.spring_boot_soap_example.GetUserRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.ws.client.core.support.WebServiceGatewaySupport;
import java.io.IOException;

@Service
public class UserService extends WebServiceGatewaySupport {

    @Autowired
    private ServiceService serviceService;


    public void CreateHTTPPost(GetUserRequest text) throws IOException {
       if (text.getText()>0) {
           System.out.println("UserService  Called !!!");
           text.setText(text.getText() - 1);
           serviceService.getServiceData(text);
       }

    }


}
