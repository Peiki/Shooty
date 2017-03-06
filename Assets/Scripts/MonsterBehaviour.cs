using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterMovement:MonoBehaviour{
	public float speed=2.0f;
	void Update(){
		transform.Translate(Vector3.down*speed*Time.deltaTime);
	}
	public void die(){
		Destroy(gameObject);
	}
}