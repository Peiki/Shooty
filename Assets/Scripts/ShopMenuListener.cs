using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopMenuListener:MonoBehaviour{
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
	public void ResetStats(){
		PlayerPrefs.DeleteAll();
	}
	public void AddCoins(){
		PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+500);
	}
}