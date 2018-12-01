using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulation : MonoBehaviour {

    public enum LookAtCompute {
        QuatLookRotation = 0,
        TransformLookAt = 1
    };

    public Transform LookAtPosition = null;
    public LineSeg LineOfSight = null;
    public LookAtCompute ComputeMode = LookAtCompute.QuatLookRotation;
    public bool OrbitHorizontal = false;

    public float distance = 50.0f;
    public float speed = 5f;
    public Transform target;
    public float distanceMin = 50f;
    public float distanceMax = 5000f;
    public Vector3 lastPosition;

    private float ZoomAmount = 0; //With Positive and negative values
    private float MaxToClamp = 10;
    private float scrollSpeed = 20f;

    private Vector3 initial, recent;

    // Use this for initialization
    void Start () {
        Debug.Assert(LookAtPosition != null);
        Debug.Assert(LineOfSight != null);
        LineOfSight.SetWidth(0.2f);
        LineOfSight.SetPoints(transform.localPosition, LookAtPosition.localPosition);
    }
    
    // Update is called once per frame
    void Update () 
    {
        LineOfSight.SetPoints(transform.localPosition, LookAtPosition.localPosition);

        switch (ComputeMode)
        {
            case LookAtCompute.QuatLookRotation:
                // Viewing vector is from transform.localPosition to the lookat position
                Vector3 V = LookAtPosition.localPosition - transform.localPosition;
                Vector3 W = Vector3.Cross(-V, transform.up);
                Vector3 U = Vector3.Cross(W, -V);
                transform.localRotation = Quaternion.LookRotation(V, U);
                break;

            case LookAtCompute.TransformLookAt:
                transform.LookAt(LookAtPosition);
                break;
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetMouseButton(0)) 
            {
                transform.LookAt(target);
                transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
                transform.RotateAround(target.position, Vector3.right, Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad * -10.0f);
            }

            if (Input.GetMouseButtonDown(1))
            {
                initial = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            }
            else if (Input.GetMouseButton(1))
            {
                recent = new Vector3(Input.mousePosition.x - initial.x, Input.mousePosition.y - initial.y, 0);
                initial = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                transform.position = new Vector3(transform.position.x - recent.x * Time.deltaTime, transform.position.y - recent.y / 2f * Time.deltaTime, transform.position.z);
                target.position = new Vector3(target.position.x - recent.x * Time.deltaTime, target.position.y - recent.y / 2f * Time.deltaTime, target.position.z);

            }


            ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
            ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
            var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
            gameObject.transform.Translate(0, 0, translate * scrollSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

        }
    }
}
    