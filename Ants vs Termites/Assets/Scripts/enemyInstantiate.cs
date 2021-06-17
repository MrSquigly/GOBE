using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyInstantiate : MonoBehaviour
{
    public GameObject spritePrefab;
    public TMP_Text waveIndicator;

    private float enemySpawn = 0f;
    public float increment;

    public float incrementDecrease;
    public float minIncrement;

    public static bool canStart = true;
    private bool canSpawn = true;

    private int mobCount = 0;
    private int waveGoal = 10;

    private void Start()
    {
        PlayerPrefs.SetFloat("Increment", increment);
        waveIndicator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        increment = PlayerPrefs.GetFloat("Increment");
        if (Time.timeSinceLevelLoad >= enemySpawn && canStart == true)
        {
            if(canSpawn == true)
            {
                Instantiate(spritePrefab, transform.position, Quaternion.identity);
                mobCount++;
                enemySpawn += increment;
            }

            if (mobCount == waveGoal)
            {
                canSpawn = false;
                if(statsManager.killCount == waveGoal)
                {
                    statsManager.killCount = 0;
                    StartCoroutine(WaveCooldown());
                    if (increment > minIncrement)
                    {
                        increment *= incrementDecrease;
                    }
                    PlayerPrefs.SetFloat("Wave", PlayerPrefs.GetFloat("Wave") + 1);
                }
            }
        }
    }

    private IEnumerator WaveCooldown()
    {
        canStart = false;
        waveIndicator.enabled = true;
        enemySpawn = Time.timeSinceLevelLoad + 11;
        mobCount = 0;
        yield return new WaitForSeconds(10f);
        waveIndicator.enabled = false;
        canStart = true;
        canSpawn = true;
    }
}
