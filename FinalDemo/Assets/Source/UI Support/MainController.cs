using System; // for assert
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for GUI elements: Button, Toggle

public partial class MainController : MonoBehaviour {

    // reference to all UI elements in the Canvas
    public Camera MainCamera = null;
    public TheWorld mModel = null;
    public World World = null;
    /*
    public XfromControl mXform = null;
    public SliderWithEcho IntervalControl = null;
    public SliderWithEcho SpeedControl = null;
    public SliderWithEcho DeathControl = null;
    */

    // Use this for initialization
    void Start() {
        Debug.Assert(MainCamera != null);
        Debug.Assert(mModel != null);
        Debug.Assert(World != null);
        /*
        Debug.Assert(mXform != null);
        Debug.Assert(IntervalControl != null);
        Debug.Assert(SpeedControl != null);
        Debug.Assert(DeathControl != null);

        IntervalControl.SetSliderLabel("Interval");
        IntervalControl.InitSliderRange(0.5f, 4f, 1f);
        IntervalControl.SetSliderListener(mModel.SetBallInterval);
        mModel.SetBallInterval(IntervalControl.GetSliderValue());

        SpeedControl.SetSliderLabel("Speed");
        SpeedControl.InitSliderRange(0.5f, 15f, 6f);
        SpeedControl.SetSliderListener(mModel.SetBallSpeed);
        mModel.SetBallSpeed(SpeedControl.GetSliderValue());

        DeathControl.SetSliderLabel("Alive Sec");
        DeathControl.InitSliderRange(1, 15, 10);
        DeathControl.SetSliderListener(mModel.SetAliveTime);
        mModel.SetAliveTime(DeathControl.GetSliderValue());

        mXform.SetSelectedObject(mModel.GetBarrierObject());
        */
    }

    // Update is called once per frame
    void Update() {
        LMBService();
    }
}
