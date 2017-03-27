using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SB_Listener:MonoBehaviour{
	[SerializeField] GameObject weapon;
	[SerializeField] GameObject bullet;
	public int distance;
	public float fireRate;
	float angle;
	bool shootEnabled=true;
	bool tripleShoot=false;
	void Update(){	
		 if(Input.touchCount==1 && Time.timeScale==1){
		 //if(Input.GetButtonDown("Fire1") && Time.timeScale==1){
		 	Vector3 direction=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		 	if(controlPosition(-5.2f,5.1f,-5.9f,-8.2f,direction) && controlPosition(4.8f,5.9f,9.6f,8.6f,direction)){
		 		weapon.transform.LookAt(direction,Vector3.forward);
		 		Vector2 direction2=new Vector2(-(distance*Mathf.Sin(angle)),distance*Mathf.Cos(angle));
		 		if(canShoot()){
		 			Instantiate(bullet,weapon.transform.position,weapon.transform.rotation).GetComponent<BulletScript>().setDirection(direction2);
		 			if(tripleShoot){
						direction2.x=direction2.x-1;
						Instantiate(bullet,weapon.transform.position,weapon.transform.rotation).GetComponent<BulletScript>().setDirection(direction2);
						direction2.x=direction2.x+2;
						Instantiate(bullet,weapon.transform.position,weapon.transform.rotation).GetComponent<BulletScript>().setDirection(direction2);
					}
		 			setShoot(false);
		 			StartCoroutine(WaitTime());
		 		}
		 	}
		 		
		 }
	}
	bool canShoot(){
		return shootEnabled;
	}
	private IEnumerator WaitTime(){
		yield return new WaitForSeconds(fireRate);
		setShoot(true);
	}
	public void setInteractable(bool value){
		GetComponent<Button>().interactable=value;
	}
	public void setFireRate(float fireRate){
		this.fireRate=fireRate;
	}
	public void enableTripleShoot(){
		tripleShoot=true;
		StartCoroutine(Timer());
	}
	private IEnumerator Timer(){
		yield return new WaitForSeconds(10);
		tripleShoot=false;
	}
	bool controlPosition(float x1,float x2,float y1,float y2,Vector3 direction){
		if(!(direction.x>x1 && direction.x<x2 && direction.y<y1 && direction.y>y2))
			return true;
		return false;
	}
	public void setShoot(bool value){
		shootEnabled=value;
	}
}