using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{


    public void moveCameraToHardware()
    {
        this.transform.position = new Vector3((float)-6.25, 0, -10);
    }

    public void moveCameraToSoftware()
    {
        this.transform.position = new Vector3((float)6.25, 0, -10);
    }

    public void moveCameraToMain()
    {
        this.transform.position = new Vector3(0, 0, -10);
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
}
