using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletScript:MonoBehaviour{
	public float bulletSpeed=0.001f;
	Vector2 direction;
	bool hit=false;
	void Update(){
		transform.Translate(direction*Time.deltaTime*bulletSpeed);
		if(transform.position.x==direction.x && transform.position.y==direction.y)
			hit=!hit;

	}
	public void setDirection(Vector2 direction){
		this.direction=direction;
	}
	public bool getHit(){
		return hit;
	}
}