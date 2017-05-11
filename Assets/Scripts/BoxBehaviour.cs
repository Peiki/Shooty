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
	[SerializeField] GameObject fireball;
	int powerup;
	int time;
	bool setDead=false;
	void Start(){
		powerup=Random.Range(1,10);
	}
	void Update(){
		if(GetComponent<MonsterBehaviour>().getDead() && !setDead)
			Activate();
	}
	public void Activate(){
		setDead=true;
		time=15;
		bool activated=false;
		do{
			if(PlayerPrefs.GetInt("check2")==1)
				playSound();
			if(powerup==1){
				controller.GetComponent<SceneController>().addHeart();
				controller.GetComponent<SceneController>().resetRange();
				activated=true;
			}
			else if(powerup==2){
				shoot.GetComponent<SB_Listener>().setFireRate(0.1f);
				activated=true;
			}
			else if(powerup==3){
				bullet.GetComponent<BulletScript>().setDamage(PlayerPrefs.GetFloat("damage")+2);
				activated=true;
			}
			else if(powerup==4){
				barrier.GetComponent<BarrierBehaviour>().Activate();
				time=10;
				activated=true;
			}
			else if(powerup==5){
				shoot.GetComponent<SB_Listener>().enableTripleShoot();
				time=10;
				activated=true;
			}
			else if(powerup==6 && PlayerPrefs.GetInt("powerup1")==1){
				float posX=-5.48f;
				for(int i=0;i<12;i++){
					Instantiate(fireball,new Vector3(posX,-3.91f,-1),Quaternion.identity).GetComponent<FireballBehaviour>().setActive(true);
					posX=posX+1;
				}
				activated=true;
			}
			/*else if(powerup==7 && PlayerPrefs.GetInt("powerup2")==1){
				activated=true;
			}
			else if(powerup==8 && PlayerPrefs.GetInt("powerup3")==1){
				activated=true;
			}
			else if(powerup==9 && PlayerPrefs.GetInt("powerup4")==1){
				activated=true;
			}*/
			if(!activated)
				powerup=Random.Range(1,10);
		}while(!activated);
		if(powerup!=1 && powerup!=6)
			timerOnGui.GetComponent<TimerBehaviour>().setTime(powerup);
		controller.GetComponent<SceneController>().startTimer(time,powerup);
		Instantiate(powerupSprite,this.transform.position,Quaternion.identity).GetComponent<PowerUpScript>().setSprite(powerup);
	}
	void playSound(){
		GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
	}
}