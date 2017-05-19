using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DBBugReport:MonoBehaviour{
	[SerializeField] GameObject title;
	[SerializeField] GameObject description;
	[SerializeField] GameObject popup;
	bool emptyFields=true;
	public string URL="http://shootygame.altervista.org/sendReport.php?";
	IEnumerator SendReport(string name,string title,string description){
        string post_url=URL+"name="+name+"&title="+title+"&description="+description;
        WWW hs_post=new WWW(post_url);
        yield return hs_post;
        if(hs_post.error!=null)
            Debug.Log("There was an error posting the high score: "+hs_post.error);
    }
	public void openPopup(){
		if(title.GetComponent<Text>().text=="")
			popup.transform.GetChild(0).GetComponent<Text>().text="Title is missing";
		else if(description.GetComponent<Text>().text=="")
			popup.transform.GetChild(0).GetComponent<Text>().text="Description is missing";
		else{
			popup.transform.GetChild(0).GetComponent<Text>().text="Thank you for your submit!";
			emptyFields=false;
			StartCoroutine(SendReport(PlayerPrefs.GetString("name"),title.GetComponent<Text>().text,description.GetComponent<Text>().text));
		}
		popup.SetActive(true);
	}
	public void resetFields(){
		if(!emptyFields)
			SceneManager.LoadScene("Menu",LoadSceneMode.Single);
	}
}