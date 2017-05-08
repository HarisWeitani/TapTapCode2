using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpText : MonoBehaviour
{
    public GameObject popUp;
    public Canvas canvas;
    private Vector2 position = new Vector2(0, 0);

    void Start()
    {
        GameObject inst = (GameObject)Instantiate(popUp, position, Quaternion.identity);
        inst.transform.SetParent(canvas.transform);
        //Destroy(inst, 15.0f);
    }
    public void PopUp()
    {

    }

}
