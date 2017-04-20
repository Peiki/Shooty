using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckSFX:MonoBehaviour{
	void Start(){
		if(PlayerPrefs.GetInt("check2")==1)
			GetComponent<AudioSource>().mute=false;
		else
			GetComponent<AudioSource>().mute=true;
	}
}