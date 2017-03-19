using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HideScript:MonoBehaviour{
	[SerializeField] Sprite hidden;
	[SerializeField] Sprite shown;
	bool state=false;
	bool passed=false;
	void Start(){
		StartCoroutine(HideRandomly());
	}
	void Update(){
		if(transform.position.y<-3.5f && !passed){
			changeState(true);
			passed=true;
		}
	}
	void changeState(bool state){
		if(state){
			GetComponent<SpriteRenderer>().sprite=shown;
			gameObject.AddComponent<BoxCollider2D>().isTrigger=true;
		}
		else{
			GetComponent<SpriteRenderer>().sprite=hidden;
			Destroy(GetComponent<BoxCollider2D>());
		}
	}
	private IEnumerator HideRandomly(){
		while(!GetComponent<MonsterBehaviour>().getDead()){
			yield return new WaitForSeconds(Random.Range(0.5f,3));
			if(transform.position.y>=-3.5f){
				changeState(state);
				state=!state;
			}
		}
	}
}