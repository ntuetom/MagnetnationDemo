using UnityEngine;
using System.Collections;

public class Magmusic : MonoBehaviour {
	public static Vector3 deltaCompass;   //初始磁感應 
	public Vector3 ChageCompass;   //當下磁感應
	public Vector3 OneCompass;
    bool startgo = false;
    bool[] bplay = new bool[3]{true,true,true};
    public AudioClip[] aud;
    float felez, ftiger;
    Vector3[] V3temp;
	// Use this for initialization
	void Start () { 
		// 取得預設 磁感應大小
        deltaCompass = Vector3.zero;
  
	}
	void OnEnable(){
		//取得電子羅盤裝置, 才能偵測磁感應
		Input.location.Start();
		Input.compass.enabled = true;
        OneCompass = new Vector3(0,0,0);
        startgo = true;
	}
	// Update is called once per frame
	void Update () {

		if(startgo){
			ChageCompass = Input.compass.rawVector;
            deltaCompass = ChageCompass - OneCompass;
						
            //elephant
            if (deltaCompass.z>10 && deltaCompass.x>0 && deltaCompass.y<-10)
            {
                bplay[1] = true;
                bplay[2] = true;
                if (!audio.isPlaying && bplay[0])
                        {
                            audio.clip = aud[0];
                            audio.Play();
                            bplay[0] = false;
                        }
						transform.position=new Vector3(-15,60,0);
                        felez = ChageCompass.z;
				
			}
           
            //turtle
            else if (deltaCompass.z>-5 && deltaCompass.z<10 && deltaCompass.y>=-10)
            {
                bplay[0] = true;
                bplay[2] = true;
                if (!audio.isPlaying && bplay[1])
                {
                    audio.clip = aud[1];
                    audio.Play();
                    bplay[1] = false;
                }
                transform.position = new Vector3(0, 35, 0);


            }
           
           
            
             //tiger
            else if (deltaCompass.z<=-5)
            {
                bplay[1] = true;
                bplay[0] = true;
                if (!audio.isPlaying && bplay[2])
                {
                    audio.clip = aud[2];
                    audio.Play();
                    bplay[2] = false;
                }
                transform.position = new Vector3(20, 55, 0);
                ftiger = ChageCompass.z;
            }
            
            
            //歸零
            if(deltaCompass.x<2 && deltaCompass.x>-2 && deltaCompass.y<2 && deltaCompass.y>-2 && deltaCompass.z<2 && deltaCompass.z>-2)
            {
                bplay[1] = true;
                bplay[0] = true;
                bplay[2] = true;
                audio.Stop();
				transform.position=new Vector3(-30,8,0);
				
			}
			




		}
	}
	void OnGUI() {
		
		


        if (GUI.Button(new Rect(10, 10, 150, 120), "Reset  "+ OneCompass))
        {
            OneCompass = Input.compass.rawVector; 
        }
        if (GUI.Button(new Rect(Screen.width / 3, Screen.height/10, 50, 50), "on"))
        {
            startgo = true;
            Input.compass.enabled = true;
        }
        if (GUI.Button(new Rect(Screen.width / 3*2, Screen.height/10, 50, 50), "off"))
        {
            startgo = false;
            Input.compass.enabled = false;
        }
	}
}
