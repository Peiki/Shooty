using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpecialListener:MonoBehaviour{
	void Start(){
		GetComponent<Button>().interactable=false;
	}
	public void setInteractable(bool value){
		GetComponent<Button>().interactable=value;
		if(value==true)
			GetComponent<Image>().color=Color.white;
		if(value==false)
			GetComponent<Image>().color=Color.grey;
	}
}