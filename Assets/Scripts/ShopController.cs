using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopController:MonoBehaviour{
	int position;
	[SerializeField] Button[] buttons;
	[SerializeField] Button[] buyButtons;
	[SerializeField] GameObject[] popups;
	[SerializeField] GameObject coinsNumber;
	void Start(){
		changePosition(0);
		setUpButtons();
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
			coinsNumber.GetComponent<CoinAnimation>().subtractCoins(int.Parse(button.transform.GetChild(0).GetComponent<Text>().text));
			Update();
		}
		else
			Debug.Log("NOT ENOUGH MONEY!");
	}
	public void Update(){
		coinsNumber.GetComponent<Text>().text="= "+PlayerPrefs.GetInt("coins");
	}
	public void setUpButtons(){
		string type="weapon";
		int j=1;
		for(int i=0;i<buyButtons.Length;i++){
			if(j==4){
				type="skill";
				j=1;
			}
			Debug.Log(type+j);
			Debug.Log(PlayerPrefs.GetInt(type+j));
			if(PlayerPrefs.GetInt(type+j)==2){
				buyButtons[i].interactable=false;
				buyButtons[i].transform.GetChild(0).GetComponent<Text>().text="EQUIPPED";
				buyButtons[i].transform.GetChild(1).gameObject.SetActive(false);
			}
			else if(PlayerPrefs.GetInt(type+j)==1){
				buyButtons[i].interactable=true;
				buyButtons[i].transform.GetChild(0).GetComponent<Text>().text="OWNED";
			}
			else{
				buyButtons[i].interactable=true;
				buyButtons[i].transform.GetChild(0).GetComponent<Text>().text=PlayerPrefs.GetInt(type+j+"Price").ToString();
				buyButtons[i].transform.GetChild(1).gameObject.SetActive(true);
			}
			j++;
		}
	}
}