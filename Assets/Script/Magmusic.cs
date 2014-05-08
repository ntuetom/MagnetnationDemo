using UnityEngine;
using System.Collections;

public class Magmusic : MonoBehaviour {
	public static Vector3 StartCompass;   //初始磁感應
	public Vector3 ChageCompass;   //當下磁感應
	public Vector3 OneCompass; 
	bool startgo=false;
	public AudioClip[]  aud=new AudioClip[3];
	// Use this for initialization
	void Start () { 
		// 取得預設 磁感應大小
		StartCompass = Input.compass.rawVector;
	}
	void OnEnable(){
		//取得電子羅盤裝置, 才能偵測磁感應
		Input.location.Start();
		Input.compass.enabled = true;
		StartCompass = Input.compass.rawVector;
  
	}
	// Update is called once per frame
	void Update () {

		if(startgo){


			ChageCompass = Input.compass.rawVector;

						//當下-初始的磁感應的變化量來判斷位置
			if( (ChageCompass.x-StartCompass.x)>10 || (ChageCompass.x-StartCompass.x)<-10 ){
                        if (!audio.isPlaying)
                        {
                            audio.clip = aud[0];
                            audio.Play();
                        }
						transform.position=new Vector3(30,28,0);
							
				
			} 
			 
		
			if( (ChageCompass.y-StartCompass.y)<-10 ){	

                    if (!audio.isPlaying)
                    {
                        audio.clip = aud[1];
                        audio.Play();
                    }
					transform.position=new Vector3(-3,60,0);
				
			}
            if ((ChageCompass.y - StartCompass.y) > 0 && (ChageCompass.x - StartCompass.x) < -5)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = aud[2];
                    audio.Play();
                }
                transform.position = new Vector3(-36, 28, 0);


            }

            //歸零
			if(  (ChageCompass.x-StartCompass.x)<10 && (ChageCompass.x-StartCompass.x)>-10){

                audio.Stop();
				transform.position=new Vector3(0,0,0);
				
			}
			




		}
	}
	void OnGUI() {
		
		if (GUI.Button(new Rect(10, 70, 120, 120), "Click")){
			startgo=true;
			//重新刷新 初始磁感應大小
			StartCompass = Input.compass.rawVector;
		}
		
	}
}
