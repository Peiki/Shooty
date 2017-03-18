using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireBehaviour:MonoBehaviour{
	[SerializeField] Sprite[] fireImage;
	void Update(){
		if(gameObject.activeSelf)
			StartCoroutine(FireAnimation());
	}
	private IEnumerator FireAnimation(){
		for(int i=0;i<25;i++){
			GetComponent<SpriteRenderer>().sprite=fireImage[i];
			yield return new WaitForSeconds(0.02f);
		}
	}
	public void Activate(bool value){
		gameObject.SetActive(value);
		StartCoroutine(Wait());
	}
	private IEnumerator Wait(){
		yield return new WaitForSeconds(0.1f);
	}
}