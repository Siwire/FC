using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
    }
    public void OnMouseUp()
    {
        SceneManager.LoadScene("GameFarm");
        
    }
}
