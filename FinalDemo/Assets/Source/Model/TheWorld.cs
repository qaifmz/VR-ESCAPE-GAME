using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TheWorld : MonoBehaviour {

    public SceneNode TheRoot;
    public UILineSegment AimingLine;
    public UILineSegment BigLine;
    //public Plane Barrier;

    const float kBigLineWidth = 3f;

    // to keep track of last time a ball is geneated
    //float mSinceLastGenerated = 10f;
    //float mGenerateInterval = 1f;  // in second
    float mSpeed = 30f; // 1 unit per second
    //float mAliveTime = 10f;


	// Use this for initialization
	void Start () {
        Debug.Assert(AimingLine != null);
        Debug.Assert(BigLine != null);
        //Debug.Assert(Barrier != null);

        BigLine.SetWidth(kBigLineWidth);
    }

    void Update()
    {
        /*
        mSinceLastGenerated += Time.deltaTime;
        if (mSinceLastGenerated >= mGenerateInterval)
        {
            GameObject g = Instantiate(Resources.Load("TravelingBall")) as GameObject;
            TravelingBall b = g.GetComponent<TravelingBall>();
            b.Initialize(this);

            mSinceLastGenerated = 0f;
        }
        */
        //  Matrix4x4 i = Matrix4x4.identity;
        //TheRoot.CompositeXform(ref i);

        if (Input.GetMouseButtonDown(1))
        {
            GameObject g = Instantiate(Resources.Load("TravelingBall")) as GameObject;
            TravelingBall b = g.GetComponent<TravelingBall>();
            b.Initialize(this);
        }
    }

    public bool SetLineEndPoint(string onWall, Vector3 p)
    {
        return AimingLine.SetEndPoint(onWall, p) || BigLine.SetEndPoint(onWall, p);
    }
    

    // Setter/Getter
    public void SetBallSpeed(float s) { mSpeed = s; }
    public float GetBallSpeed() { return mSpeed; }
    //public void SetBallInterval(float i) { mGenerateInterval = i; }
    //public float GetBallInterval() { return mGenerateInterval; }
    //public void SetAliveTime(float l) { mAliveTime = l;  }
    //public float GetAliveTime() { return mAliveTime; }
    
    //public GameObject GetBarrierObject() { return Barrier.gameObject; }
    public LineSegment GetAimLine() { return AimingLine; }
}
