using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TabBar : MonoBehaviour
{
    private static bool isCreated = false;
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject buttonMenu = GameObject.Find("BttnMenu");
        if (scene.name == "GameFarm")
        {
            buttonMenu.SetActive(true);
        }
        else
        {
            if (buttonMenu)
            {
                buttonMenu.SetActive(false);
            }
        }
    }
    private void Awake()
    {
        if (!isCreated)
        {
            DontDestroyOnLoad(gameObject);
            isCreated = true;
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }
    //public static void ButtonToMenuStatus(bool SetStatus)
    //{
    //    GameObject buttonMenu = GameObject.Find("BttnMenu");
    //    buttonMenu.SetActive(SetStatus);
    //}
}
