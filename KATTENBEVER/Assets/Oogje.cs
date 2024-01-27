using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oogje : MonoBehaviour
{
    [SerializeField]
    private Transform oogDraaiPunt;
    public float speed;
    public float rotationModifier;
    public bool pupilBewegen;
    // Update is called once per frame

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            pupilBewegen = true;
        }
        else
        {
            pupilBewegen = false;
        }
    }

    private void FixedUpdate()
    {
        if (pupilBewegen)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // zero z

            Vector3 vectorToTarget = mouseWorldPos - oogDraaiPunt.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            oogDraaiPunt.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }
}
