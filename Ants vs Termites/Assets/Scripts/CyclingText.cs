using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CyclingText : MonoBehaviour
{
    public TMP_Text text;
    public string nameText;
    public float init;
    private float textValue;

    private void Start()
    {
        PlayerPrefs.SetFloat(nameText, init);
    }
    // Update is called once per frame
    void Update()
    {
        textValue = PlayerPrefs.GetFloat(nameText);
        text.SetText(nameText + ": {}", textValue);
    }
}
