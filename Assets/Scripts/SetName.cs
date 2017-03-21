using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetName:MonoBehaviour{
	[SerializeField] GameObject nameField;
	[SerializeField] GameObject popupName;
	void Start(){
		if(PlayerPrefs.GetString("name")=="")
			popupName.SetActive(true);
		else
			popupName.SetActive(false);
	}
	public void setName(){
		if(nameField.GetComponent<Text>().text!="")
			PlayerPrefs.SetString("name",nameField.GetComponent<Text>().text);
	}
}