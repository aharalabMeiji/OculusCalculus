using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuseumPlayer : MonoBehaviour
{
    public static Vector3 PlayerPosition;
    public static Quaternion PlayerRotation;
    public static int ContentNumber;

    public GameObject RayCone;
    public GameObject RayCollider;

    public Vector3 RayStart;
    public Vector3 RayCtrl;
    public Quaternion RayDirection;
    public Vector3 CtrlPt;
    public GameObject PlayerController;
    public GameObject RightHand;
    Ray MyRay;
    public Collider MyCollider;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = FindObjectsOfType<GameObject>();
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].name.Contains("RightHandAnchor"))
            {
                RightHand = objs[i];
            }
            if (objs[i].name.Contains("RayCone"))
            {
                RayCone = objs[i];
            }
            if (objs[i].name.Contains("RayCollider"))
            {
                RayCollider = objs[i];
            }
            if (objs[i].name.Contains("OVRPlayerController"))
            {
                PlayerController = objs[i];
            }
        }
        PlayerController.transform.position = PlayerPosition;
        PlayerController.transform.rotation = PlayerRotation;
        CtrlPt = RightHand.transform.rotation * Vector3.forward;
        MyRay = new Ray();
    }

    // Update is called once per frame
    void Update()
    {
        RayStart = RightHand.transform.position;
        RayDirection = RightHand.transform.rotation;
        RayCtrl = RayDirection * Vector3.forward;
        MyRay.origin = RayStart;
        MyRay.direction = RayCtrl;

        bool hitTF = Physics.Raycast(MyRay, out RaycastHit hit);

        if (hitTF && hit.collider.name.Contains("Panel"))
        {
            MyCollider = hit.collider;
            RayCollider.transform.position = hit.point;
        }
        else
        {
            RayCollider.transform.position = 100f*Vector3.down; //RayStart + RayCtrl ;
            MyCollider = null;
        }

        RayCone.transform.position = RayStart;
        RayCone.transform.rotation = RayDirection * Quaternion.Euler(90, 0, 0);

        if (MyCollider != null && MyCollider.name.Contains("Panel"))
        {
            Debug.Log(MyCollider.name);
            if (OVRInput.Get(OVRInput.Button.One)
                || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)
                || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                //GameObject colObj = col.gameObject;
                if (MyCollider.name.Contains("Panel27"))
                {
                    ContentNumber = 27;
                    PlayerPosition = PlayerController.transform.position;
                    PlayerRotation = PlayerController.transform.rotation;
                    SceneManager.LoadScene("Scenes/LimitSample02Scene");
                }
                if (MyCollider.name.Contains("Panel28"))
                {
                    ContentNumber = 28;
                    PlayerPosition = PlayerController.transform.position;
                    PlayerRotation = PlayerController.transform.rotation;
                    SceneManager.LoadScene("Scenes/LimitSample02Scene");
                }
                if (MyCollider.name.Contains("Panel29"))
                {
                    ContentNumber = 29;
                    PlayerPosition = PlayerController.transform.position;
                    PlayerRotation = PlayerController.transform.rotation;
                    SceneManager.LoadScene("Scenes/LimitSample02Scene");
                }
            }
        }

    }
}
