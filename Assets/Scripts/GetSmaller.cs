﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetSmaller:MonoBehaviour{
	float scaleRate=0.01f;
	void Update(){
		transform.localScale-=Vector3.one*scaleRate;
	}
	public void resetScale(){
		transform.localScale=new Vector3(1,1,1);
		if(PlayerPrefs.GetInt("check2")==1)
			playSound();
	}
	void playSound(){
		GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
	}
}