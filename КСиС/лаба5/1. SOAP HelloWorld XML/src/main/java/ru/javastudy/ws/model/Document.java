package ru.javastudy.ws.model;

import javax.xml.bind.annotation.XmlRootElement;
import java.io.Serializable;
import java.util.List;

/**
 * Created for JavaStudy.ru on 12.06.2016.
 */
@XmlRootElement(name = "document")
public class Document implements Serializable{

    private int id;
    private String name;
    private List<ru.javastudy.ws.model.Goods> goodsList;

    public Document() {
    }

    public Document(int id, String name, List<ru.javastudy.ws.model.Goods> goodsList) {
        this.id = id;
        this.name = name;
        this.goodsList = goodsList;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<ru.javastudy.ws.model.Goods> getGoodsList() {
        return goodsList;
    }

    public void setGoodsList(List<ru.javastudy.ws.model.Goods> goodsList) {
        this.goodsList = goodsList;
    }

    @Override
    public String toString() {
        return "Document{" +
                "goodsList=" + goodsList +
                ", name='" + name + '\'' +
                ", id=" + id +
                '}';
    }
}
