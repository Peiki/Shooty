﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerupsController:MonoBehaviour{
	[SerializeField] GameObject[] powerupObject;
	[SerializeField] GameObject coinsNumber;
	[SerializeField] GameObject noMoneyPopup;
	[SerializeField] AudioClip buySound;
	[SerializeField] AudioClip noMoneySound;
	[SerializeField] AudioClip maximumSound;
	string[] playerPrefs=new string[]{"damage","speed","health"};
	string[] playerPrefs2=new string[]{"damageCount","speedCount","healthCount"};
	float[] increment=new float[]{0.3f,-0.05f,1f};
	void Start(){
		setPowerups();
	}
	void setPowerups(){
		for(int i=0;i<powerupObject.Length;i++){
			for(int j=0;j<powerupObject[i].transform.GetChild(2).childCount;j++){
				if(j<PlayerPrefs.GetInt(playerPrefs2[i])){
					powerupObject[i].transform.GetChild(2).GetChild(j).GetComponent<Image>().color=Color.red;
					powerupObject[i].transform.GetChild(3).GetChild(1).GetComponent<Text>().text=PlayerPrefs.GetInt("powerup"+(i+1)+"Price").ToString();
				}
				else
					powerupObject[i].transform.GetChild(2).GetChild(j).GetComponent<Image>().color=new Color(0.5f,0.1f,0.1f);
				if(j+1==powerupObject[i].transform.GetChild(2).childCount && PlayerPrefs.GetInt(playerPrefs2[i])==j+1){
					powerupObject[i].transform.GetChild(3).gameObject.GetComponent<Button>().interactable=false;
					powerupObject[i].transform.GetChild(3).GetChild(0).GetComponent<Text>().text="MAXIMUM";
					powerupObject[i].transform.GetChild(3).GetChild(1).GetComponent<Text>().text="";
					powerupObject[i].transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
				}
			}
		}
	}
	public void Upgrade(int i){
		if(int.Parse(powerupObject[i].transform.GetChild(3).GetChild(1).GetComponent<Text>().text)<=PlayerPrefs.GetInt("coins")){
			PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-int.Parse(powerupObject[i].transform.GetChild(3).GetChild(1).GetComponent<Text>().text));
			coinsNumber.GetComponent<CoinAnimation>().subtractCoins(int.Parse(powerupObject[i].transform.GetChild(3).GetChild(1).GetComponent<Text>().text));
			PlayerPrefs.SetInt("powerup"+(i+1)+"Price",PlayerPrefs.GetInt("powerup"+(i+1)+"Price")+PlayerPrefs.GetInt("powerup"+(i+1)+"Price"));
			PlayerPrefs.SetFloat(playerPrefs[i],PlayerPrefs.GetFloat(playerPrefs[i])+increment[i]);
			PlayerPrefs.SetInt(playerPrefs2[i],PlayerPrefs.GetInt(playerPrefs2[i])+1);
			Debug.Log(playerPrefs[i]+" "+PlayerPrefs.GetFloat(playerPrefs[i]));
			Debug.Log(playerPrefs2[i]+" "+PlayerPrefs.GetInt(playerPrefs2[i]));
			setPowerups();
			if(PlayerPrefs.GetInt("check2")==1)
				if(PlayerPrefs.GetFloat(playerPrefs[i])==10)
					GetComponent<AudioSource>().PlayOneShot(maximumSound);
				else
					GetComponent<AudioSource>().PlayOneShot(buySound);
		}
		else{
			if(PlayerPrefs.GetInt("check2")==1)
				GetComponent<AudioSource>().PlayOneShot(noMoneySound);
			noMoneyPopup.GetComponent<PopupScript>().Activate();
		}
			noMoneyPopup.GetComponent<PopupAnimation>().resetScale();
	}
}