using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumPlayer : MonoBehaviour
{
    public static Vector3 PlayerPosition;
    public static int ContentNumber;

    public GameObject RayCone;
    public GameObject RayCollider;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = PlayerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
