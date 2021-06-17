using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Attack Damage", 10);
        PlayerPrefs.SetFloat("Start Health", 100);
        PlayerPrefs.SetFloat("Enemy Start Health", 100);
        PlayerPrefs.SetFloat("Enemy Damage", 15);
    }
}
