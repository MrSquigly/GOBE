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
   
    // Update is called once per frame
    void Update()
    {

        if (Time.timeSinceLevelLoad >= enemySpawn)
        {
            Instantiate(spritePrefab, transform.position, Quaternion.identity);
            enemySpawn += increment;

            if (increment > minIncrement)
            {
                increment *= incrementDecrease;
            }
            
        }
    }
}
