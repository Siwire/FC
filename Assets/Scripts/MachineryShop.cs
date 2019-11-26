using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MachineryShop : MonoBehaviour
{
    //public Text[] text_tractor, text_harvester;
    public Text[] text_tractor;
    List<Machinery> machinery = MachineryArray.GetMachinery();
    void Update()
    {
        text_tractor[0].text = PlayerPrefs.GetInt(UserConstants.FieldsCount) - PlayerPrefs.GetInt("tractor_1") - PlayerPrefs.GetInt("tractor_1") - PlayerPrefs.GetInt("tractor_3") + "";
        text_tractor[1].text = PlayerPrefs.GetInt(UserConstants.FieldsCount) - PlayerPrefs.GetInt("tractor_2") - PlayerPrefs.GetInt("tractor_3") + "";
        text_tractor[2].text = PlayerPrefs.GetInt(UserConstants.FieldsCount) - PlayerPrefs.GetInt("tractor_3") + "";
        /*for (int i = 0; i < machinery.Count; i++) {
            text_tractor[i].text = PlayerPrefs.GetInt(machinery[i].getIndex());
        }*/
        Debug.Log(PlayerPrefs.GetInt("tractor_1"));
    }

    private string GetPreviousMachineryIndex(string MachineryType, int BuyingMachineryLevel)
    {
        List<Machinery> MachineriesByType = MachineryArray.GetMachineriesByType(MachineryType);
        for (int i = BuyingMachineryLevel - 1; i > 0; i--)
        {
            string PreviousMachineryIndex = MachineryType + "_" + i;
            int PreviousMachineryCount = PlayerPrefs.GetInt(PreviousMachineryIndex);
            Machinery MachineryPreviousLevel = MachineriesByType.Find(machine => machine.getLevel() == i);
            if (PreviousMachineryCount > 0)
            {
                return PreviousMachineryIndex;
            }
            else
            {
                return "";
            }
        }
        return "";
    }
    public void BuyMachinery(string index)
    {
        Machinery BuyingMachinary = MachineryArray.GetMachineryByIndex(index);
        List<Machinery> MachineriesByType = MachineryArray.GetMachineriesByType(BuyingMachinary.getType());

        if (PlayerPrefs.GetInt(UserConstants.TractorsCount) >= PlayerPrefs.GetInt(UserConstants.FieldsCount))
        {
            Debug.Log("Not enough fields");
        }
        if (BuyingMachinary.getLevel() > 1)
        {
            string PreviousMachineryIndex = GetPreviousMachineryIndex(BuyingMachinary.getType(), BuyingMachinary.getLevel());
            if (PreviousMachineryIndex.Length > 0)
            {
                Machinery PreviousMachinary = MachineryArray.GetMachineryByIndex(PreviousMachineryIndex);
                float ResultPriceWithDiscount = BuyingMachinary.getPrice() - PreviousMachinary.getPrice();
                if (PlayerPrefs.GetFloat(UserConstants.money) < ResultPriceWithDiscount)
                {
                    Debug.Log("Not enough money");
                }
                else
                {
                    PlayerPrefs.SetInt(index, PlayerPrefs.GetInt(index) + 1);
                    PlayerPrefs.SetInt(PreviousMachineryIndex, PlayerPrefs.GetInt(PreviousMachineryIndex) - 1);
                    PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - BuyingMachinary.getPrice() - PreviousMachinary.getPrice());
                }
            }
            else
            {
                if (PlayerPrefs.GetFloat(UserConstants.money) < BuyingMachinary.getPrice())
                {
                    Debug.Log("Not enough money");
                }
                else
                {
                    PlayerPrefs.SetInt(index, PlayerPrefs.GetInt(index) + 1);
                    PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - BuyingMachinary.getPrice());
                }
            }

            //for (int i = BuyingMachinary.getLevel() - 1; i > 0; i--)
            //{
            //    string PreviousMachineryIndex = BuyingMachinary.getType() + "_" + i;
            //    int PreviousMachineryCount = PlayerPrefs.GetInt(PreviousMachineryIndex);
            //    Machinery MachineryPreviousLevel = MachineriesByType.Find(machine => machine.getLevel() == i);
            //    if (PreviousMachineryCount > 0)
            //    {
            //        PlayerPrefs.SetInt(PreviousMachineryIndex, PlayerPrefs.GetInt(PreviousMachineryIndex) - 1);
            //        PlayerPrefs.SetInt(index, PlayerPrefs.GetInt(index) + 1);
            //        PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - BuyingMachinary.getPrice() - MachineryPreviousLevel.getPrice());
            //    }
            //    else
            //    {

            //    }
            //}
        }

        //string previousMachineryIndex = BuyingMachinary.getType() + "_" + (BuyingMachinary.getLevel() - 1);
        //Machinery previousMachinery = MachineryArray.GetMachineryByIndex(previousMachineryIndex);
        //if (PlayerPrefs.GetFloat(UserConstants.money) >= BuyingMachinary.getPrice() || PlayerPrefs.GetFloat(UserConstants.money) >= (BuyingMachinary.getPrice() - previousMachinery.getPrice()))
        //{

        //}
    }
    /*public void BuyMachinery(string index)
    {
        Machinery BuyingMachinary = MachineryArray.GetMachineryByIndex(index);
        if (PlayerPrefs.GetFloat(UserConstants.money) < BuyingMachinary.getPrice())
        {
            Debug.Log("Not enough money");
        }
        else if (PlayerPrefs.GetFloat(UserConstants.TractorsCount) >= PlayerPrefs.GetFloat(UserConstants.FieldsCount))
        {
            Debug.Log("Not enough fields");
        }
        else
        {
            if (BuyingTractor.getLevel() > 1)
            {
                string previousMachineryIndex = BuyingTractor.getType() + "_" + (BuyingTractor.getLevel() - 1);
                Machinery previousMachinery = MachineryArray.GetMachineryByIndex(previousMachineryIndex);///////////////--------------------
                PlayerPrefs.SetInt(previousMachineryIndex, PlayerPrefs.GetInt(previousMachineryIndex) - 1);
                PlayerPrefs.SetInt(index, PlayerPrefs.GetInt(index) + 1);
                if (PlayerPrefs.GetInt(previousMachineryIndex) > 0) //если у нас трактор 1 уровня - 1
                {
                    PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - BuyingTractor.getPrice() - previousMachinery.getPrice());
                }
                else
                {
                    PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - BuyingTractor.getPrice());
                    PlayerPrefs.SetFloat(UserConstants.TractorsCount, PlayerPrefs.GetFloat(UserConstants.TractorsCount) + 1);
                }
            }
            else
            {
                PlayerPrefs.SetInt(index, PlayerPrefs.GetInt(index) + 1);
                PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - BuyingTractor.getPrice());
                PlayerPrefs.SetFloat(UserConstants.TractorsCount, PlayerPrefs.GetFloat(UserConstants.TractorsCount) + 1);
            }
        }
    }*/
}

