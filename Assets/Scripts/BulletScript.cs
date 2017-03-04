using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletScript:MonoBehaviour{
	public float bulletSpeed=1f;
	Vector2 direction;
	bool hit=false;
	void Start(){
		
	}
	void Update(){
		transform.Translate(direction*Time.deltaTime*bulletSpeed,Space.World);
		if(transform.position.x==direction.x && transform.position.y==direction.y)
			hit=!hit;
	}
	public void setDirection(Vector2 direction){
		this.direction=direction;
	}
	public bool getHit(){
		return hit;
	}
	void OnCollisionEnter2D(Collision2D collision){
		Destroy(collision.gameObject);
		Debug.Log("HIT");
	}
	void OnTriggerEnter2D(Collider2D collider){
		Destroy(collider.gameObject);
		Debug.Log("HIT");
	}
}