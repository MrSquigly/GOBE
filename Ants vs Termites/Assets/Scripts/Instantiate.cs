using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spritePrefab;
    public int enemySpawn = 5;
    void Start()
    {
        Instantiate(spritePrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(PlayerPrefs.GetFloat("Food") > 10)
            {
                Instantiate(spritePrefab, transform.position, Quaternion.identity);
                PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 10);
            }
        }
    }
}
