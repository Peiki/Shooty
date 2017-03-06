using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateListener:MonoBehaviour{
	bool left_down=false,right_down=false;
	public void SetLD(){
		left_down=!left_down;
	}
	public void SetRD(){
		right_down=!right_down;
	}
	public void Update(){
		if(left_down && (transform.eulerAngles.z<70 || transform.eulerAngles.z>280))
			transform.Rotate(Vector3.forward*2*90*Time.deltaTime);
		else if(right_down && (transform.eulerAngles.z>290 || transform.eulerAngles.z<80))
			transform.Rotate(Vector3.forward*2*-90*Time.deltaTime);
	}
}