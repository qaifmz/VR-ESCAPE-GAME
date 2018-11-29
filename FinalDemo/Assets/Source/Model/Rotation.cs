using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    private const float kRotateDelta = 45; // per second
    private const float kRotateSize = 80;
    private int RotateSign = 1;
    private int RotateCount = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float angle = RotateSign * kRotateDelta * Time.fixedDeltaTime;
        Quaternion q = Quaternion.AngleAxis(angle, transform.right);
        transform.localRotation = q * transform.localRotation;
        RotateCount += RotateSign;
        if (Mathf.Abs(RotateCount) > kRotateSize)
        {
            RotateSign *= -1;
        }
    }
}
