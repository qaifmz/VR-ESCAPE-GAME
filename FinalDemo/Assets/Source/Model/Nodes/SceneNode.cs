﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneNode : MonoBehaviour {

    protected Matrix4x4 mCombinedParentXform;
    
    public Vector3 NodeOrigin = Vector3.zero;
    public List<NodePrimitive> PrimitiveList;
    /*
    public Transform AxisFrame = null;
    public Vector3 Offset = Vector3.zero;
    public SceneNode Parent = null;
    */
    

    // Use this for initialization
    protected void Start () {
        InitializeSceneNode();
        // Debug.Log("PrimitiveList:" + PrimitiveList.Count);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void InitializeSceneNode()
    {
        mCombinedParentXform = Matrix4x4.identity;
    }

    // This must be called _BEFORE_ each draw!! 
    public void CompositeXform(ref Matrix4x4 parentXform)
    {
        Matrix4x4 orgT = Matrix4x4.Translate(NodeOrigin);
        Matrix4x4 trs = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);
        
        mCombinedParentXform = parentXform * orgT * trs;

        // propagate to all children
        foreach (Transform child in transform)
        {
            SceneNode cn = child.GetComponent<SceneNode>();
            if (cn != null)
            {
                cn.CompositeXform(ref mCombinedParentXform);
            }
        }
        
        // disenminate to primitives
        foreach (NodePrimitive p in PrimitiveList)
        {
            p.LoadShaderMatrix(ref mCombinedParentXform);
        }

        /*/ Compute AxisFrame 
        if (AxisFrame != null)
        {
            AxisFrame.GetComponent<Renderer>().enabled = false;
            if (Parent != null)
            {
                AxisFrame.localPosition = mCombinedParentXform.MultiplyPoint(transform.localPosition);
                AxisFrame.localRotation = transform.localRotation;
            }
            else
            {
                AxisFrame.localPosition = transform.localPosition + Offset;
                AxisFrame.localRotation = transform.localRotation;
            }
        }*/
    }
}