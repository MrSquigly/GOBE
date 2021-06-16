using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyInstantiate : MonoBehaviour
{
    public GameObject spritePrefab;
    public TMP_Text waveIndicator;

    float enemySpawn = 0f;
    public float increment;
    public float incrementDecrease;
    public float minIncrement;

    public static bool canStart = true;
    private bool canSpawn = true;

    private int mobCount = 0;
    private int waveGoal = 10;

    private void Start()
    {
        waveIndicator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeSinceLevelLoad + "compared to" + enemySpawn);

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
                Debug.Log(statsManager.killCount);
                if(statsManager.killCount == waveGoal)
                {
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
        enemySpawn += waveGoal;
        waveGoal += 10;
        canStart = false;
        waveIndicator.enabled = true;
        yield return new WaitForSeconds(10f);
        waveIndicator.enabled = false;
        canStart = true;
        canSpawn = true;
    }
}
