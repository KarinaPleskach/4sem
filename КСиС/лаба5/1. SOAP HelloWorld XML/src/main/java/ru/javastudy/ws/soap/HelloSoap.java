package ru.javastudy.ws.soap;

import ru.javastudy.ws.model.Goods;
import javax.jws.WebService;

/**
 * Created for JavaStudy.ru on 10.06.2016.
 */
@WebService(endpointInterface = "ru.javastudy.ws.soap.WebserviceSEI",
        serviceName = "HelloSoap")
public class HelloSoap implements ru.javastudy.ws.soap.WebserviceSEI {

    @Override
    public String testService() {
        return "Hello from SOAP Webservice!";
    }

    @Override
    public String sayHelloTo(String text) {
        return "Hello to " + text;
    }

    @Override
    public Goods getGoods() {
        Goods goods = new Goods();
        goods.setId(1);
        goods.setName("Some goods test name");
        return goods;
    }
}
