using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletScript:MonoBehaviour{
	[SerializeField] GameObject hitSprite;
	[SerializeField] Sprite[] bulletsImage;
	public float bulletSpeed;
	public float damage;
	Vector2 direction;
	void Start(){
		for(int i=0;i<3;i++)
			if(PlayerPrefs.GetInt("weapon"+(i+1))==2)
				GetComponent<SpriteRenderer>().sprite=bulletsImage[i];
	}
	void Update(){
		transform.Translate(direction*Time.deltaTime*bulletSpeed);
	}
	public void setDirection(Vector2 direction){
		this.direction=direction;
		if(PlayerPrefs.GetInt("check2")==1)
			playSound();
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
 	public void setDamage(int damage){
 		this.damage=damage;
 	}
	void playSound(){
		GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
	}
}