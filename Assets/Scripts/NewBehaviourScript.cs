using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform EndPoint;
    void Start()
    {
        Vector3 asd = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f));
        Debug.Log(asd);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f));
    }
    void Update()
    {
        Vector3 asd = Vector3.MoveTowards(transform.position, EndPoint.position, Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, EndPoint.position, Time.deltaTime);
        if (transform.position == EndPoint.position)
        {
            Destroy(gameObject);
            /*transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) *Time.deltaTime;
            if (transform.localScale.x == 0.01f & transform.localScale.y == 0.01f) {
                Destroy(gameObject);
            }*/
        }
    }
}
