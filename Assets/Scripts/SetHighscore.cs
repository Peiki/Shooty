using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetHighscore:MonoBehaviour{
	void Start(){
		GetComponent<Text>().text+=PlayerPrefs.GetInt("highscore");
	}
}
