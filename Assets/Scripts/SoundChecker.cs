using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundChecker:MonoBehaviour{
	[SerializeField] Sprite[] soundImages;
	[SerializeField] Sprite[] musicImages;
	[SerializeField] GameObject sfxButton;
	[SerializeField] GameObject musicButton;
	[SerializeField] GameObject soundSystem;
	[SerializeField] GameObject sceneController;
	void Start(){
		musicButton.GetComponent<Image>().sprite=musicImages[PlayerPrefs.GetInt("check1")];
		sfxButton.GetComponent<Image>().sprite=soundImages[PlayerPrefs.GetInt("check2")];
	}
	public void changeSound(int i){
		if(PlayerPrefs.GetInt("check"+i)==1)
			PlayerPrefs.SetInt("check"+i,0);
		else
			PlayerPrefs.SetInt("check"+i,1);
		musicButton.GetComponent<Image>().sprite=musicImages[PlayerPrefs.GetInt("check1")];
		sfxButton.GetComponent<Image>().sprite=soundImages[PlayerPrefs.GetInt("check2")];
		soundSystem.GetComponent<CheckSFX>().check();
		soundSystem.GetComponent<CheckSFX>().check2();
	}
	public void returnToGame(){
		if(sceneController.GetComponent<SceneController>().getMusicStarted() && PlayerPrefs.GetInt("check1")==1)
			sceneController.GetComponent<AudioSource>().UnPause();
		else if(PlayerPrefs.GetInt("check1")==1){
			sceneController.GetComponent<SceneController>().playMusic();
			sceneController.GetComponent<AudioSource>().loop=true;
			sceneController.GetComponent<SceneController>().setMusicStarted(true);
		}
	}
}