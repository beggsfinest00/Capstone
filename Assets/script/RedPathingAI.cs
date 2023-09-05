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

    public GameObject[] knights;

    public Transform[] spots;

    private void Start()
    {
        spawnLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < knights.Length; i++)
        {
            knights[i].GetComponent<NavMeshAgent>().SetDestination(spots[i].position);
        }

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

        if (moving && transform.position.x == destination.x && transform.position.z == destination.z)
        {
            moving = false;
        }

        if (moving)
        {
            //anim.SetBool("Moving", true);
            anim?.SetFloat("Velocity", 1f);
        }
        else
        {
            //anim.SetBool("Moving", false);
            anim?.SetFloat("Velocity", 0f);
        }
    }
}
