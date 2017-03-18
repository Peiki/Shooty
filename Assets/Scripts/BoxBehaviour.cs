using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxBehaviour:MonoBehaviour{
	//shield(?), tri-shot
	[SerializeField] GameObject controller;
	[SerializeField] GameObject powerupSprite;
	[SerializeField] GameObject shoot;
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject timerOnGui;
	int powerup;
	bool setDead=false;
	void Start(){
		powerup=Random.Range(1,4);
	}
	void Update(){
		if(GetComponent<MonsterBehaviour>().getDead() && !setDead)
			Activate();
	}
	public void Activate(){
		setDead=true;
		if(powerup==1)
			controller.GetComponent<SceneController>().addHeart();
		else if(powerup==2)
			shoot.GetComponent<SB_Listener>().setFireRate(0.1f);
		else if(powerup==3)
			bullet.GetComponent<BulletScript>().setDamage(3);
		if(powerup!=1)
			timerOnGui.GetComponent<TimerBehaviour>().setTime(powerup);
		controller.GetComponent<SceneController>().startTimer(15,powerup);
		Instantiate(powerupSprite,this.transform.position,Quaternion.identity).GetComponent<PowerUpScript>().setSprite(powerup);
	}
}