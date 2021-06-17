using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioClip skyrimTheme;
    public AudioClip skyrimTheme2;
    public AudioClip tossACoin;
    public AudioSource audio;
    private int x;

    void start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audio.isPlaying == false)
        {
            x = Random.Range(1, 4);
            if (x == 1)
            {
                audio.clip = skyrimTheme;
                audio.Play();
            }
            else if (x == 2)
            {
                audio.clip = skyrimTheme2;
                audio.Play();
            }
            else if (x == 3)
            {
                audio.clip = tossACoin;
                audio.Play();
            }
    }
    }
}