using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DBGetUser:MonoBehaviour{
	[SerializeField] GameObject userPopup;
	[SerializeField] GameObject loading;
    [SerializeField] GameObject grid;
    [SerializeField] GameObject grid2;
    [SerializeField] GameObject searchPopup;
    [SerializeField] Button addButton;
    [SerializeField] Sprite userImage;
    [SerializeField] Sprite[] sprites;
    string URL="http://shootygame.altervista.org/displayYours.php?";
   	string URL_2="http://shootygame.altervista.org/addFriend.php?";
   	string URL_3="http://shootygame.altervista.org/displayRank.php?";
   	string URL_4="http://shootygame.altervista.org/checkFollowed.php?";
   	string URL_5="http://shootygame.altervista.org/removeFriend.php?";
    string username;
    bool friend;
    bool connection=false;
	public void openPopup(){
		userPopup.transform.GetChild(0).GetComponent<Image>().sprite=null;
        userPopup.transform.GetChild(1).GetComponent<Text>().text="";
        userPopup.transform.GetChild(2).GetComponent<Text>().text="";
        userPopup.transform.GetChild(3).GetComponent<Text>().text="";
        connection=false;
        loading.SetActive(true);
        addButton.interactable=false;
		userPopup.gameObject.SetActive(true);
	}
	public void setUsername(int position){
        if(searchPopup.gameObject.activeSelf==false)
	       username=grid.transform.GetChild(position).GetComponent<Text>().text;
        else
           username=grid2.transform.GetChild(position).GetChild(0).GetComponent<Text>().text;
		StartCoroutine(GetUser(username));
		StartCoroutine(Animation());
		StartCoroutine(CheckFollowed());
	}
	public void addFriend(){
		if(friend)
			StartCoroutine(RemoveFriend());
		else
			StartCoroutine(AddFriend());
	}
	private IEnumerator GetUser(string name){
		string post_url=URL+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        int score=int.Parse(hs_get.text);
        post_url=URL_3+"score="+score;
        hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        connection=true;
        loading.SetActive(false);
        userPopup.transform.GetChild(2).GetComponent<Text>().text="Position: "+hs_get.text;
        userPopup.transform.GetChild(0).GetComponent<Image>().sprite=userImage;
        userPopup.transform.GetChild(1).GetComponent<Text>().text=username;
        userPopup.transform.GetChild(3).GetComponent<Text>().text="Highscore: "+score;
	}
	private IEnumerator AddFriend(){
		changeButton(false);
		string post_url=URL_2+"follower="+PlayerPrefs.GetString("name")+"&followed="+username;
		WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
	}
	private IEnumerator RemoveFriend(){
		changeButton(true);
		string post_url=URL_5+"follower="+PlayerPrefs.GetString("name")+"&followed="+username;
		WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
	}
	private IEnumerator CheckFollowed(){
		addButton.interactable=false;
		string post_url=URL_4+"follower="+PlayerPrefs.GetString("name")+"&followed="+username;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        addButton.interactable=true;
        if(username==PlayerPrefs.GetString("name")){
            changeButton(true);
        	addButton.interactable=false;
        }
        else if(int.Parse(hs_get.text)==0)
            changeButton(true);
        else
            changeButton(false);
	}
	void changeButton(bool value){
		var colors=addButton.colors;
		if(value){
			colors.normalColor=Color.black;
            colors.highlightedColor=Color.black;
        	addButton.transform.GetChild(0).gameObject.GetComponent<Text>().text="Add Friend";
        	friend=false;
		}
		else{
			colors.normalColor=Color.red;
            colors.highlightedColor=Color.red;
        	addButton.transform.GetChild(0).gameObject.GetComponent<Text>().text="Remove";
        	friend=true;
		}
		addButton.colors=colors;
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
            userPopup.transform.GetChild(2).GetComponent<Text>().text="ERROR!";
        }
    }
}