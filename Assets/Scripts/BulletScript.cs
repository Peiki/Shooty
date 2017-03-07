using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletScript:MonoBehaviour{
	[SerializeField] GameObject hitSprite;
	public float bulletSpeed;
	public float damage;
	Vector2 direction;
	void Update(){
		transform.Translate(direction*Time.deltaTime*bulletSpeed,Space.World);
	}
	public void setDirection(Vector2 direction){
		this.direction=direction;
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag=="Monster"){
			Instantiate(hitSprite,transform.position,Quaternion.identity).GetComponent<HitBehaviour>().startCoroutine();
			collider.GetComponent<MonsterBehaviour>().getHit((int)damage);
			Destroy(this);
			Destroy(gameObject);
		}
	}
	public void OnBecameInvisible(){
	 	Destroy(this);
	 	Destroy(gameObject);
 	}
 	
}