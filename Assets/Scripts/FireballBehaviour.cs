using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireballBehaviour:MonoBehaviour{
	public int speed;
	public int damage;
	bool active;
	[SerializeField] GameObject hitSprite;
	void Update(){
		if(active){
			transform.Translate(Vector3.up*speed*Time.deltaTime);
		}
	}
	public void OnBecameInvisible(){
		if(active){
			Destroy(this);
	 		Destroy(gameObject);
		}
 	}
	public void setActive(bool value){
		active=value;
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag=="Monster"){
			Vector3 position=transform.position;
			position.z=-2;
			Instantiate(hitSprite,position,Quaternion.identity).GetComponent<HitBehaviour>().startCoroutine();
			collider.GetComponent<MonsterBehaviour>().getHit((int)damage);
			Destroy(this);
			Destroy(gameObject);
		}
	}
}