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
    private int y;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audio.isPlaying == false)
        {
            x = Random.Range(1, 4);
            if (x == 1 && y != 1)
            {
                audio.clip = skyrimTheme;
                audio.Play();
                y = x;
            }
            else if (x == 2 && y !=2)
            {
                audio.clip = skyrimTheme2;
                audio.Play();
                y = x;
            }
            else if (x == 3 && y != 3)
            {
                audio.clip = tossACoin;
                audio.Play();
                y = x;
            }
    }
    }
}