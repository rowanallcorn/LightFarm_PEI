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

    public bool isTillingSoil = false;
    public bool isPlantingSeed = false;
    public bool isHarvestingCrop = false;

    //For Holding Insantiated Objects in Scenes, cleaner
    public GameObject obj_SoilHolder;
    public GameObject obj_FarmHolder;


    //For planting specific crops
    public scr_Crop_Data[] cropList;
    public string currentlyPlanting;
    // public bool isPlantingPea, isPlantingPotato;


    //for soil health options
    public bool isWatering, isFertilizing, isAddingMinerals;

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
            ResetHighlightSize();
        }

        if (Input.GetMouseButtonUp(0))
        {
            //mouse no longer held
            mouseHeld = false;
            //highlight no longer active
            obj_highlight.SetActive(false);

            //currently checks position, but also tils the spot selected
            CheckPosition();

            //testing soil health options // adding on
            CheckingSoil();
        }

        //when mouse is held down
        if (mouseHeld)
        {
            //enable highlight
            HighlightPosition();

            //if the player is trying to place an object
            if (isPlacingObject)
                PlacingObject(obj_TestObject);
        }

    }

    //move around the highlight object when the player holds down, to see where interacting
    void HighlightPosition()
    {
        //enable the highlight
        obj_highlight.SetActive(true);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //centre grid point
            obj_highlight.transform.position = sc_Grid.GetPointOnGridCentred(hit.point);
            if (sc_Grid.cellSize == 1)
                obj_highlight.transform.position = sc_Grid.GetPointOnGridCorner(hit.point);

            //if player is placing an object, change the grid point
            if (isPlacingObject)
            {
                if (biggerObject)
                    obj_highlight.transform.position = sc_Grid.GetPointOnGridCorner(hit.point);
            }

            obj_highlight.transform.position -= new Vector3(0f, .5f, 0f);

            //move up slightly to be above ground
            obj_highlight.transform.position = new Vector3(obj_highlight.transform.position.x, obj_highlight.transform.position.y + .05f, obj_highlight.transform.position.z);
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

                    //if player is placing an object (raised bed)
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
                    //if player is just tilling
                    else if (isTillingSoil)
                    {
                        //Get raycast's position as a point on the grid

                        if (sc_Grid.cellSize == 1)
                            TillSoil(sc_Grid.GetPointOnGridCorner(hit.point));
                        else
                            TillSoil(sc_Grid.GetPointOnGridCentred(hit.point));
                    }
                }
                //only if hitting farming plot
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("FarmPlot"))
                {
                    if (isHarvestingCrop)
                    {
                        if (hit.collider.gameObject.tag != "RaisedBed")
                        {
                            //if clicking on soil, and there's a child (crop), try to harvest it
                            if (hit.collider.gameObject.transform.parent.childCount > 1)
                            {
                                hit.collider.gameObject.transform.parent.GetComponentInChildren<scr_Crop_Controller>().HarvestCrop();
                            }

                        }

                        if (hit.collider.gameObject.tag == "RaisedBed")
                        {
                            {

                                if (hit.collider.gameObject.GetComponent<scr_Raised_Bed>().soilPlots[0].transform.childCount > 1)
                                {
                                    //for each plot
                                    foreach (var singlePlot in hit.collider.gameObject.GetComponent<scr_Raised_Bed>().soilPlots)
                                    {
                                        //harvest the crop
                                        singlePlot.GetComponentInChildren<scr_Crop_Controller>().HarvestCrop();
                                    }
                                }

                            }
                        }
                    }

                    //TODO implement quantity checks for different seeds, and type of seed being planted
                    if (isPlantingSeed)
                    {

                        if (hit.collider.gameObject.tag == "RaisedBed")
                        {
                            //for each plot
                            foreach (var singlePlot in hit.collider.gameObject.GetComponent<scr_Raised_Bed>().soilPlots)
                            {
                                //Debug.Log(singlePlot);
                                //plant the crop
                                PlantCrop(singlePlot.transform.position, singlePlot.transform.GetChild(0).gameObject);
                            }

                        }
                        else
                        {
                            if (sc_Grid.cellSize == 1)
                                PlantCrop(hit.collider.gameObject.transform.position, hit.collider.gameObject);
                            else
                                PlantCrop(sc_Grid.GetPointOnGridCentred(hit.point), hit.collider.gameObject);
                        }
                    }


                }
                //if hitting crop directly
                else if (hit.collider.tag == "Crop")
                {
                    if (isHarvestingCrop)
                    {
                        //if crop is not part of raised bed, but single soil
                        if (hit.collider.gameObject.transform.root.gameObject.name == obj_SoilHolder.name)
                        {
                            hit.collider.gameObject.GetComponent<scr_Crop_Controller>().HarvestCrop();
                        }
                        //if hitting crop in a raised bed
                        else if (hit.collider.gameObject.transform.root.gameObject.name == obj_FarmHolder.name)
                        {
                            if (hit.collider.gameObject.transform.parent.parent.GetComponent<scr_Raised_Bed>().soilPlots[0].transform.childCount > 1)
                            {
                                //for each plot
                                foreach (var singlePlot in hit.collider.gameObject.transform.parent.parent.GetComponent<scr_Raised_Bed>().soilPlots)
                                {
                                    //harvest the crop
                                    singlePlot.GetComponentInChildren<scr_Crop_Controller>().HarvestCrop();
                                }
                            }
                        }
                    }
                }

            }
        }
    }


    //FOR TESTING
    void TillSoil(Vector3 spawnPoint)
    {

        Vector3 halfCellSize;

        //for collision checking
        if (sc_Grid.cellSize == 1)
            halfCellSize = new Vector3(sc_Grid.cellSize / 2, .5f, sc_Grid.cellSize / 2);
        else
            halfCellSize = new Vector3((sc_Grid.cellSize / 2) - .01f, .25f, (sc_Grid.cellSize / 2) - .01f);

        //check if collision????
        Collider[] colliders = Physics.OverlapBox(spawnPoint, halfCellSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            //things to avoid
            if (colliders[i].tag == "Farm" || colliders[i].gameObject.layer == 9)
            {
                //won't instantiate later down
                return;
            }

        }


        //tilled spot
        GameObject tilTestObj = Instantiate(pre_TilledSpot);
        tilTestObj.transform.position = spawnPoint;
        tilTestObj.transform.position -= new Vector3(0f, .5f, 0f);
        tilTestObj.transform.parent = obj_SoilHolder.transform;

        ResetHighlightSize();
    }


    void PlantCrop(Vector3 spawnPoint, GameObject soilPlot)
    {
         Vector3 halfCellSize = new Vector3(sc_Grid.cellSize / 2, 1f, sc_Grid.cellSize / 2);
        //Vector3 halfCellSize = new Vector3(sc_Grid.cellSize, 1f, sc_Grid.cellSize);

        //check if collision????
        Collider[] colliders = Physics.OverlapBox(spawnPoint, halfCellSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            //things to avoid
            if (colliders[i].tag == "Crop")
            {
                //won't instantiate later down
                return;
            }

        }

        //TODO, change for specific crops clicked
        //crop
        GameObject cropObj = Instantiate(pre_Crop);
        cropObj.transform.position = spawnPoint + Vector3.up;
        cropObj.transform.parent = soilPlot.transform.parent;

        PlantSpecificCrop(cropObj);

        ResetHighlightSize();
    }

    //when placing an object
    void PlacingObject(GameObject objToPlace)
    {
        /*   
        //if the object is bigger than one cell
        if (objToPlace.transform.localScale.x > sc_Grid.cellSize || objToPlace.transform.localScale.z > sc_Grid.cellSize)
        {
            biggerObject = true;
        }
        else
        {
            biggerObject = false;
        }

        //if the object is bigger, change the highlight to match the size
        if (biggerObject)
        {
            //set to size
             obj_highlight.transform.localScale = new Vector3(objToPlace.transform.localScale.x, objToPlace.transform.localScale.z, 1);
            //obj_highlight.transform.localScale = new Vector3(objToPlace.GetComponent<scr_Grid_Object_Size>().tileX * sc_Grid.cellSize, objToPlace.GetComponent < scr_Grid_Object_Size>().tileZ * sc_Grid.cellSize, 1);
        }
        else
        {
            ResetHighlightSize();
        }*/

        biggerObject = true;
        obj_highlight.transform.localScale = new Vector3(objToPlace.GetComponent<scr_Grid_Object_Size>().tileX * sc_Grid.cellSize, objToPlace.GetComponent<scr_Grid_Object_Size>().tileZ * sc_Grid.cellSize, 1);

    }

    void PlaceObject(Vector3 spawnPoint, GameObject objToPlace)
    {
        //TODO: get object size half
        //rework with assets
        //Vector3 halfObjectSize = objToPlace.transform.localScale * .5f;
         //halfObjectSize = new Vector3(halfObjectSize.x, halfObjectSize.y, halfObjectSize.z);
        Vector3 halfObjectSize = new Vector3((objToPlace.GetComponent<scr_Grid_Object_Size>().tileX * sc_Grid.cellSize)/2+1, 1, (objToPlace.GetComponent<scr_Grid_Object_Size>().tileZ * sc_Grid.cellSize)/2);

        // halfObjectSize = new Vector3(halfObjectSize.x - 1, halfObjectSize.y, halfObjectSize.z - 1);


        //check if collision????
        Collider[] colliders = Physics.OverlapBox(spawnPoint, halfObjectSize);
        for (int i = 0; i < colliders.Length; i++)
        {
            //things to avoid
            if (colliders[i].tag == "Farm" || colliders[i].tag == "RaisedBed" || colliders[i].gameObject.layer == 9)
            {
                //won't instantiate later down
                return;
            }

        }

        //intsantiate the object in the spot
        GameObject farmTestObj = Instantiate(objToPlace);
        farmTestObj.transform.position = spawnPoint;
        //farmTestObj.transform.position -= new Vector3(0f, 4.5f, 0f); //move down
        farmTestObj.transform.parent = obj_FarmHolder.transform;

        ResetHighlightSize();

    }

    private void ResetHighlightSize()
    {
        //reset highlight size
        obj_highlight.transform.localScale = new Vector3(sc_Grid.cellSize, sc_Grid.cellSize, 1);
    }


    public void PlantSpecificCrop(GameObject cropObj)
    {

        //based on "currentlyPlanting" string, set the right data for the plant object
        switch (currentlyPlanting)
        {
            case "Carrot":
                cropObj.GetComponent<scr_Crop_Controller>().data = cropList[GetCropIndexInList("Carrot")];
                break;
            case "Cauliflower":
                cropObj.GetComponent<scr_Crop_Controller>().data = cropList[GetCropIndexInList("Cauliflower")];
                break;
            case "Pea":
                cropObj.GetComponent<scr_Crop_Controller>().data = cropList[GetCropIndexInList("Pea")];
                break;
            case "Potato":
                cropObj.GetComponent<scr_Crop_Controller>().data = cropList[GetCropIndexInList("Potato")];
                break;
            case "Winter Wheat":
                cropObj.GetComponent<scr_Crop_Controller>().data = cropList[GetCropIndexInList("Winter Wheat")];
                break;
        }
    }

    //find a crop based on it's name and return it's index in the list
    private int GetCropIndexInList(string cropName)
    {

        //look for crop with matching name
        for (int i = 0; i < cropList.Length; i++)
        {
            //if match, return index
            if (cropList[i].name == cropName)
            {
                return i;
            }
        }

        //otherwise 0
        return 0;
    }

    /* for bools
    public void PlantSpecificCrop( GameObject cropObj)
    {

        if (isPlantingPea)
        {
            cropObj.GetComponent<scr_Crop_Controller>().data = cropList[2];
        }
        else if (isPlantingPotato)
        {
            cropObj.GetComponent<scr_Crop_Controller>().data = cropList[3];
        }

    }*/


    //dealing with soil health values
    void CheckingSoil()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //FOR TESTING
            //Debug.DrawLine(ray.origin, hit.point);

            if (hit.collider != null)
            {
                //only if hitting ground layer
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("FarmPlot"))
                {
                    //if soil is part of a raised bed
                    if (hit.collider.gameObject.tag == "RaisedBed")
                    {

                        //for each plot
                        foreach (var singlePlot in hit.collider.gameObject.GetComponent<scr_Raised_Bed>().soilPlots)
                        {
                            //depending on current action tested
                            if (isWatering)
                            {
                                singlePlot.GetComponent<scr_Soil_Health>().IncreaseWater();
                            }
                            else if (isAddingMinerals)
                            {
                                singlePlot.GetComponent<scr_Soil_Health>().IncreaseMinerals();
                            }
                            else if (isFertilizing)
                            {
                                singlePlot.GetComponent<scr_Soil_Health>().IncreaseFertilizer();
                            }
                        }

                    }
                    else
                    {
                        //hits single dirt
                        //depending on current action tested
                        if (isWatering)
                        {
                            hit.collider.gameObject.transform.parent.GetComponent<scr_Soil_Health>().IncreaseWater();
                        }
                        else if (isAddingMinerals)
                        {
                            hit.collider.gameObject.transform.parent.GetComponent<scr_Soil_Health>().IncreaseMinerals();
                        }
                        else if (isFertilizing)
                        {
                            hit.collider.gameObject.transform.parent.GetComponent<scr_Soil_Health>().IncreaseFertilizer();
                        }
                    }

                }
            }
        }

    }


}
