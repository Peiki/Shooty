using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ProgressBar:MonoBehaviour{
    void Start(){
        GetComponent<Image>().fillAmount=0;
    }
    public void fillAmount(float amount){
        if(GetComponent<Image>().fillAmount!=1)
            GetComponent<Image>().fillAmount+=amount;
    }
}