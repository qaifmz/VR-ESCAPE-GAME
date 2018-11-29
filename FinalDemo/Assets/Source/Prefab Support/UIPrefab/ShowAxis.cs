using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAxis : MonoBehaviour {

    public GameObject AxisShow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowAxisFrames()
    {
        AxisShow.SetActive(true);
    }
}
