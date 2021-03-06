﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetName:MonoBehaviour{
	[SerializeField] GameObject nameField;
	[SerializeField] GameObject popupName;
	[SerializeField] GameObject panel;
	void Start(){
		if(PlayerPrefs.GetString("name")==""){
			PlayerPrefs.SetInt("weapon1",2);
			PlayerPrefs.SetInt("weapon2",0);
			PlayerPrefs.SetInt("weapon3",0);
			PlayerPrefs.SetInt("skill1",2);
			PlayerPrefs.SetInt("skill2",0);
			PlayerPrefs.SetInt("skill3",0);
			PlayerPrefs.SetInt("powerup1",0);
			PlayerPrefs.SetInt("powerup2",0);
			PlayerPrefs.SetInt("powerup3",0);
			PlayerPrefs.SetInt("powerup4",0);
			PlayerPrefs.SetInt("weapon2Price",1000);
			PlayerPrefs.SetInt("weapon3Price",3500);
			PlayerPrefs.SetInt("skill2Price",2000);
			PlayerPrefs.SetInt("skill3Price",50);
			PlayerPrefs.SetInt("powerup1Price",100);
			PlayerPrefs.SetInt("powerup2Price",100);
			PlayerPrefs.SetInt("powerup3Price",1000);
			//PlayerPrefs.SetInt("powerup4Price",1250);
			PlayerPrefs.SetFloat("damage",1);
			PlayerPrefs.SetFloat("speed",0.4f);
			PlayerPrefs.SetFloat("health",3);
			PlayerPrefs.SetInt("damageCount",1);
			PlayerPrefs.SetInt("speedCount",1);
			PlayerPrefs.SetInt("healthCount",1);
			PlayerPrefs.SetInt("check1",1);
			PlayerPrefs.SetInt("check2",1);
			PlayerPrefs.SetInt("check3",1);
			PlayerPrefs.SetInt("tut_Start",0);
			PlayerPrefs.SetInt("tut_Shop",0);
			PlayerPrefs.SetInt("tut_Account",0);
			PlayerPrefs.SetInt("tut_Game",0);
			popupName.SetActive(true);
		}
		else{
			popupName.SetActive(false);
			panel.SetActive(false);
		}		
	}
	public void setName(){
		PlayerPrefs.SetString("name",nameField.GetComponent<Text>().text);
		GetComponent<StartTutorial>().check();
	}
}