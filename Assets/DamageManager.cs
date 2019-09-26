using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DamageManager : MonoBehaviour
{

    public int health;

    public float invulnPeriod;

    //This is just an information holder for invulnPeriod
    float invulnTimer;

    int correctLayer;

    public bool isPlayer;

    public bool isDead;

    public Text healthText;

    public Text deadText;

    public Text pointsText;

    public int points = 0;

    public float restartDelay = 2f;

    private void Start()
    {
        correctLayer = gameObject.layer;

        Debug.Log("Correct Layer: " + correctLayer);

        deadText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I'm Hit!");

        //This is the invulnerability layer where it will not trigger on obstacle or enemies
        gameObject.layer = 10;

        --health;

        //Here we set the Timer to be equal to whatever we want the period of invulnerability to be
        invulnTimer = invulnPeriod;

    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayer == true)
        {
            healthText.text = ("Health: " + health);

            if (isDead == false)
            {
                pointsText.text = ("Points: " + points);

                ++points;

            }
            
        }

        if (transform.position.x > 216 && isDead == false)
        {
           health = 2;
        }

        //This subracts from the invulnTimer based on time
        invulnTimer -= Time.deltaTime;

        if (invulnTimer <= 0)
        {
            Debug.Log("Layer Changed!");
            gameObject.layer = correctLayer;
        }

        if(health <= 0)
        {
            Die();
        }

        if (isDead == true)
        {
            restartDelay -= Time.deltaTime;
        }


    }

    void Die()
    {

        //if the object isn't a player it'll just disappear
        if (isPlayer == false)
        {
            Destroy(gameObject);
        }
        
        //if the object is the player it will instead tell the game that it is dead and start a countdown
        //once the count down reaches 0 it will set the scene to the menu
        if(isPlayer == true)
        {
            isDead = true;

            deadText.text = "You Died!";

            if(restartDelay <= 0)
            {
                SceneManager.LoadScene(0);
            }
            
        }
        
    }


}
