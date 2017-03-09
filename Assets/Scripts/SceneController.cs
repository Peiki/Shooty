using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneController:MonoBehaviour{
	int monster_hit=0;
	int hearts=3;
	int maxSeconds=5;
	[SerializeField] GameObject monster;
	[SerializeField] GameObject fence;
	[SerializeField] GameObject ray;
	[SerializeField] GameObject gameOverPopup;
	[SerializeField] GameObject monsterKilled;
	[SerializeField] GameObject[] heartObject;
	[SerializeField] Sprite emptyHeart;
	void Start(){
		StartCoroutine(RandomSpawn());
		for(int i=0;i<7;i++)
			Instantiate(fence,new Vector2(-5.04f+(1.7f*i),-5),Quaternion.identity).tag="Fence";
	}
	private IEnumerator RandomSpawn(){
		while(true){
			yield return new WaitForSeconds(Random.Range(1,maxSeconds));
			Instantiate(monster,randomPosition(),Quaternion.identity);
			if(monster_hit%10==0 && maxSeconds!=1 && monster_hit!=0)
				maxSeconds--;
		}
		yield return new WaitForSeconds(Random.Range(1,maxSeconds));
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
	public void monsterHit(){
		monster_hit++;
		monsterKilled.GetComponent<Text>().text="= "+monster_hit;
	}
	public void removeHeart(){
		heartObject[hearts-1].GetComponent<Image>().sprite=emptyHeart;
		StartCoroutine(Flash(heartObject[hearts-1]));
		hearts--;
		if(hearts==0){
			Time.timeScale=0;
			if(monster_hit>PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore",monster_hit);
				gameOverPopup.transform.GetChild(0).GetComponent<Text>().text="NEW HIGHSCORE!";
			}
         		
			gameOverPopup.SetActive(true);
		}
	}
	public IEnumerator Flash(GameObject heartObject){
		for(int i=0;i<10;i++){
			yield return new WaitForSeconds(0.1f);
			heartObject.SetActive(!heartObject.activeSelf);
		}
	}
	public void activateSpecial(){
		ray.GetComponent<RayBehaviour>().setActive(true);
	}
}