using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {


    public Sprite PlayerSpr1;
    public Sprite PlayerSpr2;

    private SpriteRenderer sr;

    void Start () {

        sr = GetComponent<SpriteRenderer>();

        if (sr.sprite == null)
        {
            sr.sprite = PlayerSpr1;
        }
	}
	
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            SpriteChanger();
        }
	}


    void SpriteChanger()
    {
        if (sr.sprite == PlayerSpr1)
        {
            sr.sprite = PlayerSpr2;
        }

        else
        {
            sr.sprite = PlayerSpr1;
        }
    }
}
