using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SB_Listener:MonoBehaviour{
	[SerializeField] GameObject weapon;
	public Rigidbody2D bullet;
	public float maxSpeed=300f;
	Vector3 direction;
	public void Start(){
		Vector3 direction=weapon.transform.forward;
	}
	public void Shoot(){
		bullet=Instantiate(bullet,weapon.transform.position,weapon.transform.rotation) as Rigidbody2D; //position to change at top of arrow
		bullet.AddForce(new Vector2(maxSpeed,0),ForceMode2D.Impulse);
	}
	 void OnTriggerEnter(Collider other){ //TESTING
        Destroy(bullet);
    }

    /*void OnColissionEnter(Collision col) {
         if(col.collider.tag == "ground")
             isGrounded = true;
    	*/
}