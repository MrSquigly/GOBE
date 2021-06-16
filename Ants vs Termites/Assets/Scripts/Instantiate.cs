using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    
    public GameObject spritePrefab;

    float timer;
    public float cooldown;
    void Start()
    {
        Instantiate(spritePrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            if (Input.GetKeyDown("space"))
            {
                if (PlayerPrefs.GetFloat("Food") > 10)
                {
                    Instantiate(spritePrefab, transform.position, Quaternion.identity);
                    PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 10);
                }
            }
        }
    }
}
