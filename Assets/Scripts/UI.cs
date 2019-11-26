using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text text_money, text_timerplant;
    public void Update()
    {
        float timerText = PlayerPrefs.GetFloat(UserConstants.TimerPlants);
        text_timerplant.text = Math.Round(timerText) + " s   " + PlayerPrefs.GetString(UserConstants.SelectedPlant);
        text_money.text = PlayerPrefs.GetFloat(UserConstants.money) + "$";
        //Debug.Log(ImprovememtsArray.GetWorkersByLevel("first").getwprice());
    }
}
