using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void OnMouseUp()
    {
        SceneManager.LoadScene("GameFarm");
        
    }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.022f, 0.022f, 0.022f);
    }

}
