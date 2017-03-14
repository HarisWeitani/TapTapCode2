using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public Sprite Player1;
    public Sprite Player2;
    private SpriteRenderer sr;

    private bool idle = false;
    public float timeIdle = 2.0f;
    float currentTime = 0f;
    

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Player1;
        currentTime = Time.time + timeIdle;
	}
	

	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            ChangeSprite();
            GetComponent<Animator>().Stop();
        }

        if (idle==true)
        {
            CheckIdle();
        }
	}

    void ChangeSprite()
    {
        if (sr.sprite == Player1)
        {
            sr.sprite = Player2;
        }

        else
        {
            sr.sprite = Player1;
        }
    }

    void CheckIdle()
    {
        if (Time.time > currentTime)
        {
            idle = true;
            GetComponent<Animator>().Play("PlayerMovement");
            currentTime = Time.time + timeIdle;
            
        }
    }
}
