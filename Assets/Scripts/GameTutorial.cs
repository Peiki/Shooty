using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameTutorial:MonoBehaviour{
	[SerializeField] GameObject panel;
	[SerializeField] GameObject fsButton;
	[SerializeField] GameObject tapText;
	[SerializeField] GameObject gameOverPopup;
	[SerializeField] GameObject pbForeground;
	[SerializeField] Sprite green;
	int status=1;
	void Start(){
		if(PlayerPrefs.GetInt("tut_Game")==1){
			panel.SetActive(false);
			fsButton.SetActive(false);
			GetComponent<SceneController>().startCountdown();
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
				panel.transform.GetChild(4).gameObject.SetActive(true);
				GetComponent<SceneController>().removeHeart();
				break;
			case 5:
				panel.transform.GetChild(3).gameObject.SetActive(false);
				panel.transform.GetChild(4).gameObject.SetActive(false);
				panel.transform.GetChild(5).gameObject.SetActive(true);
				panel.transform.GetChild(6).gameObject.SetActive(true);
				GetComponent<SceneController>().removeHeart();
				GetComponent<SceneController>().removeHeart();
				Time.timeScale=1;
				break;
			case 6:
				panel.transform.GetChild(5).gameObject.SetActive(false);
				panel.transform.GetChild(6).gameObject.SetActive(false);
				GetComponent<SceneController>().addHeart();
				GetComponent<SceneController>().addHeart();
				GetComponent<SceneController>().addHeart();
				gameOverPopup.SetActive(false);
				panel.transform.GetChild(7).gameObject.SetActive(true);
				pbForeground.GetComponent<Image>().fillAmount=1;
				pbForeground.GetComponent<Image>().sprite=green;
				break;
			case 7:
				panel.transform.GetChild(7).gameObject.SetActive(false);
				panel.transform.GetChild(8).gameObject.SetActive(true);
				break;
			case 8:
				panel.transform.GetChild(8).gameObject.SetActive(false);
				panel.transform.GetChild(9).gameObject.SetActive(true);
				break;
			case 9:
				PlayerPrefs.SetInt("tut_Game",1);
				SceneManager.LoadScene("Game",LoadSceneMode.Single);
				break;
		}
		status++;
	}
}