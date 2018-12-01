using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxisFrames : MonoBehaviour {

    public GameObject Axis;
    public GameObject X;
    public GameObject Y;
    public GameObject Z;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Axis.GetComponent<Renderer>().enabled == true)
        {
            X.GetComponent<Renderer>().enabled = true;
            Y.GetComponent<Renderer>().enabled = true;
            Z.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            X.GetComponent<Renderer>().enabled = false;
            Y.GetComponent<Renderer>().enabled = false;
            Z.GetComponent<Renderer>().enabled = false;
        }
    }
}
