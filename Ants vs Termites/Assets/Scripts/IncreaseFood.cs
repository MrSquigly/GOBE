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
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("Interval"));
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") + 10);
        }
    }
}
