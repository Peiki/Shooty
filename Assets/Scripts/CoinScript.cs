using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinScript:MonoBehaviour{
	[SerializeField] Sprite[] coinImage;
	private IEnumerator coinAnimation(){
		while(gameObject.activeSelf)
			for(int i=0;i<10;i++){	
				GetComponent<SpriteRenderer>().sprite=coinImage[i];
				yield return new WaitForSeconds(0.016f);
			}
	}
	private IEnumerator Timer(){
		yield return new WaitForSeconds(1);
		Destroy(this);
		Destroy(gameObject);
	}
	public void Activate(){
		StartCoroutine(coinAnimation());
		StartCoroutine(Timer());
	}
}