using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AccountTutorial:MonoBehaviour{
	[SerializeField] GameObject panel;
	[SerializeField] GameObject fsButton;
	[SerializeField] GameObject tapText;
	[SerializeField] GameObject searchUserPopup;
	[SerializeField] GameObject inputFieldPlaceholder;
	[SerializeField] Button addButton;
	int status=1;
	void Start(){
		if(PlayerPrefs.GetInt("tut_Account")==1){
			panel.SetActive(false);
			fsButton.SetActive(false);
		}
	}
	public void next(){
		switch(status){
			case 1:
				panel.transform.GetChild(0).gameObject.SetActive(true);
				break;
			case 2:
				panel.transform.GetChild(0).gameObject.SetActive(false);
				panel.transform.GetChild(1).gameObject.SetActive(true);
				panel.transform.GetChild(2).gameObject.SetActive(true);
				break;
			case 3:
				panel.transform.GetChild(2).gameObject.SetActive(false);
				panel.transform.GetChild(3).gameObject.SetActive(true);
				break;
			case 4:
				tapText.SetActive(false);
				panel.transform.GetChild(3).gameObject.SetActive(false);
				panel.transform.GetChild(4).gameObject.SetActive(true);
				break;
			case 5:
				panel.transform.GetChild(1).gameObject.SetActive(false);
				panel.transform.GetChild(4).gameObject.SetActive(false);
				panel.transform.GetChild(5).gameObject.SetActive(true);
				GetComponent<AccountController>().changePosition(1);
				break;
			case 6:
				panel.transform.GetChild(5).gameObject.SetActive(false);
				panel.transform.GetChild(6).gameObject.SetActive(true);
				GetComponent<AccountController>().changeStatus();
				searchUserPopup.GetComponent<PopupScript>().Activate();
				break;
			case 7:
				panel.transform.GetChild(6).gameObject.SetActive(false);
				panel.transform.GetChild(7).gameObject.SetActive(true);
				inputFieldPlaceholder.GetComponent<Text>().text="Peiki";
				break;
			case 8:
				panel.transform.GetChild(7).gameObject.SetActive(false);
				panel.transform.GetChild(8).gameObject.SetActive(true);
				panel.transform.GetChild(9).gameObject.SetActive(true);
				searchUserPopup.GetComponent<DBSearch>().searchName("Peiki");
				break;
			case 9:
				panel.transform.GetChild(8).gameObject.SetActive(false);
				panel.transform.GetChild(9).gameObject.SetActive(false);
				panel.transform.GetChild(10).gameObject.SetActive(true);
				GetComponent<DBGetUser>().setUsername(0);
				GetComponent<DBGetUser>().openPopup();
				setButton();
				break;
			case 10:
				PlayerPrefs.SetInt("tut_Account",1);
				SceneManager.LoadScene("Account",LoadSceneMode.Single);
				break;
		}
		status++;
	}
	void setButton(){
		var colors=addButton.colors;
		colors.normalColor=Color.red;
        colors.highlightedColor=Color.red;
        addButton.transform.GetChild(0).gameObject.GetComponent<Text>().text="Remove";
        addButton.colors=colors;
        addButton.interactable=true;
	}
}