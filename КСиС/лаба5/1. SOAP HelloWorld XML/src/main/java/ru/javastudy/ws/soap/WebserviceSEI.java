package ru.javastudy.ws.soap;

import ru.javastudy.ws.model.Goods;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

/**
 * Created for JavaStudy.ru on 11.06.2016.
 */
/**
 * The @WebService annotation on the implementation class lets CXF know which
 * interface to use when creating WSDL. In this case its simply our HelloWorld interface.
 */
@WebService
public interface WebserviceSEI {

    @WebMethod//annotation optional and is mainly used to provide a name attribute to the public method in wsdl
    String testService();

    @WebMethod
    String sayHelloTo(@WebParam(name = "text") String text);

    @WebMethod
    Goods getGoods();
}
