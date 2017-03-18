using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterBehaviour:MonoBehaviour{
	public float speed;
	public float life;
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
		}
	}
    public IEnumerator FlashColor(){
    	GetComponent<SpriteRenderer>().color=Color.grey;
		yield return new WaitForSeconds(0.1f);
		if(life<=0){
			GetComponent<SpriteRenderer>().color=Color.black;
			yield return new WaitForSeconds(0.1f);
			Destroy(gameObject);
		}
		else
			GetComponent<SpriteRenderer>().color=Color.white;
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
}