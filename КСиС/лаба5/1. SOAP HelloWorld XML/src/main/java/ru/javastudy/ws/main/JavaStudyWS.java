package ru.javastudy.ws.main;

import org.apache.cxf.jaxws.JaxWsProxyFactoryBean;
import ru.javastudy.ws.model.Goods;
import ru.javastudy.ws.soap.WebserviceSEI;

/**
 * Created for JavaStudy.ru on 09.06.2016.
 */
public class JavaStudyWS {

    public static void main(String[] args) {
        testSOAPFromClient();
    }

    /**
     * create client and test soap service
     */
    private static void testSOAPFromClient() {
        String soapServiceUrl = "http://localhost:8080/soap/webserviceSEI";

        JaxWsProxyFactoryBean factoryBean = new JaxWsProxyFactoryBean();
        factoryBean.setServiceClass(WebserviceSEI.class);
        factoryBean.setAddress(soapServiceUrl);

        WebserviceSEI webserviceSEI = (WebserviceSEI) factoryBean.create();

        Goods result = webserviceSEI.getGoods();
        System.out.println("Result: " + result);
    }

}
