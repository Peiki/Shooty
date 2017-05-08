﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterBehaviour:MonoBehaviour{
	[SerializeField] GameObject coin;
	[SerializeField] AudioClip hitSound;
	[SerializeField] AudioClip deadSound;
	bool canMove=false;
	public float speed;
	public float life;
	public int chance;
	bool dead=false;
	bool onFire=false;
	void Start(){
		tag="Monster";
	}
	void Update(){
		if(!dead && canMove)
			transform.Translate(Vector3.down*speed*Time.deltaTime);
	}
	public void getHit(int damage){
		StartCoroutine(FlashColor());
		life=life-damage;
		if(life<=0){
			dead=true;
			Destroy(GetComponent<BoxCollider2D>());
			if(PlayerPrefs.GetInt("check2")==1)
				playDeadSound();
		}
		else if(PlayerPrefs.GetInt("check2")==1){
			playHitSound();
		}
	}
	public void setOnFire(bool value){
		onFire=value;
		if(value){
			StartCoroutine(FireTimer());
			StartCoroutine(FireDamage());
			GetComponent<SpriteRenderer>().color=Color.yellow;
		}
	}
	public IEnumerator FireTimer(){
		yield return new WaitForSeconds(10);
		setOnFire(false);
	}
	public IEnumerator FireDamage(){
		while(onFire){
			yield return new WaitForSeconds(1);
			getHit(1);
		}
	}
    public IEnumerator FlashColor(){
    	Color naturalColor=GetComponent<SpriteRenderer>().color;
    	if(naturalColor==Color.white)
    		GetComponent<SpriteRenderer>().color=Color.grey;
    	else
    		GetComponent<SpriteRenderer>().color=Color.red;
		yield return new WaitForSeconds(0.1f);
		if(life<=0){
			GetComponent<SpriteRenderer>().color=Color.black;
			yield return new WaitForSeconds(0.1f);
			if(Random.Range(1,chance+1)==1 && chance!=0){
				Instantiate(coin,this.transform.position,Quaternion.identity).GetComponent<CoinScript>().Activate();
				PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+1);
			}
			Destroy(gameObject);
		}
		else
			GetComponent<SpriteRenderer>().color=naturalColor;
	}
	public float getSpeed(){
		return speed;
	}
	public bool getDead(){
		return dead;
	}
	public void setDead(){
		dead=true;
	}
 	void playHitSound(){
		GetComponent<AudioSource>().PlayOneShot(hitSound);
	}
 	void playDeadSound(){
		GetComponent<AudioSource>().PlayOneShot(deadSound);
	}
	public void setMove(){
		canMove=true;
	}
}