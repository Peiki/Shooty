using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DBGet:MonoBehaviour{
    public string URL="https://shooty.000webhostapp.com/display.php";
    public string URL_2="https://shooty.000webhostapp.com/displayYours.php?";
	void Start(){
		StartCoroutine(GetScores());
        StartCoroutine(GetYourScore(PlayerPrefs.GetString("name")));
	}
	IEnumerator GetScores(){
        WWW hs_get=new WWW(URL);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error); //error message here
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text=hs_get.text;
    }
    IEnumerator GetYourScore(string name){
        string post_url=URL_2+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error); //error message here
        transform.GetChild(2).GetChild(2).GetComponent<Text>().text+=hs_get.text;
    }
}