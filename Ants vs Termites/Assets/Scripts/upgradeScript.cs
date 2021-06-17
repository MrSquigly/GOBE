using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeScript : MonoBehaviour
{
    private int x = 0;
    private int y = 0;
    private int z = 0;
    private int q = 0;

    public void fooda()
    {
        if (x == 0 && PlayerPrefs.GetFloat("Food") >= 20)
        {
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 20);
            PlayerPrefs.SetFloat("Interval", PlayerPrefs.GetFloat("Interval") - 1);
            x = 1;
        }

    }
    public void foodb()
    {
        if (x == 1 && PlayerPrefs.GetFloat("Food") >= 40)
        {
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 40);
            PlayerPrefs.SetFloat("Interval", PlayerPrefs.GetFloat("Interval") - 1);
            x = 2;
        }
    }

    public void foodc()
    {
        if (x == 2 && PlayerPrefs.GetFloat("Food") >= 60)
        {
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 60);
            PlayerPrefs.SetFloat("Interval", PlayerPrefs.GetFloat("Interval") - 1);
            x = 3;
        }


    }
    public void beetlea()
    {
        if (y == 0 && PlayerPrefs.GetFloat("Food") >= 20)
        {
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 20);
            PlayerPrefs.SetFloat("Attack Damage", PlayerPrefs.GetFloat("Attack Damage") + 10);
            y = 1;
        }
    }
    public void beetleb()
    {
        if (y == 1 && PlayerPrefs.GetFloat("Food") >= 40)
        {
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 40);
            PlayerPrefs.SetFloat("Attack Damage", PlayerPrefs.GetFloat("Attack Damage") + 10);
            y = 2;
        }
    }
    public void beetlec()
    {
        if (y == 2 && PlayerPrefs.GetFloat("Food") >= 60)
        {
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 60);
            PlayerPrefs.SetFloat("Attack Damage", PlayerPrefs.GetFloat("Attack Damage") + 10);
            y = 3;
        }
    }
    public void reppellenta()
    {
        if (z == 0 && PlayerPrefs.GetFloat("Food") >= 20)
        {
            PlayerPrefs.SetFloat("Repellent", PlayerPrefs.GetFloat("Repellent") + 5);
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 20);
            z = 1;
        }
    }
    public void reppellentb()
    {
        if (z == 1 && PlayerPrefs.GetFloat("Food") >= 40)
        {
            PlayerPrefs.SetFloat("Repellent", PlayerPrefs.GetFloat("Repellent") + 5);
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 20);
            z = 2;
        }
    }
    public void reppellentc()
    {
        if (z == 2 && PlayerPrefs.GetFloat("Food") >= 60)
        {
            PlayerPrefs.SetFloat("Repellent", PlayerPrefs.GetFloat("Repellent") + 5);
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 20);
            z = 3;
        }
    }
    public void incrementa()
    {
        if (q == 0 && PlayerPrefs.GetFloat("Food") >= 30)
        {
            PlayerPrefs.SetFloat("Increment", PlayerPrefs.GetFloat("Increment") + 1);
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 30);
            q = 1;
        }
    }
    public void incrementb()
    {
        if (q == 1 && PlayerPrefs.GetFloat("Food") >= 60)
        {
            PlayerPrefs.SetFloat("Increment", PlayerPrefs.GetFloat("Increment") + 1);
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 60);
            q = 2;
        }
    }
    public void incrementc()
    {
        if (q == 2 && PlayerPrefs.GetFloat("Food") >= 90)
        {
            PlayerPrefs.SetFloat("Increment", PlayerPrefs.GetFloat("Increment") + 1);
            PlayerPrefs.SetFloat("Food", PlayerPrefs.GetFloat("Food") - 90);
            q = 3;
        }
    }
 }
