using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SleepEnDrop : MonoBehaviour
{
    private Camera mainCam;
    public bool slepend;

    public void Start()
    {
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseUp()
    {

    }

    private void OnMouseDrag()
    {
        slepend = true;
        transform.position = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

    }

    public void OnMouseExit()
    {
        slepend = false;
    }
}