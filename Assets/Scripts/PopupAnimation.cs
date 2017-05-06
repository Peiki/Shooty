using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupAnimation:MonoBehaviour{
	int width=0;
	int heigth=0;
	Scene scene;
	void Start(){
		GetComponent<RectTransform>().sizeDelta=new Vector2(0,0);
		scene=SceneManager.GetActiveScene();
	}
	void Update(){
		width=width+40;
		heigth=heigth+15;
		if(width<=800){
			GetComponent<RectTransform>().sizeDelta=new Vector2(width,heigth);
			
		}
		else if(scene.name=="Game"){
			transform.GetChild(3).gameObject.SetActive(true);
			transform.GetChild(4).gameObject.SetActive(true);			
		}
	}
	public void resetScale(){
		GetComponent<RectTransform>().sizeDelta=new Vector2(0,0);
		width=0;
		heigth=0;
		if(scene.name=="Game"){
			transform.GetChild(3).gameObject.SetActive(true);
			transform.GetChild(4).gameObject.SetActive(true);
		}
	}
}