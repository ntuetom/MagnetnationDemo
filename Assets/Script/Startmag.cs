using UnityEngine;
using System.Collections;

public class Startmag : MonoBehaviour {
	public Vector3 StartCompass;
	// Use this for initialization
	void Start () {
		StartCompass = Input.compass.rawVector;
	}
	void OnEnable(){
		Input.location.Start();
		Input.compass.enabled = true;
		StartCompass = Input.compass.rawVector;
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		
		guiText.text = ( StartCompass.x.ToString("f1") +" , "+ 
		                StartCompass.y.ToString("f1")+" , "+ 
		                StartCompass.z.ToString("f1"));
		
	}
}
