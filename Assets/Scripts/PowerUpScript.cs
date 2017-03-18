using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerUpScript:MonoBehaviour{
	[SerializeField] Sprite[] sprites;
	bool canMove=false;
	void Update(){
		if(canMove)
			transform.Translate(Vector3.up*Time.deltaTime);
	}
	public void setSprite(int position){
		GetComponent<SpriteRenderer>().sprite=sprites[position-1];
		canMove=true;
		StartCoroutine(Die());
	}
	public IEnumerator Die(){
		yield return new WaitForSeconds(1.0f);
		Destroy(this);
		Destroy(gameObject);
	}
}