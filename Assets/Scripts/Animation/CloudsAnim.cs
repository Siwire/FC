using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsAnim : MonoBehaviour
{
    public float minSpeed = 1;
    public float maxSpeed = 4;
    public float minY = 0;
    public float maxY = 0;
    public float distantspawn = 5;
    float speed = -1;
    float camWidth;

    void Start()
    {
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Debug.Log(camWidth);
        speed = Random.Range(minSpeed, maxSpeed);
        transform.position = new Vector3(-camWidth - distantspawn, Random.Range(minY, maxY), transform.position.z);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if(transform.position.x - distantspawn > camWidth)
        {
            Destroy(gameObject);
        }
    }
}
