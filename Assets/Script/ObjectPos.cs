using UnityEngine;
using System.Collections;

public class ObjectPos : MonoBehaviour {
	

	public Vector3 ChageCompass;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	      ChageCompass = Input.compass.rawVector;
	      
	}
	void OnGUI() {
		
		
	    	guiText.text = (
                Magmusic.StartCompass.x.ToString("f1") + " , " +
                Magmusic.StartCompass.y.ToString("f1") + " , " +
                Magmusic.StartCompass.z.ToString("f1"));
		   
		
		
	}
}
