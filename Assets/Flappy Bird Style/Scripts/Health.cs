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

    void Update()
    {
        // See two hearts on screen
        if(health == 2)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
        }

        // See one heart on screen
        if(health == 1)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(true);
        }

        // See no hearts
        if(health == 0)
        {
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
        }
    }

}
