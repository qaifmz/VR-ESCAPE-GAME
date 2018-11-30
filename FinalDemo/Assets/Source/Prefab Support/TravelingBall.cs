﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingBall : MonoBehaviour {

    float mSpeed = 0f;
    Vector3 mDir = Vector3.right;
    //float mMaxLengthAlive = 0f;  // in seconds
    //float mTimeAlive = 0f;

    TheWorld mWorld;

    //public GameObject mShadow;
    public GameObject mProjectedOnBig;


    // Use this for initialization
    void Start()
    {
        /*
        mShadow = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mShadow.GetComponent<Renderer>().material.color = Color.black;
        mShadow.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        mShadow.GetComponent<Renderer>().enabled = false; // don't show by default
        */
        mProjectedOnBig = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mProjectedOnBig.GetComponent<Renderer>().material.color = Color.white;
        mProjectedOnBig.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        mProjectedOnBig.GetComponent<Renderer>().enabled = false;
        mProjectedOnBig.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
    }
	
	// Update is called once per frame
	void Update () {
        /*
        mTimeAlive += Time.deltaTime;
        if (mTimeAlive > mMaxLengthAlive)
        {
            Destroy(mShadow);
            Destroy(mProjectedOnBig);
            Destroy(transform.gameObject);
        }

        bool castShadow = mWorld.ProcessBarrier(GetComponent<TravelingBall>(), mShadow.transform);
        mShadow.GetComponent<Renderer>().enabled = castShadow;*/

        bool castShadow = mWorld.ProcessBigLine(GetComponent<TravelingBall>(), mProjectedOnBig.transform);
        mProjectedOnBig.GetComponent<Renderer>().enabled = castShadow;
        

        transform.localPosition += mSpeed * Time.deltaTime * mDir;
        //Debug.Log("Ball: " + transform.localPosition);
    }

    public void Initialize(TheWorld w)
    {
        LineSegment l = w.GetAimLine();
        mWorld = w;
        SetDir(l.GetLineDir());
        SetStartPosition(l.GetStartPos());
        SetSpeed(mWorld.GetBallSpeed());
        //SetAliveTime(mWorld.GetAliveTime());
    }

    public Vector3 GetPosition() { return transform.localPosition; }
    public bool TravelTowards(Vector3 n) { return (Vector3.Dot(mDir, n) < 0f); }

    public void ReflectDir(Vector3 n)
    {  // WATCH OUT!! mDir is point towards n (instead of away!)
        float vDotn = Vector3.Dot(-mDir, n);
        SetDir(2*vDotn*n + mDir);
    }

    // private setters
    private void SetSpeed(float s) { mSpeed = s; }
    private void SetDir(Vector3 d) { mDir = d; }
    private void SetStartPosition(Vector3 p) { transform.localPosition = p; }
    //private void SetAliveTime(float t) { mMaxLengthAlive = t; }
}