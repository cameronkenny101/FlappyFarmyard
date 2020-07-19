using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	public void StartGame(){
		Time.timeScale = 1;
    }
}
