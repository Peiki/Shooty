using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PopupAnimation:MonoBehaviour{
	void Start(){
		transform.position=new Vector3(Screen.width/2,-200,0);
	}
	void Update(){
		if(transform.position.y<660)
			transform.Translate(Vector3.up*40);
	}
	public void resetPosition(){
		transform.position=new Vector3(400,-200,0);
	}
}