using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerupsController:MonoBehaviour{
	[SerializeField] GameObject[] powerupObject;
	[SerializeField] GameObject coinsNumber;
	[SerializeField] GameObject noMoneyPopup;
	string[] playerPrefs=new string[]{"damage","speed","health"};
	void Start(){
		setPowerups();
	}
	void setPowerups(){
		for(int i=0;i<powerupObject.Length;i++){
			for(int j=0;j<powerupObject[i].transform.GetChild(2).childCount;j++){
				if(j<PlayerPrefs.GetInt(playerPrefs[i]))
					powerupObject[i].transform.GetChild(2).GetChild(j).GetComponent<Image>().color=Color.red;
				else
					powerupObject[i].transform.GetChild(2).GetChild(j).GetComponent<Image>().color=new Color(0.5f,0.1f,0.1f);
				if(j+1==powerupObject[i].transform.GetChild(2).childCount && PlayerPrefs.GetInt(playerPrefs[i])==j+1){
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
			PlayerPrefs.SetInt(playerPrefs[i],PlayerPrefs.GetInt(playerPrefs[i])+1);
			setPowerups();
		}
		else
			noMoneyPopup.GetComponent<PopupScript>().Activate();
			noMoneyPopup.GetComponent<PopupAnimation>().resetPosition();
	}
}