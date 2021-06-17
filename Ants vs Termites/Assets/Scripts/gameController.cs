using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Attack Damage", 1);
        PlayerPrefs.SetFloat("Start Health", 100);
        PlayerPrefs.SetFloat("Enemy Start Health", 1000);
        PlayerPrefs.SetFloat("Enemy Damage", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
