using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SB_Listener:MonoBehaviour{
	[SerializeField] GameObject weapon;
	[SerializeField] GameObject bullet;
	public float maxSpeed=300f;
	public int distance=10;
	public float angle;
	public void Shoot(){
		angle=weapon.transform.rotation.z*2.3f;
		Vector3 position=new Vector3(weapon.transform.position.x,weapon.transform.position.y,0);
		Vector2 direction=new Vector2(-(distance*Mathf.Sin(angle)),distance*Mathf.Cos(angle));
		Instantiate(bullet,position,weapon.transform.rotation).GetComponent<BulletScript>().setDirection(direction);
	}
}