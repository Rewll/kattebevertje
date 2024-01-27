using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mond : MonoBehaviour
{
    public List<Transform> mondstukken = new List<Transform>();
    public LineRenderer LR;

    private void Start()
    {
        LR.positionCount = mondstukken.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mondstukken.Count; i++)
        {
            LR.SetPosition(i, mondstukken[i].position);
        }
    }
}