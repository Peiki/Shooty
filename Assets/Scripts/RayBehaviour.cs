using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RayBehaviour:MonoBehaviour{
	public float damage;
	bool running=false;
	int skill;
	int[] length;
	[SerializeField] GameObject weapon;
	[SerializeField] Sprite[] rayImage1;
	[SerializeField] Sprite[] rayImage2;
	void Start(){
		length=new int[]{5,7,0}; 
		Vector3 weaponPosition=weapon.transform.position;
		weaponPosition.y=-4.55f;
		weaponPosition.z=-1;
		transform.position=weaponPosition;
		gameObject.SetActive(false);
		for(int i=0;i<3;i++){
			if(PlayerPrefs.GetInt("skill"+(i+1))==2)
				skill=i+1;
		}
	}
	void Update(){
		transform.rotation=weapon.transform.rotation;
		if(gameObject.activeSelf && !running)
			StartCoroutine(RayAnimation(length[skill-1]));
		else if(running==true)
			running=false;
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag=="Monster")
			if(skill==1)
				collider.GetComponent<MonsterBehaviour>().getHit((int)damage);
			else if(skill==2)
				collider.GetComponent<MonsterBehaviour>().setOnFire(true);
	}
	private IEnumerator RayAnimation(int length){
		while(gameObject.activeSelf)
			for(int i=0;i<length;i++){
				if(skill==1)
					GetComponent<SpriteRenderer>().sprite=rayImage1[i];
				else if(skill==2)
					GetComponent<SpriteRenderer>().sprite=rayImage2[i];
				yield return new WaitForSeconds(0.1f);
			}
	}
	public void setActive(bool value){
		transform.rotation=weapon.transform.rotation;
		gameObject.SetActive(value);
	}
}