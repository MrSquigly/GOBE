using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    
    public GameObject spritePrefab;

    public float cooldown;
    private bool canPress = true;

    void Start()
    {
        Instantiate(spritePrefab, transform.position, Quaternion.identity);
        StartCoroutine(pressCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress == true)
        {
            if (Input.GetKeyDown("space"))
            {
                if (PlayerPrefs.GetFloat("Food") >= 10)
                {
                    canPress = false;
                    Instantiate(spritePrefab, transform.position, Quaternion.identity);
                    PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 10);
                }
            }
        }
    }

    private IEnumerator pressCooldown()
    {
        while (true)
        {
            canPress = true;
            yield return new WaitForSeconds(0.8f); // I used .2 secs but you can update it as fast as you want
        }
    }
    
}
