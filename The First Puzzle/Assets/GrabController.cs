using UnityEngine;

[DisallowMultipleComponent]
public class GrabController : MonoBehaviour
{
    [SerializeField] Transform holdPoint;
    [SerializeField] GameObject grabbed;

    [SerializeField] bool active;

    void Start()
    {
        grabbed = null;
        active = false;
    }

    void Update()
    {
        if (grabbed)
        {
            if (Input.GetKey(KeyCode.I) && !active)
            {
                active = true;
                holdPoint.gameObject.SetActive(false);
                grabbed.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            else if (Input.GetKey(KeyCode.O) && active)
            {
                active = false;
                holdPoint.gameObject.SetActive(true);
                grabbed.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbed = null;
            }
        }
        if (active)
        {
            grabbed.transform.position = holdPoint.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            grabbed = other.gameObject;
        }
    }
}