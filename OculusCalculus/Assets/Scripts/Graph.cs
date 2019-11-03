using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Vector3[] Vertices;
    public int[] Triangles;
    public int DivR, DivT;
    public float MaxR, MinR, MaxT, MinT, stepR, stepT;

    public Mesh MyMesh;
    public bool GraphA;

    void Start()
    {
        MaxR = 3f;
        MinR = 0f;
        MaxT = Mathf.PI * 2f;
        MinT = 0f;
        DivR = 40;
        DivT = 40;
        stepR = MaxR / DivR;
        stepT = MaxT / DivT;
        MyMesh = new Mesh();
        MakeMeshData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeMeshData()
    {
        Vertices = new Vector3[(DivR + 1) * (DivT + 1)];
        Triangles = new int[DivR * DivT * 6];
        for(int r = 0; r <= DivR; r++)
        {
            float rr = MinR + stepR * r;
            for(int t = 0; t <= DivT; t++)
            {
                float tt = MinT + stepT * t;
                float x = rr * Mathf.Cos(tt);
                float y = rr * Mathf.Sin(tt);
                float z = Func(rr, tt);
                Vertices[t + r * (DivT + 1)] = new Vector3(x, z, y);
            }
        }
        for (int r = 0; r < DivR; r++)
        {
            int r1 = r + 1;
            for (int t = 0; t < DivT; t++)
            {
                int t1 = t + 1;
                if (GraphA) {
                    Triangles[(t + r * DivT) * 6 + 0] = t + r * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 1] = t + r1 * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 2] = t1 + r1 * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 3] = t + r * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 4] = t1 + r1 * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 5] = t1 + r * (DivT + 1);
                }
                else
                {
                    Triangles[(t + r * DivT) * 6 + 0] = t + r * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 2] = t + r1 * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 1] = t1 + r1 * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 3] = t + r * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 5] = t1 + r1 * (DivT + 1);
                    Triangles[(t + r * DivT) * 6 + 4] = t1 + r * (DivT + 1);
                }
                //                Debug.Log((t + r * (DivT + 1)) + " " + (t + r1 * (DivT + 1)));
            }
        }
        MyMesh.vertices = Vertices;
        MyMesh.triangles = Triangles;
        MyMesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = MyMesh;
    }

        float Func(float rr,float tt)
    {
        float x = rr * Mathf.Cos(tt);
        float y = rr * Mathf.Sin(tt);
        if (x * x + y * y == 0f)
        {
            float xx = Mathf.Cos(tt);
            float yy = Mathf.Sin(tt);
            return xx * xx + 0.5f * xx * yy + 2f * yy * yy;
        }
        return (x * x + 0.5f * x * y + 2f * y * y) / (x * x + y * y);
    }


}
