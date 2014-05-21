using UnityEngine;
using System.Collections;

public class Magmusic : MonoBehaviour {
	public static Vector3 deltaCompass;   //初始磁感應 
	public Vector3 ChageCompass;   //當下磁感應
	public Vector3 OneCompass; 
	bool startgo=false;
    public AudioClip[] aud;
    float felez,ftiger;
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
        OneCompass = new Vector3(8,-2,-20);
        startgo = true;
	}
	// Update is called once per frame
	void Update () {

		if(startgo){


			ChageCompass = Input.compass.rawVector;
            deltaCompass = ChageCompass - OneCompass;
						
            //elephant
            if ((ChageCompass.x - OneCompass.x) < 0 && (ChageCompass.x - OneCompass.x) > -20 &&
                (ChageCompass.y - OneCompass.y) > -50 && (ChageCompass.y - OneCompass.y) < -10)
            {
                        if (!audio.isPlaying)
                        {
                            audio.clip = aud[0];
                            audio.Play();
                        }
						transform.position=new Vector3(-20,80,0);
                        felez = ChageCompass.z;
				
			}
           
            //turtle
            else if ((ChageCompass.x - OneCompass.x) > -10 && (ChageCompass.x - OneCompass.x) < 0 &&
                      (ChageCompass.y - OneCompass.y) > -20 && (ChageCompass.y - OneCompass.y) < -10 &&
                        ChageCompass.z < felez)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = aud[2];
                    audio.Play();
                }
                transform.position = new Vector3(0, 50, 0);


            }
           
            //giraffe
            else if ((ChageCompass.x - OneCompass.x) < -40 && (ChageCompass.x - OneCompass.x) > -70 &&
                (ChageCompass.y - OneCompass.y) > 10 && (ChageCompass.y - OneCompass.y) < 20)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = aud[1];
                    audio.Play();
                }
                transform.position = new Vector3(-10, 20, 0);


            }
            
             //tiger
            else if ((ChageCompass.x - OneCompass.x) > 0 && (ChageCompass.y - OneCompass.y) < 10 &&
                       (ChageCompass.y - OneCompass.y) < 0 && (ChageCompass.y - OneCompass.y) > -10)
            {

                if (!audio.isPlaying)
                {
                    audio.clip = aud[3];
                    audio.Play();
                }
                transform.position = new Vector3(20, 70, 0);
                ftiger = ChageCompass.z;
            }
            
            //flamingo
            else if ((ChageCompass.x - OneCompass.x) > 0 && (ChageCompass.x - OneCompass.x) < 10 &&
                     (ChageCompass.y - OneCompass.y) < -8 && (ChageCompass.y - OneCompass.y) > -15 &&
                      ChageCompass.z > ftiger)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = aud[4];
                    audio.Play();
                }
                transform.position = new Vector3(15, 30, 0);


            }

            
            //歸零
            else
            {

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
