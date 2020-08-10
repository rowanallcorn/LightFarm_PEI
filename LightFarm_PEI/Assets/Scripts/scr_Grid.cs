using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Grid : MonoBehaviour
{
    public int gridRows, gridColumns;
    private float gridY = 0.5f;

    //how big each cell is
    //correlates to overlay as well
    public int cellSize;

    private Vector3[,] gridCells;

    // Start is called before the first frame update
    void Start()
    {
        gridCells = new Vector3[gridRows, gridColumns];

        SetupGrid();

    }

    //initial grid setup
    //would need to be called again if grid is moved after setup? 
    private void SetupGrid()
    {
        //Loops create/store all the Vector points on the grid, according to size
        for (int x = 0; x < gridRows; x += cellSize)
        {
            for (int z = 0; z < gridColumns; z += cellSize)
            {
                gridCells[x, z] = new Vector3(transform.root.position.x + x, gridY, transform.root.position.z + z);
            }
        }
    }

    //get the centre of a cell on the grid
    public Vector3 GetPointOnGridCentred(Vector3 hitPoint)
    {
            //check for matching spot it array
            for (int x = 0; x < gridRows; x += cellSize)
            {
                for (int z = 0; z < gridColumns; z += cellSize)
                {

                if (z != 0 && x != 0)
                {
                    if (hitPoint.z < gridCells[x,z].z && hitPoint.z > gridCells[x, z].z - cellSize)
                    {
                        //if hit matches both row and col 
                        if (hitPoint.x < gridCells[x, z].x && hitPoint.x > gridCells[x, z].x - cellSize)
                        {
                            //return spot, but centred within grid cell
                             return GetCentreOfSpot(gridCells[x, z]);
                        }
                    }
                }
                else
                {
                    if (hitPoint.z < gridCells[x, z].z && hitPoint.z > 0)
                    {
                        //if hit matches both row and col 
                        if (hitPoint.x < gridCells[x, z].x && hitPoint.x > 0)
                        {
                            //return spot, but centred within grid cell
                            return GetCentreOfSpot(gridCells[x, z]);
                        }
                    }

                }

                }
            }

        //if nothing
       return Vector3.zero;


    }

    //get the grid point as a corner
    public Vector3 GetPointOnGridCorner(Vector3 hitPoint)
    {
        //check for matching spot it array
        for (int x = 0; x < gridRows; x += cellSize)
        {
            for (int z = 0; z < gridColumns; z += cellSize)
            {

                if (z != 0 && x != 0)
                {
                    if (hitPoint.z < gridCells[x, z].z && hitPoint.z > gridCells[x, z].z - cellSize)
                    {
                        //if hit matches both row and col 
                        if (hitPoint.x < gridCells[x, z].x && hitPoint.x > gridCells[x, z].x - cellSize)
                        {

                            //return spot
                            return gridCells[x, z];
                        }
                    }
                }
                else
                {
                    if (hitPoint.z < gridCells[x, z].z && hitPoint.z > 0)
                    {
                        //if hit matches both row and col 
                        if (hitPoint.x < gridCells[x, z].x && hitPoint.x > 0)
                        {

                            //return spot
                            return gridCells[x, z];
                        }
                    }

                }

            }
        }

        //if nothing
        return Vector3.zero;


    }


    //Return the grid position
    private Vector3 GetCentreOfSpot(Vector3 hitPoint)
    {
        //get half the size
        float halfCell = cellSize / 2f;

        //get new positions (moved in by half size)
        float newX = hitPoint.x - halfCell;
        float newZ = hitPoint.z - halfCell;
        Vector3 midCell = new Vector3(newX, gridY, newZ);

        //return new middle point
        return midCell;

    }

    //Visual Editor Reference
    //Enable to see how grid looks like in the scene
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < gridRows; x += cellSize)
        {
            for (float z = 0; z < gridColumns; z += cellSize)
            {
                Gizmos.DrawSphere( new Vector3(transform.root.position.x + x, gridY, transform.root.position.z + z),.1f);
            }

        }
    }
    */
}
