using UnityEngine;
using System.Collections;

public class ColumnMov : MonoBehaviour
{

    bool move;

   // public bool top;
    float moveAmount;

    void Start()
    {
        transform.GetChild(0).transform.position = new Vector3(
            transform.GetChild(0).transform.position.x + Random.Range(-5, 5), 
            transform.GetChild(0).transform.position.y,
            transform.GetChild(0).transform.position.z);

      //  if (Random.value > 0.6f)
       // {
       //     transform.GetChild(0).gameObject.SetActive(false);
      //  }


     //   if (Random.value > 0.5f)
      //  {
      //      move = true;
      //      StartCoroutine(moveChange());
      //  }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            //If the bird hits the trigger collider in between the columns then
            //tell the game control that the bird scored.
            GameControl.instance.BirdScored();
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void Update()
    {
        if (move)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * moveAmount));
        }
    }

    IEnumerator moveChange()		///Allows object to move up and down 
    {
        moveAmount = 0.8f;
        yield return new WaitForSeconds(0.5f);
        moveAmount = -0.8f;
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(moveChange());

    }
}
