using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterBehaviour:MonoBehaviour{
	[SerializeField] GameObject controller;
	[SerializeField] GameObject pbForeground;
	[SerializeField] GameObject fire;
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
		StartCoroutine(FlashColor(gameObject));
		life=life-damage;
		if(life<=0)
    		dead=true;
	}
	public void die(){
		Destroy(gameObject);
		controller.GetComponent<SceneController>().monsterHit();
		pbForeground.GetComponent<ProgressBar>().fillAmount(0.10f);
	}
	void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Fence"){
        	Vector3 monsterRotation=transform.rotation.eulerAngles;
        	monsterRotation.z=180;
        	Vector2 monsterPosition=transform.position;
        	monsterPosition.y=monsterPosition.y-1;
        	Instantiate(fire,monsterPosition,Quaternion.Euler(monsterRotation)).GetComponent<FireBehaviour>().Activate(true,gameObject);
        	Destroy(gameObject);
        	controller.GetComponent<SceneController>().removeHeart();
        }
    }
    public IEnumerator FlashColor(GameObject monsterObject){
    	monsterObject.GetComponent<SpriteRenderer>().color=Color.grey;
		yield return new WaitForSeconds(0.1f);
		if(life<=0){
			monsterObject.GetComponent<SpriteRenderer>().color=Color.black;
			yield return new WaitForSeconds(0.1f);
			die();
		}
		else
			monsterObject.GetComponent<SpriteRenderer>().color=Color.white;
	}
}