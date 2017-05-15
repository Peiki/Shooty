using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DBAddFriend:MonoBehaviour{
	[SerializeField] GameObject grid;
	string URL="http://shootygame.altervista.org/addFriend.php?";
	public void SendFriend(int position){
		string followed=grid.transform.GetChild(position).GetChild(0).GetComponent<Text>().text;
		StartCoroutine(AddFriend(position,PlayerPrefs.GetString("name"),followed));
	}
	IEnumerator AddFriend(int position,string follower,string followed){
		grid.transform.GetChild(position+1).GetChild(0).gameObject.GetComponent<Button>().interactable=false;
		string post_url=URL+"follower="+follower+"&followed="+followed;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
	}
}