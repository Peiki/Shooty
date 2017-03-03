using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupScript:MonoBehaviour{
	void Start(){
		gameObject.SetActive(false);
	}
	public void Activate(){
		gameObject.SetActive(true);
		Time.timeScale=0;
	}
	public void Deactivate(){
		gameObject.SetActive(false);
		Time.timeScale=1;
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
		Time.timeScale=1;
	}
}
