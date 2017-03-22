using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinAnimation:MonoBehaviour{
	[SerializeField] GameObject moneyText;
	Vector2 originalPosition;
	void Start(){
		moneyText.SetActive(false);
		originalPosition=moneyText.transform.position;
	}
	public void subtractCoins(int amount){
		moneyText.transform.position=originalPosition;
		moneyText.SetActive(true);
		moneyText.GetComponent<Text>().text="-"+amount;
	}
	void Update(){
		if(moneyText.activeSelf)
			moneyText.transform.Translate(Vector3.up);
	}
	public void OnBecameInvisible(){
	 	moneyText.SetActive(false);
 	}
}