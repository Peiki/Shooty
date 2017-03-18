using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BarrierBehaviour:MonoBehaviour{
	void Start(){
		tag="Shield";
		gameObject.SetActive(false);
	}
	public void Activate(){
		gameObject.SetActive(true);
		StartCoroutine(Timer());
	}
	public IEnumerator Timer(){
		yield return new WaitForSeconds(10);
		gameObject.SetActive(false);
	}
}