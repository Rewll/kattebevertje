using UnityEngine;

public class VertsTest : MonoBehaviour
{

    Shapes2D.Shape shape;
    Vector2[] verts;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;

    void Start()
    {
        shape = GetComponent<Shapes2D.Shape>();
        verts = new Vector2[5];
        SetVertices();
    }

    private void Update()
    {
        SetVertices();
    }

    void SetVertices()
    {
        verts[0] = pos1.position;
        verts[1] = pos2.position;
        verts[2] = pos3.position;
        verts[3] = pos4.position;
        verts[4] = pos5.position;
        shape.settings.polyVertices = verts;
    }
}