using UnityEngine;

[DisallowMultipleComponent]
public class GoalController : MonoBehaviour
{
    enum GoalType
    {
        Cube,
        Sphere,
        Cylinder
    }
    [SerializeField] GoalType type;

    [SerializeField] bool complete;

    public bool Complete
    {
        get
        {
            return complete;
        }

        set
        {
            complete = value;
        }
    }

    void Start()
    {
        Complete = false;
    }

    void Update()
    {
        if (Complete)
        {
            GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == GetGoalType())
        {
            Complete = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.name == GetGoalType())
        {
            Complete = false;
        }
    }

    string GetGoalType()
    {
        switch(type)
        {
            case (GoalType.Cube):
                return "Cube";
            case (GoalType.Sphere):
                return "Sphere";
            case (GoalType.Cylinder):
                return "Cylinder";
        }
        return "";
    }

}