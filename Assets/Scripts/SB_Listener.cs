using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SB_Listener:MonoBehaviour{
	[SerializeField] GameObject weapon;
	public Rigidbody2D bullet;
	public float maxSpeed=300f;
	public void Shoot(){
		Vector2 position=new Vector2(weapon.transform.position.x,weapon.transform.position.y);
		Vector2 direction=new Vector2(0,8);
		RaycastHit2D hit=Physics2D.Raycast(position,direction,200);
		Debug.DrawLine(position,direction);
		if(hit.collider!=null){
			Destroy(hit.collider.gameObject);
		}		
	}
}