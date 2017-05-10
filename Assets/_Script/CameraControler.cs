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
        //float targetAspect = 16.0f / 9.0f;
        //float windowsAspect = (float)Screen.width / (float)Screen.height;
        //float scaleHeight = windowsAspect / targetAspect;

        //Camera cam = GetComponent<Camera>();

        //if (scaleHeight < 1.0f)
        //{
        //    Rect rect = cam.rect;

        //    rect.width = 1.0f;
        //    rect.height = scaleHeight;
        //    rect.x = 0;
        //    rect.y = (1.0f - scaleHeight) / 2.0f;

        //    cam.rect = rect;
        //}

        //else
        //{
        //    float scaleWidth = 1.0f / scaleHeight;

        //    Rect rect = cam.rect;

        //    rect.width = scaleWidth;
        //    rect.height = 1.0f;
        //    rect.x = (1.0f - scaleWidth) / 2.0f;
        //    rect.y = 0;

        //    cam.rect = rect;
        //}
    }

    // Update is called once per frame
    void Update()
    {



    }
}
