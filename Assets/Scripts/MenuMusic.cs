using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMusic:MonoBehaviour{
	Scene scene;
	private static MenuMusic instance;
	public MenuMusic intance{
		get{
			return instance;
		}
	}
	void Start(){
		if(PlayerPrefs.GetInt("check1")==1){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().loop=true;
		}
	}
	void Awake(){
		if(instance!=null && instance!=this){
			Destroy(this.gameObject);
			return;
		}
		else
			instance=this;
		DontDestroyOnLoad(transform.gameObject);
	}
	void Update(){
		scene=SceneManager.GetActiveScene();
		if(scene.name=="Game" || PlayerPrefs.GetInt("check1")==0)
			Destroy(this.gameObject);
	}
}