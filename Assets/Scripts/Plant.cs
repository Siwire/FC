using System.Collections.Generic;
using UnityEngine;
public class Plant
{
    public string index;
    private string title;
    private int price;
    private float countChange;
    private float sellprice;
    private int spritePlant;

       public Plant(string index, string title, int price, float countChange, float sellprice, int spritePlant)
    {
        this.index = index;
        this.title = title;
        this.price = price;
        this.countChange = countChange;
        this.sellprice = sellprice;
        this.spritePlant = spritePlant;
    }

    public string getIndex()
    {
        return index;
    }

    public float getPrice() {
        return price;
    }
    public string getTitle()
    {
        return title;
    }
    public float getCountChange()
    {
        return countChange;
    }
    public float getSellPrice()
    {
        return sellprice;
    }
    public int getPlantSprite()
    {
        return spritePlant;
    }
}
