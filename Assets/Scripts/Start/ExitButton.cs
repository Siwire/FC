using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnMouseUp()
    {
        Application.Quit();
        Debug.Log("Exit pressed");
        
    }

}
