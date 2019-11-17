using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MachineryShop : MonoBehaviour
{
    void Update()
    {
        //Debug.Log(UserConstants.TractorsCount);
    }
    public void BuyMachinery(string index)
    {
        Debug.Log("BUY");
        Machinery BuyingTractor = MachineryArray.GetMachineryByIndex(index);
        if (PlayerPrefs.GetFloat(UserConstants.money) < BuyingTractor.getPrice())
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
    }
}
