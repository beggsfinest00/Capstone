using UnityEngine;
using UnityEngine.AI;

public class PathingAI : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

  
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

                //may walk on
                if (hit.collider.CompareTag("Red D") && transform.tag == "Red Man")
                    agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Green A") && transform.tag == "Red Man")
                    agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Yellow A") && transform.tag == "Red Man")
                    agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Blue A") && transform.tag == "Red Man")
                    agent.SetDestination(hit.point);

                if (hit.collider.CompareTag("Center") && transform.tag == "Red Man")
                    agent.SetDestination(hit.point);
            }
        }
    }
}
