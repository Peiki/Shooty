using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DBSearch:MonoBehaviour{
	[SerializeField] GameObject loading;
	[SerializeField] Sprite[] sprites;
	[SerializeField] Sprite userImage;
	[SerializeField] GameObject grid;
	[SerializeField] GameObject inputField;
	[SerializeField] GameObject notFound;
	bool connection=false;
	string URL="https://shooty.000webhostapp.com/searchName.php?";
	string URL2="https://shooty.000webhostapp.com/checkFollowed.php?";
	IEnumerator GetFollowed(string name){
        string post_url=URL+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        connection=true;
        loading.SetActive(false);
        string[] substrings=hs_get.text.Split(';');
        int j=0;
        for(int i=1;j<substrings.Length-1;i=i+2){
            grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text=substrings[j];
            grid.transform.GetChild(i-1).GetChild(1).GetComponent<Image>().sprite=userImage;
            string follower=grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text;
            //if(StartCoroutine(CheckFollowed(PlayerPrefs.GetString("name"),follower))==1)
           	grid.transform.GetChild(i).gameObject.SetActive(true);
            j++;
        }
        if(substrings.Length==1)
       		notFound.gameObject.SetActive(true);
    }
    /*IEnumerator CheckFollowed(string follower,string followed){
    	string post_url=URL2+"follower="+follower+"&followed="+followed;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        connection=true;
        loading.SetActive(false);
        string[] substrings=hs_get.text.Split(';');
        int j=0;
        for(int i=1;j<substrings.Length-1;i=i+2){
            grid.transform.GetChild(i).gameObject.SetActive(true);
            grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text=substrings[j];
            grid.transform.GetChild(i-1).GetChild(1).GetComponent<Image>().sprite=userImage;
            j++;
        }
        if(substrings.Length==1)
       		notFound.gameObject.SetActive(true);
    }*/
    public void emptyGrid(){
    	for(int i=1;i<14;i=i+2){
    		grid.transform.GetChild(i).gameObject.SetActive(false);
            grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text="";
            grid.transform.GetChild(i-1).GetChild(1).GetComponent<Image>().sprite=null;
    	}
    }
	public void searchName(){
		loading.gameObject.SetActive(true);
		notFound.gameObject.SetActive(false);
		emptyGrid();
		StartCoroutine(Animation());
		StartCoroutine(GetFollowed(inputField.GetComponent<Text>().text));
	}
	private IEnumerator Animation(){
        while(loading.activeSelf)
        	for(int i=0;i<8;i++){
                loading.GetComponent<Image>().sprite=sprites[i];
                yield return new WaitForSeconds(0.05f);
            }
    }
}