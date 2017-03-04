using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SB_Listener:MonoBehaviour{
	[SerializeField] GameObject weapon;
	[SerializeField] GameObject bullet;
	public float maxSpeed=300f;
	public int distance=5;
	public float angle;

	public void Shoot(){
		angle=weapon.transform.rotation.z*2.3f;

		Vector2 position=new Vector2(weapon.transform.position.x,weapon.transform.position.y);
		Vector2 direction=new Vector2(-(distance*Mathf.Sin(angle)),distance*Mathf.Cos(angle));

		RaycastHit2D hit=Physics2D.Raycast(position,direction,maxSpeed);

		Instantiate(bullet,position,Quaternion.identity).GetComponent<BulletScript>().setDirection(direction); //LookRotation?

		if(hit.collider!=null)
			Destroy(hit.collider.gameObject);
			/*
			Debug.Log(hit.collider.gameObject.GetComponent<BulletScript>().getHit());
			while(!(hit.collider.gameObject.GetComponent<BulletScript>().getHit())){

			}
			*/
	}
}