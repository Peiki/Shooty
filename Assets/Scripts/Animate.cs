using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Animate:MonoBehaviour{
	[SerializeField] Sprite[] sprites;
	[SerializeField] GameObject controller;
	void Start(){
		StartCoroutine(StartAnimation());
	}
	private IEnumerator StartAnimation(){
		while(true){
			if(controller.GetComponent<ShopController>().getPosition()==1)
				for(int i=0;i<sprites.Length;i++){
					GetComponent<Image>().sprite=sprites[i];
					yield return new WaitForSeconds(0.1f);
				}		
		}
	}
}