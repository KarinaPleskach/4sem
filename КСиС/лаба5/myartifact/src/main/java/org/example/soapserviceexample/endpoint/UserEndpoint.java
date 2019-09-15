//Endpoint – класс, который будет отвечать за обработку входящих запросов (своего рода точка входа).
package org.example.soapserviceexample.endpoint;

import org.example.soapservice.GetUserRequest;
import org.example.soapservice.GetUserResponse;
import org.example.soapserviceexample.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

//Аннотация @Endpoint как раз и определяет, что данный класс будет обрабатывать входящие запросы.
@Endpoint
public class UserEndpoint {

    //namespaceUri – то же пространство имен, что и указывалось при создании xml-схемы.
    private static final String NAMESPACE_URI = "http://www.example.org/SoapService";

    //аннотация @Autowired служит для инъекции (автоматической подстановки) соответствующего объекта
    @Autowired
    public UserService userService;

    //Аннотация @PayloadRoot перед методом определяет,
    //при получении какого запроса будет вызван данный метод.
    //В нашем случае, это "getUserRequest".
    //@PayloadRoot используется Spring WS для выбора метода обработчика
    //на основе namespace и localPart сообщения
    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "getUserRequest")
    @ResponsePayload
    public GetUserResponse getUserRequest(@RequestPayload GetUserRequest text) {
        GetUserResponse getUserResponse = new GetUserResponse();
        getUserResponse = userService.getUserData(text);
        return getUserResponse;
    }
    //@ResponsePayload создает соответствующее значение возвращаемому значению полезной части ответа.
    //@RequestPayload указывает на то, что входящее сообщение будет сопоставлено параметру request метода
}
