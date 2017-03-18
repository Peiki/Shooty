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
	public void Shoot(){
		if(canShoot()){
			angle=weapon.transform.rotation.z*2.3f;
			Vector3 position=new Vector3(weapon.transform.position.x,weapon.transform.position.y,0);
			Vector2 direction=new Vector2(-(distance*Mathf.Sin(angle)),distance*Mathf.Cos(angle));
			Instantiate(bullet,position,weapon.transform.rotation).GetComponent<BulletScript>().setDirection(direction);
			shootEnabled=false;
			StartCoroutine(WaitTime());
		}
	}
	bool canShoot(){
		return shootEnabled;
	}
	private IEnumerator WaitTime(){
		yield return new WaitForSeconds(fireRate);
		shootEnabled=true;
	}
	public void setInteractable(bool value){
		GetComponent<Button>().interactable=value;
	}
	public void setFireRate(float fireRate){
		this.fireRate=fireRate;
	}
}