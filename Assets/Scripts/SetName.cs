using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetName:MonoBehaviour{
	[SerializeField] GameObject nameField;
	[SerializeField] GameObject popupName;
	void Start(){
		Debug.Log(PlayerPrefs.GetString("name"));
		if(PlayerPrefs.GetString("name")=="")
			popupName.SetActive(true);
		else
			popupName.SetActive(false);
	}
	public void setName(){
		PlayerPrefs.SetString("name",nameField.GetComponent<Text>().text);
	}
}