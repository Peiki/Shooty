using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapAnimation:MonoBehaviour{
	[SerializeField] Sprite[] sprites;
	bool started;
	void Update(){
		if(gameObject.activeSelf && !started){
			StartCoroutine(Animation());
			started=true;
		}
	}
	private IEnumerator Animation(){
		while(gameObject.activeSelf)
			for(int i=0;i<2;i++){
				GetComponent<Image>().sprite=sprites[i];
				yield return new WaitForSeconds(0.5f);
			}
	}
}