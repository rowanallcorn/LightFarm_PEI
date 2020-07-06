using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Grid_Reference : MonoBehaviour
{

    private scr_Grid sc_Grid;

    public GameObject obj_highlight;
    private bool mouseHeld = false;

    //FOR TESTING
    public GameObject pre_TilledSpot;
    public GameObject pre_Crop;

    public GameObject obj_TestObject;
    public bool isPlacingObject = false;
    private bool biggerObject = false;

    // Start is called before the first frame update
    void Start()
    {
        sc_Grid = GetComponent<scr_Grid>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //mouse held on press
            mouseHeld = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //mouse no longer held
            mouseHeld = false;
            //highlight no longer active
            obj_highlight.SetActive(false);
            
            //currently checks position, but also tils the spot selected
            CheckPosition();        
        }

        //when mouse is held down
        if (mouseHeld) {
            //enable highlight
            HighlightPosition();

            //if the player is trying to place an object
            if(isPlacingObject)
            PlacingObject(obj_TestObject);
        }

    }

    //move around the highlight object when the player holds down, to see where interacting
    void HighlightPosition() {
        //enable the highlight
        obj_highlight.SetActive(true);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //centre grid point
           obj_highlight.transform.position = sc_Grid.GetPointOnGridCentred(hit.point);

            //if player is placing an object, change the grid point
            if (isPlacingObject)
            {
                if (biggerObject)
                    obj_highlight.transform.position = sc_Grid.GetPointOnGridCorner(hit.point);
            }

            //move up slightly to be above ground
            obj_highlight.transform.position = new Vector3(obj_highlight.transform.position.x, obj_highlight.transform.position.y+ .05f, obj_highlight.transform.position.z);
        }
    }

    void CheckPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //FOR TESTING
            Debug.DrawLine(ray.origin, hit.point);

            if (hit.collider != null)
            {

                
                //only if hitting ground layer
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    //Get raycast's position as a point on the grid
                    //TillSoil(sc_Grid.GetPointOnGrid(hit.point));

                    //if player is placing an object
                    if (isPlacingObject)
                    {
                        //if it's bigger, the gridpoint is counted by the corner, otherwise centred
                        if (biggerObject)
                        {
                           PlaceObject(sc_Grid.GetPointOnGridCorner(hit.point), obj_TestObject);
                        }
                        else
                        {
                            PlaceObject(sc_Grid.GetPointOnGridCentred(hit.point), obj_TestObject);

                        }
                    }

                }
                //only if hitting farming plot
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("FarmPlot"))
                {
                   // PlantCrop(sc_Grid.GetPointOnGridCentred(hit.point));
                }



            }
        }
    }


    //FOR TESTING
    void TillSoil(Vector3 spawnPoint) {

        //tilled spot
        GameObject tilTestObj = Instantiate(pre_TilledSpot);
        tilTestObj.transform.position = spawnPoint;

    }

    void PlantCrop(Vector3 spawnPoint)
    {
        GameObject cropTestObj = Instantiate(pre_Crop);
        cropTestObj.transform.position = spawnPoint + Vector3.up;

    }


    //when placing an object
    void PlacingObject(GameObject objToPlace) {
        //if the object is bigger than one cell
        if (objToPlace.transform.localScale.x > sc_Grid.cellSize || objToPlace.transform.localScale.z > sc_Grid.cellSize)
        {
            biggerObject = true;
        }
        else {
            biggerObject = false;
        }

        //if the object is bigger, change the highlight to match the size
        if (biggerObject)
        {
            //TODO
            //set to size
            obj_highlight.transform.localScale = new Vector3(objToPlace.transform.localScale.x, objToPlace.transform.localScale.z, 1);
        }
        else
        {
            ResetHighlightSize();
        }

    }

    void PlaceObject(Vector3 spawnPoint, GameObject objToPlace)
    {
        //TODO: get object size half
        //rework with assets
        Vector3 halfObjectSize = objToPlace.transform.localScale * .5f;
        halfObjectSize = new Vector3(halfObjectSize.x - 1, halfObjectSize.y, halfObjectSize.z - 1);


        //check if collision????
        Collider[] colliders = Physics.OverlapBox(spawnPoint, halfObjectSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            //things to avoid
            if (colliders[i].tag == "Farm" )
            {
                //won't instantiate later down
                return;
            }

        }

        //intsantiate the object in the spot
        GameObject tilTestObj = Instantiate(objToPlace);
        tilTestObj.transform.position = spawnPoint;

        ResetHighlightSize();

    }

    private void ResetHighlightSize() {
        //reset highlight size
        obj_highlight.transform.localScale = new Vector3(2, 2, 1);
    }


}
