using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletScript:MonoBehaviour{
	[SerializeField] GameObject hitSprite;
	[SerializeField] GameObject weapon;
	[SerializeField] Sprite iceBow;
	[SerializeField] Sprite[] bulletsImage;
	public float bulletSpeed;
	public float damage;
	bool sourceBullet=true;
	int freeze;
	Vector2 direction;
	void Start(){
		if(sourceBullet)
			setDamage(PlayerPrefs.GetFloat("damage"));
		for(int i=0;i<3;i++)
			if(PlayerPrefs.GetInt("weapon"+(i+1))==2)
				GetComponent<SpriteRenderer>().sprite=bulletsImage[i];
	}
	void Update(){
		transform.Translate(direction*Time.deltaTime*bulletSpeed);
		transform.position=new Vector3(transform.position.x,transform.position.y,-1);
	}
	public void setDirection(Vector2 direction){
		sourceBullet=false;
		this.direction=direction;
		if(PlayerPrefs.GetInt("check2")==1)
			playSound();
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag=="Monster"){
			Vector3 position=transform.position;
			position.z=-2;
			Instantiate(hitSprite,position,Quaternion.identity).GetComponent<HitBehaviour>().startCoroutine();
			if(weapon.GetComponent<SpriteRenderer>().sprite==iceBow){
				freeze=Random.Range(1,11);
				if(freeze==10)
					collider.GetComponent<MonsterBehaviour>().setFreeze();
			}
			collider.GetComponent<MonsterBehaviour>().getHit((int)damage);
			Destroy(this);
			Destroy(gameObject);
		}
	}
	public void OnBecameInvisible(){
	 	Destroy(this);
	 	Destroy(gameObject);
 	}
 	public void setDamage(float damage){
 		this.damage=damage;
 	}
	void playSound(){
		GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
	}
}