using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxBehaviour:MonoBehaviour{
	[SerializeField] GameObject controller;
	[SerializeField] GameObject powerupSprite;
	[SerializeField] GameObject shoot;
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject timerOnGui;
	[SerializeField] GameObject barrier;
	int powerup;
	int time;
	bool setDead=false;
	void Start(){
		powerup=Random.Range(1,6);
	}
	void Update(){
		if(GetComponent<MonsterBehaviour>().getDead() && !setDead)
			Activate();
	}
	public void Activate(){
		setDead=true;
		time=15;
		if(PlayerPrefs.GetInt("check2")==1)
			playSound();
		if(powerup==1){
			controller.GetComponent<SceneController>().addHeart();
			controller.GetComponent<SceneController>().resetRange();
		}
		else if(powerup==2)
			shoot.GetComponent<SB_Listener>().setFireRate(0.1f);
		else if(powerup==3)
			bullet.GetComponent<BulletScript>().setDamage(3);
		else if(powerup==4){
			barrier.GetComponent<BarrierBehaviour>().Activate();
			time=10;
		}
		else if(powerup==5){
			shoot.GetComponent<SB_Listener>().enableTripleShoot();
			time=10;
		}
		if(powerup!=1)
			timerOnGui.GetComponent<TimerBehaviour>().setTime(powerup);
		controller.GetComponent<SceneController>().startTimer(time,powerup);
		Instantiate(powerupSprite,this.transform.position,Quaternion.identity).GetComponent<PowerUpScript>().setSprite(powerup);
	}
	void playSound(){
		GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
	}
}