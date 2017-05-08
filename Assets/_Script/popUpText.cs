using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpText : MonoBehaviour
{
    public GameObject popUp;
    public Canvas canvas;
    private Vector3 position = new Vector3(380, -180, 0);

    void Start()
    {

    }
    public void PopUp()
    {
        GameObject inst = (GameObject)Instantiate(popUp, position, Quaternion.identity);
        inst.transform.SetParent(canvas.transform, false);
        inst.transform.localScale = new Vector3(2, 2, 2);
        //Destroy(inst, 15.0f);
    }

}
