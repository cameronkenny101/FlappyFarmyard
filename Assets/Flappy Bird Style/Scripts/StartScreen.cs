using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
        GameControl.instance.hasStarted = false;
		Time.timeScale = 0;
        //AudioManager.instance.PlayGameMusic();
		if(Random.value > 0.6f)
		{
            AdsManager.instance.ShowVideoReward();
        }
		else if(Random.value > 0.8f)
		{
            AdsManager.instance.ShowUnityVideoAd();
		}
    }
	
	public void StartGame()
	{
       //AudioManager.instance.PlayClickSound();
		
		Time.timeScale = 1;
        GameControl.instance.hasStarted = true;
    }
}
