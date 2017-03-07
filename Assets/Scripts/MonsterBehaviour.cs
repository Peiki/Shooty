using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterBehaviour:MonoBehaviour{
	[SerializeField] GameObject controller;
	[SerializeField] GameObject pbForeground;
	public float speed;
	public float life;
	void Start(){
		tag="Monster";
	}
	void Update(){
		transform.Translate(Vector3.down*speed*Time.deltaTime);
	}
	public void getHit(int damage){
		life=life-damage;
		if(life<=0)
			die();
	}
	public void die(){
		Destroy(gameObject);
		controller.GetComponent<SceneController>().monsterHit();
		pbForeground.GetComponent<ProgressBar>().fillAmount(0.10f);
	}
	void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Fence"){
        	Destroy(gameObject);
        	controller.GetComponent<SceneController>().removeHeart();
        }
    }
}