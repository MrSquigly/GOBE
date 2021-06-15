using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Interval", 5);
        StartCoroutine(ScoreUpdater());
    }

    private IEnumerator ScoreUpdater()
    {
        while (true)
        { 
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") + 10);
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("Interval")); // I used .2 secs but you can update it as fast as you want
        }
    }
}
