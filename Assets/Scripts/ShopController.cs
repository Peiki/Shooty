using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopController:MonoBehaviour{
	int position;
	[SerializeField] Button[] buttons;
	[SerializeField] GameObject[] popups;
	[SerializeField] GameObject coinsNumber;
	void Start(){
		changePosition(0);
	}
	public void changePosition(int position){
		this.position=position;
		for(int i=0;i<3;i++){
			if(i==position){
				buttons[i].GetComponent<Image>().color=Color.grey;
				buttons[i].interactable=false;
				popups[i].SetActive(true);
			}
			else{
				buttons[i].GetComponent<Image>().color=Color.white;
				buttons[i].interactable=true;
				popups[i].SetActive(false);
			}
		}
	}
	public int getPosition(){
		return position;
	}
	public void buy(Button button){
		if(int.Parse(button.transform.GetChild(0).GetComponent<Text>().text)<=PlayerPrefs.GetInt("coins")){
			PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-int.Parse(button.transform.GetChild(0).GetComponent<Text>().text));
			Update();
		}
		else
			Debug.Log("NOT ENOUGH MONEY!");
	}
	public void Update(){
		coinsNumber.GetComponent<Text>().text="= "+PlayerPrefs.GetInt("coins");
	}
}