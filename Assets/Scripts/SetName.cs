using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetName:MonoBehaviour{
	[SerializeField] GameObject nameField;
	[SerializeField] GameObject popupName;
	[SerializeField] GameObject panel;
	void Start(){
		if(PlayerPrefs.GetString("name")==""){
			PlayerPrefs.SetInt("weapon1", 2);
			PlayerPrefs.SetInt("weapon2", 0);
			PlayerPrefs.SetInt("weapon3", 0);
			PlayerPrefs.SetInt("skill1", 2);
			PlayerPrefs.SetInt("skill2", 0);
			PlayerPrefs.SetInt("skill3", 0);
			PlayerPrefs.SetInt("weapon2Price", 5000);
			PlayerPrefs.SetInt("weapon3Price", 50);
			PlayerPrefs.SetInt("skill2Price", 500);
			PlayerPrefs.SetInt("skill3Price", 50);
			PlayerPrefs.SetInt("damage",1);
			PlayerPrefs.SetInt("speed",1);
			PlayerPrefs.SetInt("health",1);
			PlayerPrefs.SetInt("check1",1);
			PlayerPrefs.SetInt("check2",1);
			PlayerPrefs.SetInt("check3",1);
			PlayerPrefs.SetInt("tut_Start",0);
			PlayerPrefs.SetInt("tut_Shop",0);
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