using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupScript:MonoBehaviour{
	Scene currentScene;
	void Start(){
		currentScene=SceneManager.GetActiveScene();
		gameObject.SetActive(false);
	}
	public void Activate(){
		gameObject.SetActive(true);
		if(currentScene.name=="Game")
			Time.timeScale=0;
	}
	public void Deactivate(){
		gameObject.SetActive(false);
		if(currentScene.name=="Game")
			Time.timeScale=1;
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
		Time.timeScale=1;
	}
}