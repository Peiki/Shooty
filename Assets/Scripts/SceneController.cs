using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneController:MonoBehaviour{
	int monster_hit=0;
	int hearts=3;
	int maxSeconds=6;
	int range=21;
	bool status=false;
	[SerializeField] GameObject monster;
	[SerializeField] GameObject heavyMonster;
	[SerializeField] GameObject fastMonster;
	[SerializeField] GameObject hiddenMonster;
	[SerializeField] GameObject diagonalMonster;
	[SerializeField] GameObject box;
	[SerializeField] GameObject fence;
	[SerializeField] GameObject ray;
	[SerializeField] GameObject gameOverPopup;
	[SerializeField] GameObject monsterKilled;
	[SerializeField] GameObject shoot;
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject countdownImage;
	[SerializeField] GameObject[] heartObject;
	[SerializeField] Button exitButton;
	[SerializeField] Sprite emptyHeart;
	[SerializeField] Sprite fullHeart;
	[SerializeField] Sprite invisible;
	[SerializeField] Sprite[] countdown;
	void Start(){
		exitButton.interactable=false;
		for(int i=0;i<7;i++)
			Instantiate(fence,new Vector2(-5.04f+(1.7f*i),-5),Quaternion.identity).tag="Fence";
		StartCoroutine(Countdown(3));
	}
	private IEnumerator RandomSpawn(){
		status=true;
		exitButton.interactable=true;
		while(true){
			yield return new WaitForSeconds(Random.Range(1,maxSeconds));
			RandomInstantiate();
			if(monster_hit%10==0 && maxSeconds!=1 && monster_hit!=0)
				maxSeconds--;
		}
	}
	private IEnumerator Countdown(int count){
		if(count!=0){
			countdownImage.GetComponent<Image>().sprite=countdown[count];
			countdownImage.GetComponent<GetSmaller>().resetScale();
			yield return new WaitForSeconds(1);
		}
		if(count==0){
			Destroy(countdownImage.GetComponent<GetSmaller>());
			Destroy(countdownImage);
			StartCoroutine(RandomSpawn());
		}
		else
			StartCoroutine(Countdown(count-1));
	}
	void RandomInstantiate(){
		int randomValue=Random.Range(1,range);
		if(randomValue==20){
			Instantiate(box,randomPosition(),Quaternion.identity);
			range=range-1;
		}
		else if(randomValue>15 && randomValue<20)
			Instantiate(diagonalMonster,randomPosition(),Quaternion.identity);
		else if(randomValue>13 && randomValue<16)
			Instantiate(hiddenMonster,randomPosition(),Quaternion.identity);
		else if(randomValue>10 && randomValue<14)
			Instantiate(fastMonster,randomPosition(),Quaternion.identity);
		else if(randomValue==10)
			Instantiate(heavyMonster,randomPosition(),Quaternion.identity);
		else
			Instantiate(monster,randomPosition(),Quaternion.identity);
	}
	Vector2 randomPosition(){
		int number=Random.Range(1,6);
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
			exitButton.interactable=false;
			if(monster_hit>PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore",monster_hit);
				GetComponent<DBConnect>().startPostScores("updatescore.php?");
				gameOverPopup.transform.GetChild(0).GetComponent<Text>().text="NEW HIGHSCORE!\n";
			}
			gameOverPopup.SetActive(true);
		}
	}
	public void addHeart(){
		if(hearts<3){
			heartObject[hearts].GetComponent<Image>().sprite=fullHeart;
			StartCoroutine(Flash(heartObject[hearts]));
			hearts++;
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
	public void startTimer(int time,int position){
		StartCoroutine(Timer(time,position));
	}
	public IEnumerator Timer(int time,int position){
		yield return new WaitForSeconds(time);
		if(position==2)
			shoot.GetComponent<SB_Listener>().setFireRate(0.4f);
		else if(position==3)
			bullet.GetComponent<BulletScript>().setDamage(1);
		yield return new WaitForSeconds(time);
	}
	public void resetRange(){
		range=range+1;
	}
	public bool getStatus(){
		return status;
	}
}