﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AccountController:MonoBehaviour{
	int position;
	[SerializeField] Button[] buttons;
	[SerializeField] GameObject[] screens;
	void Start(){
		changePosition(0);
	}
	public void changePosition(int position){
		this.position=position;
		for(int i=0;i<2;i++){
			if(i==position){
				buttons[i].GetComponent<Image>().color=Color.grey;
				buttons[i].interactable=false;
				screens[i].SetActive(true);
			}
			else{
				buttons[i].GetComponent<Image>().color=Color.white;
				buttons[i].interactable=true;
				screens[i].SetActive(false);
			}
		}
	}
}