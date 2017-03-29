using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuListener:MonoBehaviour{
	[SerializeField] GameObject popupName;
	[SerializeField] GameObject coinsNumber;
	[SerializeField] GameObject nameField;
	public void StartGame(){
		SceneManager.LoadScene("Game",LoadSceneMode.Single);
	}
	public void GoToShop(){
		SceneManager.LoadScene("Shop",LoadSceneMode.Single);
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}
	public void GoToLeaderboards(){
		SceneManager.LoadScene("Leaderboards",LoadSceneMode.Single);
	}
	public void GoToOptions(){
		SceneManager.LoadScene("Options",LoadSceneMode.Single);
	}
	public void GoToAccount(){
		SceneManager.LoadScene("Account",LoadSceneMode.Single);
	}
	public void ResetStats(){
		PlayerPrefs.DeleteAll();
	}
	public void AddCoins(){
		PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+500);
	}
	public void ClosePopup(){
		if(nameField.GetComponent<Text>().text!="")
			popupName.SetActive(false);
	}
	public void Update(){
		coinsNumber.GetComponent<Text>().text="= "+PlayerPrefs.GetInt("coins");
	}
}