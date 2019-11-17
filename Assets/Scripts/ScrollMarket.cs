using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMarket : MonoBehaviour
{
    public GameObject SellButtons;
    private Vector3 screenPoint, offset;
    private float _lockedYPos;
    private void Update()
    {
        
        if (SellButtons.transform.position.x > -1.44f)
            SellButtons.transform.position = Vector3.MoveTowards(SellButtons.transform.position, new Vector3(-1.44f, SellButtons.transform.position.y, SellButtons.transform.position.z), Time.deltaTime * 10f);
        else if (SellButtons.transform.position.x < -9)
            SellButtons.transform.position = Vector3.MoveTowards(SellButtons.transform.position, new Vector3(9, SellButtons.transform.position.y, SellButtons.transform.position.z), Time.deltaTime * 10f);
    }
    private void OnMouseDown()
    {
        _lockedYPos = screenPoint.x;
        offset = SellButtons.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = _lockedYPos;
        SellButtons.transform.position = curPosition;
    }
    private void OnMouseUp()
    {
        Cursor.visible = true;
    }
}
