using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopTutorial:MonoBehaviour{
	[SerializeField] GameObject panel;
	[SerializeField] GameObject fsButton;
	[SerializeField] GameObject tapText;
	[SerializeField] GameObject noMoneyPopup;
	[SerializeField] Button button1;
	[SerializeField] Button button2;
	int status=1;
	void Start(){
		if(PlayerPrefs.GetInt("tut_Shop")==1){
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
				break;
			case 3:
				panel.transform.GetChild(1).gameObject.SetActive(false);
				panel.transform.GetChild(2).gameObject.SetActive(true);
				break;
			case 4:
				tapText.SetActive(false);
				panel.transform.GetChild(2).gameObject.SetActive(false);
				panel.transform.GetChild(3).gameObject.SetActive(true);
				GetComponent<ShopController>().setDescription(0);
				break;
			case 5:
				panel.transform.GetChild(3).gameObject.SetActive(false);
				panel.transform.GetChild(4).gameObject.SetActive(true);
				break;
			case 6:
				panel.transform.GetChild(4).GetChild(0).GetComponent<Text>().text="The item will be automatically equipped";
				button2.interactable=false;
				button2.transform.GetChild(0).GetComponent<Text>().text="EQUIPPED";
				button2.transform.GetChild(1).gameObject.SetActive(false);
				button1.interactable=true;
				button1.transform.GetChild(0).GetComponent<Text>().text="OWNED";
				break;
			case 7:
				panel.transform.GetChild(4).gameObject.SetActive(false);
				panel.transform.GetChild(5).gameObject.SetActive(true);
				button1.interactable=false;
				button1.transform.GetChild(0).GetComponent<Text>().text="EQUIPPED";
				button1.transform.GetChild(1).gameObject.SetActive(false);
				button2.interactable=true;
				button2.transform.GetChild(0).GetComponent<Text>().text="OWNED";
				break;
			case 8:
				panel.transform.GetChild(5).gameObject.SetActive(false);
				panel.transform.GetChild(6).gameObject.SetActive(true);
				noMoneyPopup.SetActive(true);
				break;
			case 9:
				PlayerPrefs.SetInt("tut_Shop",1);
				SceneManager.LoadScene("Shop",LoadSceneMode.Single);
				break;
		}
		status++;
	}
}