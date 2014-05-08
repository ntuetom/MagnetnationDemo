using UnityEngine;
using System.Collections;

public class tt : MonoBehaviour {
	//public Vector3 StartCompass;
	//public Vector3 CompassChange;
	//bool x=true;
	// Use this for initialization
	
	public Vector3 StartCompass;
    public Vector3 ChageCompass;
	static public Vector3 ChageCompass2;


	static public Vector3 Rt;
	float Tm;
	bool x=false;
	void Start () {
		
			StartCompass = Input.compass.rawVector;
	}
	void OnEnable(){
		Input.location.Start();
		Input.compass.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		
		
		ChageCompass = Input.compass.rawVector-StartCompass;
		ChageCompass2 = ChageCompass;
		Tm=Tm+Time.deltaTime*10;

		if(Tm>10){ 
			
			Tm=0;
			x=true;
		}
	
	}
	void OnGUI() { 
		
		if(x){
	    	guiText.text = ( ChageCompass.x.ToString("f1") +" , "+ ChageCompass.y.ToString("f1")+" , "+ ChageCompass.z.ToString("f1"));
		   	StartCompass=Input.compass.rawVector;
			x=false;
		}
		
	}
	
}
		
		
		
	/*	
		Tm=Tm+Time.deltaTime*10;
	    if(Tm>1){ 
			ChageCompass = Input.compass.rawVector-StartCompass;
			x=true;
		 	StartCompass=Input.compass.rawVector;
			Tm=0;
		}
	
		
	}
	 void OnGUI() {
		    
		    guiText.text = ( tt2.ChageCompass.x.ToString("f1") +" , "+ ChageCompass.y.ToString("f1")+" , "+ ChageCompass.z.ToString("f1"));
   
		
		 GUILayout.Label("Magnetometer reading: " + Input.compass.rawVector.ToString());
      	guiText.text = ( Input.compass.magneticHeading.x.ToString("f1") +" , "+ Input.compass.magneticHeading.y.ToString("f1"));
		
    }*/

