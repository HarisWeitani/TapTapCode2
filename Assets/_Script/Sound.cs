using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioClip keyboard1, keyboard2, keyboard3;
    private float timeKeySounds;
    private AudioSource keyIdle;
    private int count;

	// Use this for initialization
	void Start () {
        timeKeySounds = 1;
        keyIdle = GetComponent<AudioSource>();
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {

        timeKeySounds -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {

            keyIdle.Pause();

            if (count == 0)
            {
                keyIdle.PlayOneShot(keyboard1);
                count = 1;
            }

            else if (count == 1)
            {
                keyIdle.PlayOneShot(keyboard2);
                count = 2;
            }

            else if (count == 2)
            {
                keyIdle.PlayOneShot(keyboard3);
                count = 0;
            }

            if (timeKeySounds < 0)
            {
                keyIdle.Play();
            }


        }
	}
}
