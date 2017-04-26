using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayBehaviour:MonoBehaviour{
	public float damage;
	bool running=false;
	[SerializeField] GameObject weapon;
	[SerializeField] Sprite[] rayImage1;
	void Start(){
		Vector3 weaponPosition=weapon.transform.position;
		weaponPosition.y=-4.55f;
		weaponPosition.z=-1;
		transform.position=weaponPosition;
		gameObject.SetActive(false);
	}
	void Update(){
		transform.rotation=weapon.transform.rotation;
		if(gameObject.activeSelf && !running)
			StartCoroutine(RayAnimation());
		else if(running==true)
			running=false;
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag=="Monster")
			collider.GetComponent<MonsterBehaviour>().getHit((int)damage);
	}
	private IEnumerator RayAnimation(){
		while(gameObject.activeSelf)
			for(int i=0;i<5;i++){	
				if(PlayerPrefs.GetInt("skill1")==2)
					GetComponent<SpriteRenderer>().sprite=rayImage1[i];
				else
					Debug.Log("NOTHING");
				yield return new WaitForSeconds(0.1f);
			}
	}
	public void setActive(bool value){
		transform.rotation=weapon.transform.rotation;
		gameObject.SetActive(value);
	}
}