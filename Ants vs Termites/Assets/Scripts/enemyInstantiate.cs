using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInstantiate : MonoBehaviour
{
    public GameObject spritePrefab;

    float enemySpawn = 0f;
    public float increment;
    public float incrementDecrease;
    public float minIncrement;

    private bool canStart = true;

    private int mobCount = 0;
    private int waveGoal = 10;
   
    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= enemySpawn && canStart == true)
        {
            Instantiate(spritePrefab, transform.position, Quaternion.identity);
            mobCount++;
            enemySpawn += increment;

            if (mobCount == waveGoal)
            {
                StartCoroutine(WaveCooldown());
                waveGoal += 10;
                if (increment > minIncrement)
                {
                    increment *= incrementDecrease;
                }
                PlayerPrefs.SetFloat("Wave", PlayerPrefs.GetFloat("Wave") + 1);
            }
            
        }
    }

    private IEnumerator WaveCooldown()
    {
        canStart = false;
        enemySpawn += 10f;
        yield return new WaitForSeconds(10f);

        canStart = true;
    }
}
