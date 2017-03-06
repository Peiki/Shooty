using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletScript:MonoBehaviour{
	public float bulletSpeed=3f;
	Vector2 direction;
	void Update(){
		transform.Translate(direction*Time.deltaTime*bulletSpeed,Space.World);
	}
	public void setDirection(Vector2 direction){
		this.direction=direction;
	}
	void OnTriggerEnter2D(Collider2D collider){
		collider.GetComponent<MonsterBehaviour>().die();
		Destroy(this);
		Destroy(gameObject);
	}
	public void OnBecameInvisible(){
	 	Destroy(this);
	 	Destroy(gameObject);
 	}
}