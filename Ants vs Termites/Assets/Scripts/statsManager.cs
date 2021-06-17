using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statsManager : MonoBehaviour
{
    public Image healthbar;

    public float attackDamage;

    public float attackTime;
    public float nextDamageEvent;

    public float startHealth;
    private float health;
    

    public Animator animator;

    public bool canAttack = true;

    public static int killCount = 0;
    private bool hasCounted = false;

    void Start()
    {
        PlayerPrefs.SetFloat("Attack Damage", attackDamage);
        PlayerPrefs.SetFloat("Start Health", startHealth);
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("Repellent") <= 0)
        {
            SceneManager.LoadScene("Game");
        }

        if(Time.time >= nextDamageEvent)
        {
            nextDamageEvent = Time.time + attackTime;
            canAttack = true;
        }
    }

    public void TakeDamage(float attackDamage)
    {
        if(canAttack == true)
        {
            health -= attackDamage;
            healthbar.fillAmount = health / startHealth;
            canAttack = false;
        }
        

        if (health <= 0)
        {

            animator.SetBool("combat", false);
            animator.SetBool("dead", true);
            Destroy(gameObject, 0.2f);
            if (gameObject.tag.Equals("Enemy")) {
                PlayerPrefs.SetFloat("Food", (PlayerPrefs.GetFloat("Food") + 1));
                if(hasCounted== false)
                {
                    killCount++;
                    hasCounted = true;
                }
            }
        }
    }
}
