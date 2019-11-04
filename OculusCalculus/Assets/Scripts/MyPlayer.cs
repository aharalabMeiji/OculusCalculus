using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPlayer : MonoBehaviour
{
    public GameObject XAxis, YAxis, ZAxis, XYPlane;
    public float CoordMax = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        //setSizeOfSpace(100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            SceneManager.LoadScene("Scenes/Museum");
        }
    }

    void setSizeOfSpace(float s)
    {
        XAxis.transform.localScale = (s + 0.1f) * 2f * Vector3.right + 0.1f * Vector3.up + 0.1f * Vector3.forward;
        YAxis.transform.localScale = 0.1f * Vector3.right + 0.1f * Vector3.up + (s + 0.1f) * 2f * Vector3.forward;
        ZAxis.transform.localScale = 0.1f * Vector3.right + (s + 0.1f) * 2f * Vector3.up + 0.1f * Vector3.forward;
        XYPlane.transform.localScale = s * 2f * Vector3.right + 0.05f * Vector3.up + s * 2f * Vector3.forward;
    }

}
