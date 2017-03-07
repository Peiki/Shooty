using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitBehaviour:MonoBehaviour{
	private IEnumerator showHit(){
 		yield return new WaitForSeconds(0.2f);
 		Destroy(this);
 		Destroy(gameObject);
 	}
 	public void startCoroutine(){
 		StartCoroutine(showHit());
 	}
}