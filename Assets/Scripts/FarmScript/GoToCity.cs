using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCity : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("GameCity");
        //TabBar.ButtonToMenuStatus(false);
    }
}
