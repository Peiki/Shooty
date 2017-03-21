using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class DBConnect:MonoBehaviour{
    [SerializeField] GameObject message;
    [SerializeField] GameObject nameField;
    private string secretKey="E5NsPUVa";
    public string LINK="https://shooty.000webhostapp.com/";
    bool value;
    void Start(){
        Scene scene=SceneManager.GetActiveScene();
        if(scene.name=="Menu")
            value=true;
        else
            value=false;
    }
    IEnumerator PostScores(string url,string name, int score){
        string post_url=LINK+url+"name="+WWW.EscapeURL(name)+"&score="+score+"&secretKey="+WWW.EscapeURL(secretKey);
        Debug.Log(post_url);
        WWW hs_post=new WWW(post_url);
        yield return hs_post;
        Debug.Log(hs_post.text);
        if(hs_post.error!=null)
            Debug.Log("There was an error posting the high score: "+hs_post.error); //error message here
        else if(int.Parse(hs_post.text)==0){
            GetComponent<SetName>().setName();
            GetComponent<MenuListener>().ClosePopup();
            StartCoroutine(PostScores("addscore.php?",PlayerPrefs.GetString("name"),PlayerPrefs.GetInt("highscore")));
        }
        else if(int.Parse(hs_post.text)==1)
            message.GetComponent<Text>().text="Username già utilizzato!";
        Debug.Log("HERE");
    }
    public void startPostScores(string url){
        if(value && nameField.GetComponent<Text>().text!="")
            StartCoroutine(PostScores(url,nameField.GetComponent<Text>().text,PlayerPrefs.GetInt("highscore")));
        else if(value==false)
            StartCoroutine(PostScores(url,PlayerPrefs.GetString("name"),PlayerPrefs.GetInt("highscore")));
    }
}