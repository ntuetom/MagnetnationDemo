using UnityEngine;
using System.Collections;

public class tt2 : MonoBehaviour {
	
    public Vector3 StartCompass;
    public Vector3 ChageCompass;
	bool x=false;
	float Tm;
	// Use this for initialization
	void Start () {
		StartCompass = Input.compass.rawVector;
	} 
	
	// Update is called once per frame
	void Update () {
	//	if(x){
	//		StartCompass = Input.compass.rawVector;
	//		x=false;
	//	}
			ChageCompass = Input.compass.rawVector-StartCompass;
	
		Tm=Tm+Time.deltaTime*10;
	
		if(Tm>10){ 
			
		//	x=true;
		 	StartCompass=Input.compass.rawVector;
		//	print(Tm);
			Tm=0;
		}
	
	}
	 void OnGUI() {
		
		guiText.text = ( ChageCompass.x.ToString("f1") +" , "+ ChageCompass.y.ToString("f1")+" , "+ ChageCompass.z.ToString("f1"));
   
	}
	
}
