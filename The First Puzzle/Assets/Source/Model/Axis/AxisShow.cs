using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisShow : MonoBehaviour
{
    public Transform LampNode;
    public Transform PoleNode;
    public Transform DualPoleNode;
    public Transform CrossNode;
    public Transform DarkCrossNode;
    public Transform LightCrossNode;
    public Transform CamNode;
    public Transform LightNode;
    public Transform DarkNode;

    public GameObject LampAxisFrame;
    public GameObject PoleAxisFrame;
    public GameObject DualPoleAxisFrame;
    public GameObject CrossAxisFrame;
    public GameObject DarkCrossAxisFrame;
    public GameObject LightCrossAxisFrame;
    public GameObject CamAxisFrame;
    public GameObject LightAxisFrame;
    public GameObject DarkAxisFrame;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SelectAxisFrame(Transform obj)
    {
        if (obj == LampNode)
        {
            LampAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == PoleNode)
        {
            PoleAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == DualPoleNode)
        {
            DualPoleAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == CrossNode)
        {
            CrossAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == DarkCrossNode)
        {
            DarkCrossAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == LightCrossNode)
        {
            LightCrossAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == CamNode)
        {
            CamAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == LightNode)
        {
            LightAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
            if (obj == DarkNode)
        {
            DarkAxisFrame.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            LampAxisFrame.GetComponent<Renderer>().enabled = false;
            PoleAxisFrame.GetComponent<Renderer>().enabled = false;
            DualPoleAxisFrame.GetComponent<Renderer>().enabled = false;
            CrossAxisFrame.GetComponent<Renderer>().enabled = false;
            DarkCrossAxisFrame.GetComponent<Renderer>().enabled = false;
            LightCrossAxisFrame.GetComponent<Renderer>().enabled = false;
            CamAxisFrame.GetComponent<Renderer>().enabled = false;
            LightAxisFrame.GetComponent<Renderer>().enabled = false;
            DarkAxisFrame.GetComponent<Renderer>().enabled = false;
        }
    }
}
