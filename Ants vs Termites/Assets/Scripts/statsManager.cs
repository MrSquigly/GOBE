using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statsManager : MonoBehaviour
{
    public Image healthbar;

    public static float attackDamage;
    public static float enemyDamage;

    public float attackTime;
    public float nextDamageEvent;

    
    public static float startHealthAlly;
    public static float startHealthEnemy;
    private float health;
    

    public Animator animator;

    public bool canAttack = true;

    public static int killCount = 0;
    private bool hasCounted = false;

    void Start()
    {
        attackDamage = PlayerPrefs.GetFloat("Attack Damage");
        startHealthAlly = PlayerPrefs.GetFloat("Start Health");
        startHealthEnemy = PlayerPrefs.GetFloat("Enemy Start Health");
        enemyDamage = PlayerPrefs.GetFloat("Enemy Damage");
        if (tag.Equals("Enemy"))
        {
            health = startHealthEnemy;
        }
        else
        {
            health = startHealthAlly;
        }
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

    public void TakeDamage()
    {
        if(canAttack == true)
        {
            if (tag.Equals("Enemy"))
            {
                health -= PlayerPrefs.GetFloat("Attack Damage");
                healthbar.fillAmount = health / startHealthEnemy;
            }
            else
            {
                health -= enemyDamage;
                healthbar.fillAmount = health / startHealthAlly;
            }
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
