using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneController:MonoBehaviour{
	[SerializeField] GameObject monster;
	void Start(){
		StartCoroutine(RandomSpawn());
	}
	private IEnumerator RandomSpawn(){
		for(int n_monsters=0;n_monsters<10;n_monsters++){
			Instantiate(monster,randomPosition(),Quaternion.identity);
			yield return new WaitForSeconds(Random.Range(1,5));
		}
	}
	Vector2 randomPosition(){
		int number=Random.Range(1,5);
		float positionX;
		if(number==1)
			positionX=-4f;
		else if(number==2)
			positionX=-2f;
		else if(number==3)
			positionX=0f;
		else if(number==4)
			positionX=2f;
		else
			positionX=4f;
		return new Vector3(positionX,8.5f,-1);
	}
}