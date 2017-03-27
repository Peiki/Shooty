using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ProgressBar:MonoBehaviour{
	[SerializeField] Sprite red;
	[SerializeField] Sprite green;
	[SerializeField] GameObject specialButton;
    [SerializeField] GameObject ray;
    [SerializeField] GameObject shoot;
	bool canCharge=true;
    void Start(){
        GetComponent<Image>().fillAmount=0f;
    }
    public void fillAmount(float amount){
        if(GetComponent<Image>().fillAmount!=1 && canCharge)
            StartCoroutine(Load());
    }
    public void activateSpecial(){
    	GetComponent<Image>().sprite=red;
    	StartCoroutine(Unload());
    }
    private IEnumerator Unload(){
    	canCharge=false;
    	while(GetComponent<Image>().fillAmount!=0){
    		yield return new WaitForSeconds(0.02f);
    		GetComponent<Image>().fillAmount=GetComponent<Image>().fillAmount-0.01f;
    	}
    	canCharge=true;
        ray.GetComponent<RayBehaviour>().setActive(false);
        shoot.GetComponent<SB_Listener>().setShoot(true);
    }
    private IEnumerator Load(){
    	float startValue=GetComponent<Image>().fillAmount;
    	for(int i=0;i<10;i++){
    		yield return new WaitForSeconds(0.01f);
    		GetComponent<Image>().fillAmount=GetComponent<Image>().fillAmount+0.01f;
    	}
    	if(GetComponent<Image>().fillAmount>0.99f){
        	GetComponent<Image>().sprite=green;
        	specialButton.GetComponent<SpecialListener>().setInteractable(true);
        }
    }
}