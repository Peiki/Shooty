using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetName:MonoBehaviour{
	[SerializeField] GameObject nameField;
	[SerializeField] GameObject popupName;
	void Start(){
		if(PlayerPrefs.GetString("name")==""){
			popupName.SetActive(true);
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
		}
		else
			popupName.SetActive(false);
	}
	public void setName(){
		if(nameField.GetComponent<Text>().text!="")
			PlayerPrefs.SetString("name",nameField.GetComponent<Text>().text);
	}
}