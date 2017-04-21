using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerBehaviour:MonoBehaviour{
	[SerializeField] Sprite[] sprites;
	[SerializeField] Sprite invisible;
	[SerializeField] GameObject controller;
	int position;
	void Start(){
		transform.GetChild(0).GetComponent<Image>().sprite=invisible;
	}
	public void setTime(int position){
		this.position=position;
		transform.GetChild(0).GetComponent<Image>().sprite=sprites[position-2];
		StartCoroutine(Timer());
	}
	public IEnumerator Timer(){
		int i=15;
		if(position==4 || position==5)
			i=10;
		while(i!=0){
			transform.GetChild(1).GetComponent<Text>().text="= "+i;
			yield return new WaitForSeconds(1);
			i--;
		}
		StartCoroutine(Flash());
	}
	public IEnumerator Flash(){
		for(int i=0;i<5;i++){
			yield return new WaitForSeconds(0.2f);
			transform.GetChild(1).GetComponent<Text>().text="= 0";
			transform.GetChild(0).GetComponent<Image>().sprite=sprites[position-2];
			yield return new WaitForSeconds(0.2f);
			transform.GetChild(1).GetComponent<Text>().text="";
			transform.GetChild(0).GetComponent<Image>().sprite=invisible;
		}
		transform.GetChild(0).GetComponent<Image>().sprite=invisible;
		transform.GetChild(1).GetComponent<Text>().text="";
		controller.GetComponent<SceneController>().resetRange();
	}
}