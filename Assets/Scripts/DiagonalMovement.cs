using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DiagonalMovement:MonoBehaviour{
	float speed;
	Vector3 direction;
	void Start(){
		speed=GetComponent<MonsterBehaviour>().getSpeed();
		randomDirection();
	}
	void Update(){
		if(!GetComponent<MonsterBehaviour>().getDead())
			transform.Translate(direction*speed*Time.deltaTime);
		if(transform.position.x<-5.10 || transform.position.x>5.10)
			changeDirection();
	}
	void randomDirection(){
		int value=Random.Range(1,3);
		if(value==1)
			direction=Vector3.right;
		else
			direction=Vector3.left;
	}
	void changeDirection(){
		if(direction==Vector3.right)
			direction=Vector3.left;
		else if(direction==Vector3.left)
			direction=Vector3.right;
	}
}