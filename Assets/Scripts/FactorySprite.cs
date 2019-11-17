using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySprite : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetInt(UserConstants.CountFactory) == 0)
        {
            Destroy(gameObject);
        }
    }
}
