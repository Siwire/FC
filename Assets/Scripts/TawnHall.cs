using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TawnHall : MonoBehaviour
{
    public int countfields, storageprice; 
    public float fieldprice = 1000f;
    public Text text_fieldsprise, text_fields, text_storagelevel, text_storageprice, text_workerLevel, text_workerTimer;
    public Text[] text_workerPrice;
    public GameObject MassageMoney;
    
    public void BuyField()
    {
        int oldFieldsCount = PlayerPrefs.GetInt(UserConstants.FieldsCount);
        if (PlayerPrefs.GetFloat(UserConstants.money) >= fieldprice)
        {
            PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - fieldprice);
            PlayerPrefs.SetInt(UserConstants.FieldsCount, oldFieldsCount + 1);
        }
        else
        {
            MassageMoney.SetActive(true);
        }
    }

    public void Update()
    {
        int oldFieldsCount = PlayerPrefs.GetInt(UserConstants.FieldsCount);
        fieldprice = 1000 * (1.00f + (oldFieldsCount * 0.05f));
        float TimerWorkers = PlayerPrefs.GetFloat(UserConstants.TimerWorkers);
        TimerWorkers -= Time.deltaTime;
        if (TimerWorkers <= 0.0f)
        {
            TimerWorkers = 0;
            PlayerPrefs.SetString(UserConstants.SelectedWorker, "gamer");
        }
        PlayerPrefs.SetFloat(UserConstants.TimerWorkers, TimerWorkers);
        float timerText = PlayerPrefs.GetFloat(UserConstants.TimerWorkers);
        text_fieldsprise.text = fieldprice + "$";
        text_fields.text ="x" + PlayerPrefs.GetInt(UserConstants.FieldsCount);
        storageprice = PlayerPrefs.GetInt(UserConstants.LevelStorage) * 2;
        text_storagelevel.text = "Max:" + PlayerPrefs.GetInt(UserConstants.LevelStorage);
        text_storageprice.text = storageprice + "$";
        text_workerTimer.text = "Timer: " + Math.Round(timerText) + "s";
        if (PlayerPrefs.GetString(UserConstants.SelectedWorker) == "gamer")
        {
            text_workerLevel.text = "Level: ";
        }
        else
        {
            text_workerLevel.text = "Level: " + PlayerPrefs.GetString(UserConstants.SelectedWorker);
        }
        List<Workers> workers = ImprovememtsArray.GetWorkers();
        for (int i = 0; i < workers.Count; i++)
        {
            text_workerPrice[i].text = Math.Round(ImprovememtsArray.GetWorkers()[i].getwprice()) + "$";
        }

    }
    public void HireWorker(string wlevel)
    {
        string OldWorkerLevel = PlayerPrefs.GetString(UserConstants.SelectedWorker);
        Workers HireWorker = ImprovememtsArray.GetWorkersByLevel(wlevel);
        if (PlayerPrefs.GetFloat(UserConstants.money) >= HireWorker.getwprice())
        {
            PlayerPrefs.SetString(UserConstants.SelectedWorker, wlevel);
            PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - HireWorker.getwprice());
            float TimerWorkers = PlayerPrefs.GetFloat(UserConstants.TimerWorkers);
            if (wlevel == OldWorkerLevel)
            {
                PlayerPrefs.SetFloat(UserConstants.TimerWorkers, TimerWorkers += 30.0f);
            }
            else { 
                PlayerPrefs.SetFloat(UserConstants.TimerWorkers, 30.0f);
            }
        }
        else {
            MassageMoney.SetActive(true);
        }
                
    }
    public void MassageMoneyClose()
    {
        MassageMoney.SetActive(false);
    }
    public void BuyStorageLevel()
    {
        if (PlayerPrefs.GetFloat(UserConstants.money) >= storageprice)
        {
            PlayerPrefs.SetFloat(UserConstants.money, PlayerPrefs.GetFloat(UserConstants.money) - storageprice);
            PlayerPrefs.SetInt(UserConstants.LevelStorage, PlayerPrefs.GetInt(UserConstants.LevelStorage) + 50);
        }
        else
        {
            MassageMoney.SetActive(true);
        }
    }
}
