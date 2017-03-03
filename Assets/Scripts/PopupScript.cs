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
	}
	public void Deactivate(){
		gameObject.SetActive(false);
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}
}
