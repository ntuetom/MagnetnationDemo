using UnityEngine;
using System.Collections;

public class Mouse_move : MonoBehaviour {
	  Vector3 mousePosition;
	  RaycastHit hit;
      Ray ray;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 
		  if (Input.GetMouseButton(0)){
		
	
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			mousePosition = Camera.main.ScreenToViewportPoint (Input.mousePosition);

		
            if (Physics.Raycast(ray, out hit)){
           
					
					hit.transform.position = new Vector3(hit.point.x,hit.point.y,0);
			
				
					
				  Debug.Log(""+ray.origin+""+hit.point);
         
 			}
	
			
		}	
		
	}
	
}


