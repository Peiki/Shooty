using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartTutorial:MonoBehaviour{
	[SerializeField] GameObject panel;
	[SerializeField] GameObject fsButton;
	[SerializeField] GameObject welcomeText;
	[SerializeField] GameObject tapText;
	int status=1;
	public void check(){
		if(PlayerPrefs.GetInt("tut_Start")==0){
			fsButton.SetActive(true);
			next();
		}
	}
	public void next(){
		switch(status){
			case 1:
				welcomeText.SetActive(true);
				tapText.SetActive(true);
				break;
			case 2:
				welcomeText.SetActive(false);
				panel.transform.GetChild(0).gameObject.SetActive(true);
				break;
			case 3:
				panel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text="Improve it playing!";
				break;
			case 4:
				panel.transform.GetChild(0).gameObject.SetActive(false);
				panel.transform.GetChild(1).gameObject.SetActive(true);
				break;
			case 5:
				tapText.SetActive(false);
				panel.transform.GetChild(1).GetChild(0).GetComponent<Text>().text="You can gain money by playing or visiting the shop!";
				break;
			case 6:
				panel.transform.GetChild(1).gameObject.SetActive(false);
				panel.transform.GetChild(2).gameObject.SetActive(true);
				break;
			case 7:
				panel.transform.GetChild(2).gameObject.SetActive(false);
				panel.transform.GetChild(3).gameObject.SetActive(true);
				break;
			case 8:
				panel.transform.GetChild(3).gameObject.SetActive(false);
				panel.transform.GetChild(4).gameObject.SetActive(true);
				break;
			case 9:
				panel.transform.GetChild(4).gameObject.SetActive(false);
				panel.transform.GetChild(5).gameObject.SetActive(true);
				break;
			case 10:
				panel.transform.GetChild(5).gameObject.SetActive(false);
				panel.transform.GetChild(6).gameObject.SetActive(true);
				break;
			case 11:
				panel.transform.GetChild(6).gameObject.SetActive(false);
				welcomeText.SetActive(true);
				welcomeText.transform.GetChild(0).GetComponent<Text>().text="HAVE FUN!";
				break;
			case 12:
				panel.SetActive(false);
				fsButton.SetActive(false);
				PlayerPrefs.SetInt("tut_Start",1);
				break;
		}
		status++;
	}
}