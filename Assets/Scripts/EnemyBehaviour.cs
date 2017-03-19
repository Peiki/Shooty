using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehaviour:MonoBehaviour{
	[SerializeField] GameObject controller;
	[SerializeField] GameObject pbForeground;
	[SerializeField] GameObject fire;
	bool setDead=false;
	public bool attack;
	public void Update(){
		if(GetComponent<MonsterBehaviour>().getDead() && !setDead)
			die();
	}
	public void die(){
		setDead=true;
		controller.GetComponent<SceneController>().monsterHit();
		pbForeground.GetComponent<ProgressBar>().fillAmount(0.10f);
	}
	void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Fence"){
        	Vector3 monsterRotation=transform.rotation.eulerAngles;
        	monsterRotation.z=180;
        	Vector3 monsterPosition=transform.position;
        	monsterPosition.y=monsterPosition.y-1;
        	monsterPosition.z=-1;
        	if(attack)
        		Instantiate(fire,monsterPosition,Quaternion.Euler(monsterRotation)).GetComponent<FireBehaviour>().Activate(true);
        	if(!GetComponent<MonsterBehaviour>().getDead())
        		StartCoroutine(Attack());
        }
        else if(collider.gameObject.tag=="Shield"){
        	GetComponent<MonsterBehaviour>().getHit(100);
        	die();
        }
    }
    public IEnumerator Attack(){
		Destroy(GetComponent<BoxCollider2D>());
		setDead=true;
		GetComponent<MonsterBehaviour>().setDead();
		GetComponent<SpriteRenderer>().color=Color.grey;
		yield return new WaitForSeconds(0.7f);
        GetComponent<SpriteRenderer>().color=Color.black;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        controller.GetComponent<SceneController>().removeHeart();
	}
}