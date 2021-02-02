using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 offset;
    private float coord;
    private void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPos();
        coord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = coord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }
}

