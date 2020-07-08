using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("startGame",2);
	}

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Image>().CrossFadeAlpha(1, 1.0f, false);
    }
	
	void startGame(){
		SceneManager.LoadScene("Main");
	}

}
