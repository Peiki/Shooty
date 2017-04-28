using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckSFX:MonoBehaviour{
	[SerializeField] GameObject sceneController;
	void Start(){
		check();
	}
	public void check(){
		if(PlayerPrefs.GetInt("check2")==1)
			GetComponent<AudioSource>().mute=false;
		else
			GetComponent<AudioSource>().mute=true;
	}
	public void check2(){
		if(PlayerPrefs.GetInt("check1")==1)
			sceneController.GetComponent<AudioSource>().mute=false;
		else
			sceneController.GetComponent<AudioSource>().mute=true;
	}
}