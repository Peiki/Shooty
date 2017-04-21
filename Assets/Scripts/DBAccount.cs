using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DBAccount:MonoBehaviour{
    [SerializeField] GameObject loading;
    [SerializeField] GameObject loading2;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite userImage;
    [SerializeField] GameObject accountScreen;
    [SerializeField] GameObject searchUserPopup;
    [SerializeField] GameObject grid;
    string URL_2="https://shooty.000webhostapp.com/displayYours.php?";
    string URL_3="https://shooty.000webhostapp.com/displayRank.php?";
    string URL_4="https://shooty.000webhostapp.com/countFollowers.php?";
    string URL_5="https://shooty.000webhostapp.com/getFollowed.php?";
    bool connection=false;
	void Start(){
		StartCoroutine(Animation());
        StartCoroutine(Timer());
        StartCoroutine(GetYourScore(PlayerPrefs.GetString("name")));
        StartCoroutine(GetFollowers(PlayerPrefs.GetString("name")));
        StartCoroutine(GetFollowed(PlayerPrefs.GetString("name")));
        StartCoroutine(GetYourRank(PlayerPrefs.GetInt("highscore")));
	}
	IEnumerator GetYourScore(string name){
        string post_url=URL_2+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        connection=true;
        loading.SetActive(false);
        accountScreen.transform.GetChild(3).GetComponent<Text>().text=PlayerPrefs.GetString("name");
        accountScreen.transform.GetChild(0).GetComponent<Image>().sprite=userImage;
        accountScreen.transform.GetChild(2).GetComponent<Text>().text="Highscore: "+hs_get.text;
    }
    IEnumerator GetYourRank(int score){
        string post_url=URL_3+"score="+score;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        connection=true;
        accountScreen.transform.GetChild(1).GetComponent<Text>().text="Position: "+hs_get.text;
    }
    IEnumerator GetFollowers(string name){
        string post_url=URL_4+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        connection=true;
        accountScreen.transform.GetChild(4).GetComponent<Text>().text="Followers: "+hs_get.text;
    }
    IEnumerator GetFollowed(string name){
        string post_url=URL_5+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        connection=true;
        loading2.SetActive(false);
        string[] substrings=hs_get.text.Split(';');
        int j=0;
        clear();
        for(int i=1;j<substrings.Length-1;i=i+2){
            grid.transform.GetChild(i).GetComponent<Text>().text=substrings[j];
            grid.transform.GetChild(i-1).GetChild(0).gameObject.SetActive(true);
            grid.transform.GetChild(i-1).GetChild(0).GetComponent<Image>().sprite=userImage;
            grid.transform.GetChild(i-1).GetChild(0).gameObject.AddComponent<Outline>();
            j++;
        }
    }
    private IEnumerator Animation(){
        while(loading.activeSelf)
            for(int i=0;i<8;i++){   
                loading.GetComponent<Image>().sprite=sprites[i];
                yield return new WaitForSeconds(0.05f);
            }
    }
    private IEnumerator Animation2(){
        while(loading2.activeSelf)
            for(int i=0;i<8;i++){
                loading2.GetComponent<Image>().sprite=sprites[i];
                yield return new WaitForSeconds(0.05f);
            }
    }
    private IEnumerator Timer(){
        yield return new WaitForSeconds(5);
        if(!connection){
            loading.SetActive(false);
            accountScreen.transform.GetChild(1).GetComponent<Text>().text="ERROR!";
        }
    }
    void clear(){
        for(int i=1;i<20;i=i+2){    
            grid.transform.GetChild(i-1).GetChild(0).gameObject.SetActive(false);
            grid.transform.GetChild(i).GetComponent<Text>().text="";
            Destroy(grid.transform.GetChild(i-1).GetChild(0).gameObject.GetComponent<Outline>());
        }
    }
    void resetLoading(){
        loading2.SetActive(true);
        StartCoroutine(Animation2());
    }
    public void startGetFollowed(){
        if(searchUserPopup.activeSelf)
            searchUserPopup.GetComponent<DBSearch>().searchName();
        else{
            clear();
            resetLoading();
            StartCoroutine(GetFollowed(PlayerPrefs.GetString("name")));
        }
    }
}