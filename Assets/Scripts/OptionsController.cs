﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController:MonoBehaviour{
	[SerializeField] GameObject[] checkmarks;
	[SerializeField] GameObject soundSystem;
	void Start(){
		for(int i=0;i<checkmarks.Length;i++)
			if(PlayerPrefs.GetInt("check"+(i+1))==0)
				checkmarks[i].GetComponent<Toggle>().isOn=false;
	}
	public void setCheck(int i){
		if(checkmarks[i].GetComponent<Toggle>().isOn)
			PlayerPrefs.SetInt("check"+(i+1),1);
		else
			PlayerPrefs.SetInt("check"+(i+1),0);
		if(PlayerPrefs.GetInt("check2")==1)
			soundSystem.GetComponent<AudioSource>().mute=false;
		else
			soundSystem.GetComponent<AudioSource>().mute=true;
	}
}