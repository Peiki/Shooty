using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundBehaviour:MonoBehaviour{
	void Start(){
		gameObject.SetActive(false);
	}
	void Update(){
		if(transform.position.y>0)
			transform.Translate(Vector3.down*0.1f);
	}
}