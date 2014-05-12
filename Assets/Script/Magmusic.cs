using UnityEngine;
using System.Collections;

public class Magmusic : MonoBehaviour {
	public static Vector3 deltaCompass;   //初始磁感應 
	public Vector3 ChageCompass;   //當下磁感應
	public Vector3 OneCompass; 
	bool startgo=false;
	public AudioClip[]  aud=new AudioClip[3];
    Vector3[] V3temp;
	// Use this for initialization
	void Start () { 
		// 取得預設 磁感應大小
        V3temp = new Vector3[2];
        deltaCompass = Vector3.zero;
	}
	void OnEnable(){
		//取得電子羅盤裝置, 才能偵測磁感應
		Input.location.Start();
		Input.compass.enabled = true;
        OneCompass = Input.compass.rawVector;
        startgo = true;
	}
	// Update is called once per frame
	void Update () {

		if(startgo){


			ChageCompass = Input.compass.rawVector;

						
            //elephant
            if ((ChageCompass.x - OneCompass.x) < -90 && (ChageCompass.y - OneCompass.y)<-30)
            {
                        if (!audio.isPlaying)
                        {
                            audio.clip = aud[0];
                            audio.Play();
                        }
						transform.position=new Vector3(80,-20,0);
							
				
			}

            //tiger
            else if ((ChageCompass.x - OneCompass.x) < -100 && (ChageCompass.y - OneCompass.y) < -40)
            {

                if (!audio.isPlaying)
                {
                    audio.clip = aud[1];
                    audio.Play();
                }
                transform.position = new Vector3(20, 70, 0);

            }

            //turtle
            else if ((ChageCompass.z - OneCompass.z) > 220 && (ChageCompass.y - OneCompass.y) < -60)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = aud[2];
                    audio.Play();
                }
                transform.position = new Vector3(0, 50, 0);


            }

            //giraffe
            else if ((ChageCompass.z - OneCompass.z) > 220 && (ChageCompass.y - OneCompass.y) < -60)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = aud[2];
                    audio.Play();
                }
                transform.position = new Vector3(-10, 20, 0);


            }

            //flamingo
            else if ((ChageCompass.z - OneCompass.z) > 220 && (ChageCompass.y - OneCompass.y) < -60)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = aud[2];
                    audio.Play();
                }
                transform.position = new Vector3(15, 30, 0);


            }

            //歸零
            if ((ChageCompass.x - OneCompass.x) < 10 && (ChageCompass.x - OneCompass.x) > -10)
            {

                audio.Stop();
				transform.position=new Vector3(-30,55,0);
				
			}
			




		}
	}
	void OnGUI() {
		
		if (GUI.Button(new Rect(10, 10, 100, 120), "計算結果")){
            deltaCompass = V3temp[1] - OneCompass;
		}

        if (GUI.Button(new Rect(140, 10, 150, 120), "REC值1  " + V3temp[0]))
        {
            V3temp[0] = Input.compass.rawVector;
        }

        if (GUI.Button(new Rect(300, 10, 150, 120), "REC值2  " + V3temp[1]))
        {
            V3temp[1] = Input.compass.rawVector; 
        }

        if (GUI.Button(new Rect(10, 140, 150, 120), "Reset  "+ OneCompass))
        {
            OneCompass = Input.compass.rawVector; 
        }
        if (GUI.Button(new Rect(Screen.width / 10, Screen.height/3*2, 50, 50), "on"))
        {
            startgo = true;
            Input.compass.enabled = true;
        }
        if (GUI.Button(new Rect(Screen.width / 3, Screen.height/3*2, 50, 50), "off"))
        {
            startgo = false;
            Input.compass.enabled = false;
        }
	}
}
