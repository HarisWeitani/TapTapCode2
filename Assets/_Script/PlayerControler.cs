using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public Sprite Player1;
    public Sprite Player2;
    private SpriteRenderer sr;
    private Animator ani;
    private float timeAni;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Player1;
        ani = GetComponent<Animator>();
        timeAni = 1;

    }


    void Update()
    {
        timeAni -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            ani.enabled = false;
            ChangeSprite();
            timeAni = 1;
        }

        if (timeAni < 0)
        {
            ani.enabled = true;
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
}
