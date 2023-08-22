using UnityEngine;
using UnityEngine.AI;

public class RedPathingAI: MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public Animator anim;

    Vector3 spawnLoc;

    Vector3 destination;

    bool moving;

    private void Start()
    {
        spawnLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;

           if (Physics.Raycast(ray, out hit))
           {
                
                //may not walk on
                if(hit.collider.CompareTag("Red A") && transform.tag != "Red Man")
                    agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Green D") && transform.tag != "Red Man")
                    agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Yellow D") && transform.tag != "Red Man")
                    agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Blue D") && transform.tag != "Red Man") 
                    agent.SetDestination(hit.point);

                //may walk on starts walk animation
                if (hit.collider.CompareTag("Red D") && transform.tag == "Red Man")
                {
                    agent.SetDestination(hit.point);
                    moving = true;
                    destination = hit.point;
                }
                    

                if (hit.collider.CompareTag("Green A") && transform.tag == "Red Man")
                {
                    agent.SetDestination(hit.point);
                    moving = true;
                    destination = hit.point;
                }
               

                if (hit.collider.CompareTag("Yellow A") && transform.tag == "Red Man")
                {
                    agent.SetDestination(hit.point);
                    moving = true;
                    destination = hit.point;
                }

                if (hit.collider.CompareTag("Blue A") && transform.tag == "Red Man")
                {
                    agent.SetDestination(hit.point);
                    moving = true;
                    destination = hit.point;
                }

                if (hit.collider.CompareTag("Center") && transform.tag == "Red Man")
                {
                    agent.SetDestination(hit.point);
                    moving = true;
                    destination = hit.point;
                }
            }
        }

        if (moving && transform.position == destination)
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetBool("Moving", true);
            anim.SetFloat("Velocity", 0.5f);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}
