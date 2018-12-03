using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHierarchy : MonoBehaviour {

	private GameObject selectedObj ;
	public float speed = 20.0f;
	public Camera mainCam;
	public string ControlPointLowerArmName;
	public string ControlPointUpperArmName;
	public string ControlPointHeadName;
	public GameObject LowerArm;
	public GameObject UpperArm;
	public GameObject Head;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse is down");

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				//selectedObj = hitInfo.transform.gameObject;
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.name == ControlPointLowerArmName) {
					selectedObj = LowerArm;

				}else if(hitInfo.transform.gameObject.name == ControlPointUpperArmName){
					selectedObj = UpperArm;
				}else if(hitInfo.transform.gameObject.name == ControlPointHeadName){
					selectedObj = Head;
				}

			} else {
				Debug.Log("No hit");
			}
			//Debug.Log("Mouse is down");
		} 

		if (selectedObj != null) {

			if (Input.GetKey (KeyCode.W)) {
				//Debug.Log ("Rotate");
				selectedObj.transform.Rotate (Vector3.up * speed * Time.deltaTime);


			}

			if (Input.GetKey (KeyCode.S)) {
				//Debug.Log ("Rotate L");
				selectedObj.transform.Rotate (-Vector3.up * speed * Time.deltaTime);


			}

			if (Input.GetKey (KeyCode.A)) {
				selectedObj.transform.Rotate (Vector3.right * speed * Time.deltaTime);


			}

			if (Input.GetKey (KeyCode.D)) {
				selectedObj.transform.Rotate (-Vector3.right * speed * Time.deltaTime);


			}
		}


	}
}
