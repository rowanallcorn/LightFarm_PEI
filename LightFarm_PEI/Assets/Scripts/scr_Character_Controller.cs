using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_Character_Controller : MonoBehaviour
{
    public LayerMask clickableGroundArea;
    public LayerMask clickableFarmingPlotArea;

    public float rotationSpeed;
    public float playerSpeed;

    private Vector3 targetPosition;
    private Vector3 lookAtTargetPosition;
    private Quaternion playerRotation;

    private bool isMoving;
    //private NavMeshAgent myAgent;



    // Start is called before the first frame update
    void Start()
    {
        //myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPositionToMoveTo();
        }
        if(isMoving == true)
        {
            Moving();
        }
    }

   

    void targetPositionToMoveTo()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hitInfo;

       if(Physics.Raycast(ray, out hitInfo, 100))
         {
            Debug.Log(hitInfo);

          targetPosition = hitInfo.point;
          targetPosition.y += 0.7f;
          //transform.LookAt(targetPosition);

          lookAtTargetPosition = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);
          playerRotation = Quaternion.LookRotation(lookAtTargetPosition);
          isMoving = true;

        }
       ///doesn't work yet.
        //else if (Physics.Raycast(ray, out hitInfo, 100, clickableFarmingPlotArea))
        //{
        //    isMoving = false;
        //}
    }

    private void Moving()
    {
      transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
      transform.position = Vector3.MoveTowards(transform.position, targetPosition, playerSpeed * Time.deltaTime);

      if (transform.position == targetPosition)
      {
         isMoving = false;
      }
        
    }


    //if (Input.GetMouseButtonDown(0))
    //{
    //    Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hitInfo;

    //    if (Physics.Raycast(myRay, out hitInfo, clickableGroundArea))
    //    {
    //        myAgent.SetDestination(hitInfo.point);

    //    }
    //}
}
