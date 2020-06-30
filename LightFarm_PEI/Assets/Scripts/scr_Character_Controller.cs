using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_Character_Controller : MonoBehaviour
{
    public LayerMask clickableGroundArea;
    public LayerMask clickableFarmingPlotArea;
    



    private NavMeshAgent myAgent;



    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving();     
    }

   

    void Moving()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, clickableGroundArea))
            {
                myAgent.SetDestination(hitInfo.point);

            }
        }

    }
}
