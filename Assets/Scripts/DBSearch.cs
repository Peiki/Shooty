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
    [SerializeField] Button searchButton;
    [SerializeField] Button exitButton;
	string URL="https://shooty.000webhostapp.com/searchName.php?";
	string URL2="https://shooty.000webhostapp.com/checkFollowed.php?";
	IEnumerator GetFollowed(string name){
        string post_url=URL+"name="+name;
        WWW hs_get=new WWW(post_url);
        yield return hs_get;
        if(hs_get.error!=null)
            print("There was an error getting the high score: "+hs_get.error);
        loading.SetActive(false);
        string[] substrings=hs_get.text.Split(';');
        int j=0;
        for(int i=1;j<substrings.Length-1;i=i+2){
            grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text=substrings[j];
            grid.transform.GetChild(i-1).GetChild(1).GetChild(0).GetComponent<Image>().sprite=userImage;
            grid.transform.GetChild(i-1).GetChild(1).GetChild(0).gameObject.AddComponent<Outline>();
            grid.transform.GetChild(i-1).GetChild(1).GetChild(0).gameObject.SetActive(true);
            string followed=grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text;
            post_url=URL2+"follower="+PlayerPrefs.GetString("name")+"&followed="+followed;
            hs_get=new WWW(post_url);
            yield return hs_get;
            grid.transform.GetChild(i).gameObject.SetActive(true);
            if(int.Parse(hs_get.text)==1 || followed==PlayerPrefs.GetString("name"))
                grid.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Button>().interactable=false;
            j++;
        }
        if(substrings.Length==1)
       		notFound.gameObject.SetActive(true);
        searchButton.interactable=true;
        exitButton.interactable=true;
    }
    public void emptyGrid(){
    	for(int i=1;i<14;i=i+2){
    		grid.transform.GetChild(i).gameObject.SetActive(false);
            grid.transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text="";
            grid.transform.GetChild(i-1).GetChild(1).GetChild(0).GetComponent<Image>().sprite=null;
            Destroy(grid.transform.GetChild(i-1).GetChild(1).GetChild(0).gameObject.GetComponent<Outline>());
            grid.transform.GetChild(i-1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            grid.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Button>().interactable=true;
    	}
    }
	public void searchName(string name){
        searchButton.interactable=false;
        exitButton.interactable=false;
		loading.gameObject.SetActive(true);
		notFound.gameObject.SetActive(false);
		emptyGrid();
		StartCoroutine(Animation());
        if(name=="")
		  StartCoroutine(GetFollowed(inputField.GetComponent<Text>().text));
        else
            StartCoroutine(GetFollowed(name));
	}
	private IEnumerator Animation(){
        while(loading.activeSelf)
        	for(int i=0;i<8;i++){
                loading.GetComponent<Image>().sprite=sprites[i];
                yield return new WaitForSeconds(0.05f);
            }
    }
}