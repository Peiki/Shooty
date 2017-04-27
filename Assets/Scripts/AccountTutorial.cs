using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AccountTutorial:MonoBehaviour{
	[SerializeField] GameObject panel;
	[SerializeField] GameObject fsButton;
	[SerializeField] GameObject tapText;
	[SerializeField] GameObject searchUserPopup;
	[SerializeField] GameObject inputFieldPlaceholder;
	int status=1;
	void Start(){
		//PlayerPrefs.SetInt("tut_Account",0);
		if(PlayerPrefs.GetInt("tut_Account")==1){
			panel.SetActive(false);
			fsButton.SetActive(false);
		}
	}
	public void next(){
		switch(status){
			case 1:
				panel.transform.GetChild(0).gameObject.SetActive(true);
				break;
			case 2:
				panel.transform.GetChild(0).gameObject.SetActive(false);
				panel.transform.GetChild(1).gameObject.SetActive(true);
				panel.transform.GetChild(2).gameObject.SetActive(true);
				break;
			case 3:
				panel.transform.GetChild(2).gameObject.SetActive(false);
				panel.transform.GetChild(3).gameObject.SetActive(true);
				break;
			case 4:
				tapText.SetActive(false);
				panel.transform.GetChild(3).gameObject.SetActive(false);
				panel.transform.GetChild(4).gameObject.SetActive(true);
				break;
			case 5:
				panel.transform.GetChild(1).gameObject.SetActive(false);
				panel.transform.GetChild(4).gameObject.SetActive(false);
				panel.transform.GetChild(5).gameObject.SetActive(true);
				GetComponent<AccountController>().changePosition(1);
				break;
			case 6:
				panel.transform.GetChild(5).gameObject.SetActive(false);
				panel.transform.GetChild(6).gameObject.SetActive(true);
				GetComponent<AccountController>().changeStatus();
				searchUserPopup.GetComponent<PopupScript>().Activate();
				break;
			case 7:
				panel.transform.GetChild(6).gameObject.SetActive(false);
				panel.transform.GetChild(7).gameObject.SetActive(true);
				inputFieldPlaceholder.GetComponent<Text>().text="flat";
				break;
			case 8:
				panel.transform.GetChild(7).gameObject.SetActive(false);
				panel.transform.GetChild(8).gameObject.SetActive(true);
				panel.transform.GetChild(9).gameObject.SetActive(true);
				searchUserPopup.GetComponent<DBSearch>().searchName("flat");
				break;
			case 9:
				searchUserPopup.GetComponent<DBAddFriend>().SendFriend(0);
				StartCoroutine(Wait());
				break;
			case 10:
				StartCoroutine(Wait2());
				PlayerPrefs.SetInt("tut_Account",1);
				SceneManager.LoadScene("Account",LoadSceneMode.Single);
				break;
		}
		status++;
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds(0.5f);
		panel.transform.GetChild(8).gameObject.SetActive(false);
		panel.transform.GetChild(9).gameObject.SetActive(false);
		panel.transform.GetChild(10).gameObject.SetActive(true);
		panel.transform.GetChild(11).gameObject.SetActive(true);
		GetComponent<DBGetUser>().openPopup();
		GetComponent<DBGetUser>().setUsername(0);
	}
	IEnumerator Wait2(){
		yield return new WaitForSeconds(0.5f);
		GetComponent<DBGetUser>().setFriend(true);
		GetComponent<DBGetUser>().setFriendName("flat");
		GetComponent<DBGetUser>().addFriend();
	}
}