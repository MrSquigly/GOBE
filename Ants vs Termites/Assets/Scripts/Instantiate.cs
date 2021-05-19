using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spritePrefab;

    void Start()
    {
        Instantiate(spritePrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(spritePrefab, transform.position, Quaternion.identity);
        }
    }
}