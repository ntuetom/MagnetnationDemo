using UnityEngine;
using System.Collections;

public class ChagePos : MonoBehaviour {

	public Vector3 StartCompass;
	public Vector3 ChageCompass;
	public AudioClip[]  atu=new AudioClip[3];
	float Tm;
	bool x=false;
	bool booltest=false;

	// Use this for initialization
	void Start () {

		StartCompass = Input.compass.rawVector;

	}
	void OnEnable(){

		Input.location.Start();
		Input.compass.enabled = true;

	}
	// Update is called once per frame
	void Update () {

		//if( booltest ){ 
			ChageCompass = Input.compass.rawVector-StartCompass;
			Tm=Tm+Time.deltaTime*10;
			if(Tm>4){ 
				

				x=true;
			}
			if(x){
				//guiText.text = ( ChageCompass.x.ToString("f1") +" , "+ ChageCompass.y.ToString("f1")+" , "+ ChageCompass.z.ToString("f1"));
				StartCompass=Input.compass.rawVector;
				x=false;

			}
			if(Tm>20){ 
				booltest=false;
				Tm=0;
			}
			move();
		//}
	}
	void move(){


		//	if(Input.GetMouseButtonDown(0)){
		if (ChageCompass.x> 100){
			if( ChageCompass.z>200){
				//one  _x>0 _Z>0   
				audio.Stop();
				audio.PlayOneShot(atu[0]);
				transform.position=new Vector3(30,28,0);
			}
		}
		//	if(Input.GetMouseButtonDown(1)){
		if (ChageCompass.y > 60 ) {
			if( ChageCompass.z < 180 ){
				//sec _y _z
				audio.Stop();
				audio.PlayOneShot(atu[1]);
				transform.position=new Vector3(-3,60,0);
			}
			
		}
		//	if(Input.GetMouseButtonDown(2)){
		//if ((ChageCompass.x>-40 && ChageCompass.x< -25)  && ChageCompass.z > 60) {
		if ( ChageCompass.x<-5 && ChageCompass.x> -15 ){	
			if(ChageCompass.z>0 &&ChageCompass.z<90 ){
				//third _x<0  _z>0
				audio.Stop();
				audio.PlayOneShot(atu[2]);
				transform.position=new Vector3(-36,28,0);
			}
			
		}


	}


}
