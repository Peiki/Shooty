using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
public class DBGet:MonoBehaviour{
    [SerializeField] GameObject loading;
    [SerializeField] GameObject grid;
    [SerializeField] Sprite[] sprites;
    string URL="http://shootygame.altervista.org/display.php";
    string URL_2="http://shootygame.altervista.org/displayYours.php?";
    string URL_3="http://shootygame.altervista.org/displayRank.php?";
    bool connection=false;
	void Start(){
        StartCoroutine(Animation());
        StartCoroutine(Timer());
        StartCoroutine(GetScores());
        StartCoroutine(GetYourScore(PlayerPrefs.GetString("name")));
        StartCoroutine(GetYourRank(PlayerPrefs.GetInt("highscore")));
	}
	IEnumerator GetScores(){
        WWW hs_get=new WWW(URL);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        loading.SetActive(false);
        connection=true;
        string[] substrings=hs_get.text.Split(';');
        int j=1;
        int h=0;
        for(int i=0;i<30;i++){
            if(h<substrings.Length-1){
                if(i==0 || i-3*(j-1)==0){
                    grid.transform.GetChild(i).GetChild(0).GetComponent<Text>().text=j+".";
                    j++;
                }
                else{ 
                    grid.transform.GetChild(i).GetChild(0).GetComponent<Text>().text=substrings[h];
                    if(PlayerPrefs.GetString("name")==substrings[h]){
                        grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().color=Color.red;
                        grid.transform.GetChild(i-1).GetChild(0).GetComponent<Outline>().effectColor=Color.red;
                        grid.transform.GetChild(i).GetChild(0).GetComponent<Text>().color=Color.red;
                        grid.transform.GetChild(i+1).GetChild(0).GetComponent<Text>().color=Color.red;
                        grid.transform.GetChild(i+1).GetChild(0).GetComponent<Outline>().effectColor=Color.red;
                    }
                    h++;
                }
            }   
        }
    }
    IEnumerator GetYourScore(string name){
        string post_url=URL_2+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        transform.GetChild(1).GetChild(2).GetComponent<Text>().text+=hs_get.text;
    }
    IEnumerator GetYourRank(int score){
        string post_url=URL_3+"score="+score;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        transform.GetChild(1).GetChild(3).GetComponent<Text>().text+=hs_get.text;
    }
    private IEnumerator Animation(){
        while(loading.activeSelf)
            for(int i=0;i<8;i++){   
                loading.GetComponent<Image>().sprite=sprites[i];
                yield return new WaitForSeconds(0.05f);
            }
    }
    private IEnumerator Timer(){
        yield return new WaitForSeconds(5);
        if(!connection){
            loading.SetActive(false);
            transform.GetChild(2).GetChild(1).GetComponent<Text>().text="ERROR WITH THE CONNECTION!";
        }
    }
}