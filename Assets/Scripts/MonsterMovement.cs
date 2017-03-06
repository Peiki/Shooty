using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterBehaviour:MonoBehaviour{
	[SerializeField] GameObject controller;
	public float speed=2.0f;
	void Update(){
		transform.Translate(Vector3.down*speed*Time.deltaTime);
	}
	public void die(){
		Destroy(gameObject);
		controller.GetComponent<SceneController>().monsterHit();
	}
	void OnTriggerEnter2D(Collider2D collider){
        Destroy(gameObject);
        if(collider.gameObject.tag=="Fence")
        	controller.GetComponent<SceneController>().removeHeart();
    }
}