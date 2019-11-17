using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CloudSpawn : MonoBehaviour
{
    public GameObject[] cloudPrefab;
    public float delay=5;
    public bool spawnClouds=true;
    public GameObject canvas;
    void Start()
    {
        StartCoroutine(SpawnClouds());
    }
    IEnumerator SpawnClouds()
    {
        while (true)
        {
            while (spawnClouds)
            {
                GameObject cloudPrefabObj = Instantiate(cloudPrefab[Random.Range(0, 4)]);
                cloudPrefabObj.transform.SetParent(canvas.transform);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
