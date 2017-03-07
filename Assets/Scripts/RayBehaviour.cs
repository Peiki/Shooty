using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayBehaviour:MonoBehaviour{
	public float damage;
	bool running=false;
	[SerializeField] GameObject weapon;
	[SerializeField] Sprite[] rayImage;
	void Start(){
		Vector2 weaponPosition=weapon.transform.position;
		weaponPosition.y=-4.55f;
		transform.position=weaponPosition;
		gameObject.SetActive(false);
	}
	void Update(){
		transform.rotation=weapon.transform.rotation;
		if(gameObject.active && !running)
			StartCoroutine(RayAnimation());
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag=="Monster")
			collider.GetComponent<MonsterBehaviour>().getHit((int)damage);
	}
	private IEnumerator RayAnimation(){
		running=true;
		while(gameObject.active){
			for(int i=0;i<5;i++){
				GetComponent<SpriteRenderer>().sprite=rayImage[i];
				yield return new WaitForSeconds(0.1f);
			}
		}
		running=false;
	}
}