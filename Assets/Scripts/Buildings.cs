using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buildings : MonoBehaviour
{
    public GameObject Market, Shop, Factory, TownHall, Advertising, Bakery, Instruments;
    public void MarketHideShow()
    {
        Market.SetActive(!Market.activeSelf);
    }
    public void ShowHideShow()
    {
        Shop.SetActive(!Shop.activeSelf);
    }
    public void FactoryHideShow()
    {
        Factory.SetActive(!Factory.activeSelf);
    }
    public void TownHallHideShow()
    {
        TownHall.SetActive(!TownHall.activeSelf);
    }
    public void AdvertisingHideShow()
    {
        Advertising.SetActive(!Advertising.activeSelf);
    }
    public void BakeryHideShow()
    {
        Bakery.SetActive(!Bakery.activeSelf);
    }
    public void InstrumentsHideShow()
    {
        Instruments.SetActive(!Instruments.activeSelf);
    }
}
