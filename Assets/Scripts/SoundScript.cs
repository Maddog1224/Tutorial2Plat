using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    Animator anim;

    void Start()

    {
        musicSource.clip = musicClipOne;

        musicSource.Play();

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame

    void Update()

    {

        if (Input.GetKeyDown(KeyCode.D))

        {

    

            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyDown(KeyCode.A))

        {


            anim.SetInteger("State", 1);

        }

        if (Input.GetKeyUp(KeyCode.D))

        {

            

            anim.SetInteger("State", 0);

        }

        if (Input.GetKeyUp(KeyCode.A))

        {

            

            anim.SetInteger("State", 0);

        }

        if (Input.GetKeyDown(KeyCode.W))

        {

            

            anim.SetInteger("State", 2);

        }

        if (Input.GetKeyUp(KeyCode.W))

        {

            

            anim.SetInteger("State", 0);

        }

        if (Input.GetKeyDown(KeyCode.D))

        {

            musicSource.loop = true;

        }

        if (Input.GetKeyUp(KeyCode.P))

        {

            musicSource.loop = false;

        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}
