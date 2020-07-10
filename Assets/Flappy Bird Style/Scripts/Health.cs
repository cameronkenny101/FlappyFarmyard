using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject heart1, heart2, heart3; // three hearts
    public static int health; // health points

    void Start()
    {
        health = 3; // health initialised to three
    }

///Temporary, DO NOT call this every frame!!!
    void Update()
    {
        // See two hearts on screen
        if(health == 2)
        {
            heart1.gameObject.SetActive(false);
        }

        // See one heart on screen
        if(health == 1)
        {
            heart2.gameObject.SetActive(false);
        }

        // See no hearts, Game Over
        if(health == 0)
        {
            heart3.gameObject.SetActive(false);
        }
    }

}
