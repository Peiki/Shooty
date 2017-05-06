using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopController:MonoBehaviour{
	int position;
	int previousImage=-1;
	[SerializeField] Button[] buttons;
	[SerializeField] Button[] buyButtons;
	[SerializeField] GameObject[] popups;
	[SerializeField] GameObject coinsNumber;
	[SerializeField] GameObject noMoneyPopup;
	[SerializeField] string[] descriptions;
	[SerializeField] GameObject[] texts;
	[SerializeField] GameObject[] imageBoxes;
	[SerializeField] AudioClip buySound;
	[SerializeField] AudioClip equipSound;
	[SerializeField] AudioClip noMoneySound;
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
	void buy(Button button){
		PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-int.Parse(button.transform.GetChild(0).GetComponent<Text>().text));
		coinsNumber.GetComponent<CoinAnimation>().subtractCoins(int.Parse(button.transform.GetChild(0).GetComponent<Text>().text));
		Update();
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
			if(PlayerPrefs.GetInt(type+j)==2){
				buyButtons[i].interactable=false;
				buyButtons[i].transform.GetChild(0).GetComponent<Text>().text="EQUIPPED";
				buyButtons[i].transform.GetChild(1).gameObject.SetActive(false);
			}
			else if(PlayerPrefs.GetInt(type+j)==1){
				buyButtons[i].interactable=true;
				buyButtons[i].transform.GetChild(0).GetComponent<Text>().text="OWNED";
				buyButtons[i].transform.GetChild(1).gameObject.SetActive(false);
			}
			else{
				buyButtons[i].interactable=true;
				buyButtons[i].transform.GetChild(0).GetComponent<Text>().text=PlayerPrefs.GetInt(type+j+"Price").ToString()+"    ";
				buyButtons[i].transform.GetChild(1).gameObject.SetActive(true);
			}
			j++;
		}
	}
	public void buyObject(int i){
		if(buyButtons[i-1].transform.GetChild(0).GetComponent<Text>().text=="OWNED"){
			if(PlayerPrefs.GetInt("check2")==1)
				GetComponent<AudioSource>().PlayOneShot(equipSound);
			string type="weapon";
			if(position==1){
				type="skill";
				i=i-3;
			}
			unEquip(type);
			PlayerPrefs.SetInt(type+i,2);
			setUpButtons();
		}
		else{
			string type="weapon";
			if(int.Parse(buyButtons[i-1].transform.GetChild(0).GetComponent<Text>().text)<=PlayerPrefs.GetInt("coins")){
				if(PlayerPrefs.GetInt("check2")==1)
					GetComponent<AudioSource>().PlayOneShot(buySound);
				if(position==1){
					type="skill";
					i=i-3;
				}
				if(position==1)
					buy(buyButtons[i+3-1]);
				else
					buy(buyButtons[i-1]);
				unEquip(type);
				PlayerPrefs.SetInt(type+i,2);
				setUpButtons();
			}
			else{
				if(PlayerPrefs.GetInt("check2")==1)
					GetComponent<AudioSource>().PlayOneShot(noMoneySound);
				noMoneyPopup.GetComponent<PopupScript>().Activate();
			}
				noMoneyPopup.GetComponent<PopupAnimation>().resetScale();
		}
		
	}
	void unEquip(string type){
		for(int j=1;j<=3;j++)
			if(PlayerPrefs.GetInt(type+j)==2)
				PlayerPrefs.SetInt(type+j,1);
	}
	public void setDescription(int i){
		Vector2 descriptionPosition=imageBoxes[position].transform.position;
		if(position==1)
			descriptionPosition.y-=100;
		if(previousImage!=-1){
			Vector2 buttonPosition=buyButtons[previousImage].transform.parent.GetChild(5).transform.position;
			if(previousImage>=3)
				buttonPosition.y-=100;
			buyButtons[previousImage].transform.parent.GetChild(4).transform.position=buttonPosition;
		}
		texts[position].GetComponent<Text>().text=descriptions[i];
		buyButtons[i].transform.parent.GetChild(4).transform.position=descriptionPosition;
		previousImage=i;
	}
}