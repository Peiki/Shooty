using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneController:MonoBehaviour{
	int monster_hit=0;
	int score=0;
	int hearts=3;
	int maxSeconds=6;
	int range=21;
	bool status=false;
	bool levelUp=false;
	bool incremented=false;
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
	[SerializeField] GameObject weapon;
	[SerializeField] GameObject countdownImage;
	[SerializeField] GameObject background;
	[SerializeField] GameObject nextLevel;
	[SerializeField] GameObject scoreText;
	[SerializeField] GameObject nextBackground;
	[SerializeField] GameObject[] heartObject;
	[SerializeField] Button exitButton;
	[SerializeField] Sprite emptyHeart;
	[SerializeField] Sprite fullHeart;
	[SerializeField] Sprite invisible;
	[SerializeField] Sprite background_desert;
	[SerializeField] Sprite[] weaponsImage;
	[SerializeField] Sprite[] countdown;
	[SerializeField] AudioClip gameOverSound;
	[SerializeField] AudioClip heartLossSound;
	[SerializeField] AudioClip levelUpSound;
	void Start(){
		for(int i=0;i<3;i++){
			if(PlayerPrefs.GetInt("weapon"+(i+1))==2)
				weapon.GetComponent<SpriteRenderer>().sprite=weaponsImage[i];
		}
		if(PlayerPrefs.GetInt("check1")==1){
			playMusic();
			GetComponent<AudioSource>().loop=true;
		}
		exitButton.interactable=false;
		scoreText.GetComponent<Text>().text="SCORE:\n"+score;
		for(int i=0;i<7;i++)
			Instantiate(fence,new Vector3(-5.04f+(1.7f*i),-5,-1),Quaternion.identity).tag="Fence";
		StartCoroutine(Countdown(3));
	}
	private IEnumerator RandomSpawn(){
		status=true;
		exitButton.interactable=true;
		while(true){
			yield return new WaitForSeconds(Random.Range(1,maxSeconds));
			RandomInstantiate();
			if(monster_hit>=20 && !levelUp){  //switch minimum
				stopMusic();
				playLevelUpSound();
				levelUp=true;
				changeArea();
				break;
			}
			if(monster_hit%10==0 && maxSeconds!=1 && monster_hit!=0 && !incremented){
				incremented=true;
				maxSeconds--;
			}
			else if(!(monster_hit%10==0))
				incremented=false;
		}
	}
	private IEnumerator Countdown(int count){
		if(count!=0){
			countdownImage.GetComponent<Image>().sprite=countdown[count];
			countdownImage.GetComponent<GetSmaller>().resetScale();
			yield return new WaitForSeconds(1);
		}
		if(count==0){
			countdownImage.SetActive(false);
			StartCoroutine(RandomSpawn());
		}
		else
			StartCoroutine(Countdown(count-1));
	}
	void RandomInstantiate(){
		int randomValue=Random.Range(1,range);
		if(randomValue==20){
			Instantiate(box,randomPosition(),Quaternion.identity).GetComponent<MonsterBehaviour>().setMove();
			decreaseRange();
		}
		else if(randomValue>15 && randomValue<20)
			Instantiate(diagonalMonster,randomPosition(),Quaternion.identity).GetComponent<MonsterBehaviour>().setMove();
		else if(randomValue>13 && randomValue<16)
			Instantiate(hiddenMonster,randomPosition(),Quaternion.identity).GetComponent<MonsterBehaviour>().setMove();
		else if(randomValue>10 && randomValue<14)
			Instantiate(fastMonster,randomPosition(),Quaternion.identity).GetComponent<MonsterBehaviour>().setMove();
		else if(randomValue==10)
			Instantiate(heavyMonster,randomPosition(),Quaternion.identity).GetComponent<MonsterBehaviour>().setMove();
		else
			Instantiate(monster,randomPosition(),Quaternion.identity).GetComponent<MonsterBehaviour>().setMove();
	}
	Vector3 randomPosition(){
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
	public void incrementScore(int amount){
		score+=amount;
		scoreText.GetComponent<Text>().text="SCORE:\n"+score;
	}
	public void removeHeart(){
		heartObject[hearts-1].GetComponent<Image>().sprite=emptyHeart;
		StartCoroutine(Flash(heartObject[hearts-1]));
		hearts--;
		playHeartLossSound();
		if(hearts==0){
			Time.timeScale=0;
			stopMusic();
			playGameOverSound();
			exitButton.interactable=false;
			if(score>PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore",score);
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
		if(position==100){
			nextLevel.gameObject.SetActive(false);
			countdownImage.SetActive(true);
			StartCoroutine(Countdown(3));
		}
	}
	public void decreaseRange(){
		range=range-1;
	}
	public void resetRange(){
		range=21;
	}
	public bool getStatus(){
		return status;
	}
	void playMusic(){
		GetComponent<AudioSource>().Play();
	}
	void stopMusic(){
		GetComponent<AudioSource>().Stop();
	}
	void playGameOverSound(){
		GetComponent<AudioSource>().PlayOneShot(gameOverSound);
	}
	void playHeartLossSound(){
		GetComponent<AudioSource>().PlayOneShot(heartLossSound);
	}
	void playLevelUpSound(){
		GetComponent<AudioSource>().PlayOneShot(levelUpSound);
	}
	void changeArea(){
		exitButton.interactable=false;
		nextBackground.SetActive(true);
		StartCoroutine(Timer(5,100));
		nextLevel.gameObject.SetActive(true);
	}
}