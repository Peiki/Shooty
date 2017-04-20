using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterBehaviour:MonoBehaviour{
	[SerializeField] GameObject coin;
	[SerializeField] AudioClip hitSound;
	[SerializeField] AudioClip deadSound;
	public float speed;
	public float life;
	public int chance;
	bool dead=false;
	void Start(){
		tag="Monster";
	}
	void Update(){
		if(!dead)
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
    public IEnumerator FlashColor(){
    	GetComponent<SpriteRenderer>().color=Color.grey;
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
			GetComponent<SpriteRenderer>().color=Color.white;
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
	public void OnBecameInvisible(){
	 	Destroy(this);
	 	Destroy(gameObject);
 	}
 	void playHitSound(){
		GetComponent<AudioSource>().PlayOneShot(hitSound);
	}
 	void playDeadSound(){
		GetComponent<AudioSource>().PlayOneShot(deadSound);
	}
	
}