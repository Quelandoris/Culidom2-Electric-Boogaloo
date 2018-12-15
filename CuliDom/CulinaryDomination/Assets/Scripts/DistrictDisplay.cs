using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictDisplay : MonoBehaviour {

    public enum CornerStates { DISABLED, INNER, OUTER};

    public enum DistrictWalls { TOP, RIGHT, BOTTOM, LEFT };

    public enum DistrictCorners { TOP_LEFT, TOP_RIGHT, BOTTOM_RIGHT, BOTTOM_LEFT };

    public GameObject topWall;
    public GameObject rightWall;
    public GameObject bottomWall;
    public GameObject leftWall;

    public GameObject tlCorner;
    public GameObject trCorner;
    public GameObject brCorner;
    public GameObject blCorner;

    public Sprite innerCornerSprite;
    public Sprite outerCornerSprite;

    bool[,] currentLayout = new bool[3, 3];
    Color currentColor;

	// Use this for initialization
	void Start () {
        
	}

    /// <summary>
    /// Sets the district border accordingly
    /// </summary>
    /// <param name="sameDistrict">3x3 boolean array (x,y). The center represents this tile, elements are true if that tile is part of the same district as this one.</param>
    public void SetBorders(bool[,] sameDistrict, Color color)
    {
        currentLayout = sameDistrict;
        currentColor = color;

        topWall.SetActive(false);
        topWall.GetComponent<SpriteRenderer>().color = color;
        rightWall.SetActive(false);
        rightWall.GetComponent<SpriteRenderer>().color = color;
        bottomWall.SetActive(false);
        bottomWall.GetComponent<SpriteRenderer>().color = color;
        leftWall.SetActive(false);
        leftWall.GetComponent<SpriteRenderer>().color = color;
        tlCorner.SetActive(false);
        tlCorner.GetComponent<SpriteRenderer>().color = color;
        trCorner.SetActive(false);
        trCorner.GetComponent<SpriteRenderer>().color = color;
        brCorner.SetActive(false);
        brCorner.GetComponent<SpriteRenderer>().color = color;
        blCorner.SetActive(false);
        blCorner.GetComponent<SpriteRenderer>().color = color;

        if (sameDistrict == null)
        {
            return;
        }

        bool topOn = !sameDistrict[1, 2];
        bool rightOn = !sameDistrict[2, 1];
        bool bottomOn = !sameDistrict[1, 0];
        bool leftOn = !sameDistrict[0, 1];

        SetWall(DistrictWalls.TOP, topOn);
        SetWall(DistrictWalls.RIGHT, rightOn);
        SetWall(DistrictWalls.BOTTOM, bottomOn);
        SetWall(DistrictWalls.LEFT, leftOn);

        //Top Left Check
        if(topOn && leftOn)
        {
            SetCorner(DistrictCorners.TOP_LEFT, CornerStates.INNER);
        }
        else if(topOn ^ leftOn)
        {
            SetCorner(DistrictCorners.TOP_LEFT, CornerStates.DISABLED);
        }
        else if (sameDistrict[0, 2])
        {
            SetCorner(DistrictCorners.TOP_LEFT, CornerStates.DISABLED);
        }
        else if(!topOn && !leftOn)
        {
            SetCorner(DistrictCorners.TOP_LEFT, CornerStates.OUTER);
        }
        

        //Top Right Check
        if (topOn && rightOn)
        {
            SetCorner(DistrictCorners.TOP_RIGHT, CornerStates.INNER);
        }
        else if (topOn ^ rightOn)
        {
            SetCorner(DistrictCorners.TOP_RIGHT, CornerStates.DISABLED);
        }
        else if (sameDistrict[2, 2])
        {
            SetCorner(DistrictCorners.TOP_RIGHT, CornerStates.DISABLED);
        }
        else if (!topOn && !rightOn)
        {
            SetCorner(DistrictCorners.TOP_RIGHT, CornerStates.OUTER);
        }
        

        //Bottom Right Check
        if (bottomOn && rightOn)
        {
            SetCorner(DistrictCorners.BOTTOM_RIGHT, CornerStates.INNER);
        }
        else if (bottomOn ^ rightOn)
        {
            SetCorner(DistrictCorners.BOTTOM_RIGHT, CornerStates.DISABLED);
        }
        else if (sameDistrict[2, 0])
        {
            SetCorner(DistrictCorners.BOTTOM_RIGHT, CornerStates.DISABLED);
        }
        else if(!bottomOn && !rightOn)
        {
            SetCorner(DistrictCorners.BOTTOM_RIGHT, CornerStates.OUTER);
        }
        

        //Bottom Left Check
        if (bottomOn && leftOn)
        {
            SetCorner(DistrictCorners.BOTTOM_LEFT, CornerStates.INNER);
        }
        else if (bottomOn ^ leftOn)
        {
            SetCorner(DistrictCorners.BOTTOM_LEFT, CornerStates.DISABLED);
        }
        else if (sameDistrict[0, 0])
        {
            SetCorner(DistrictCorners.BOTTOM_LEFT, CornerStates.DISABLED);
        }
        else if(!bottomOn && !leftOn)
        {
            SetCorner(DistrictCorners.BOTTOM_LEFT, CornerStates.OUTER);
        }
        
    }

    public bool[,] GetLayout()
    {
        return currentLayout;
    }

    public Color GetColor()
    {
        return currentColor;
    }
	
    void SetWall(DistrictWalls wall, bool enabled)
    {
        GameObject selectedWall = null;
        switch (wall)
        {
            case DistrictWalls.TOP:
                selectedWall = topWall;
                break;
            case DistrictWalls.RIGHT:
                selectedWall = rightWall;
                break;
            case DistrictWalls.BOTTOM:
                selectedWall = bottomWall;
                break;
            case DistrictWalls.LEFT:
                selectedWall = leftWall;
                break;
        }
        selectedWall.SetActive(enabled);
    }

    void SetCorner(DistrictCorners corner, CornerStates state)
    {
        GameObject selectedCorner = null;
        switch (corner)
        {
            case DistrictCorners.TOP_LEFT:
                selectedCorner = tlCorner;
                break;
            case DistrictCorners.TOP_RIGHT:
                selectedCorner = trCorner;
                break;
            case DistrictCorners.BOTTOM_RIGHT:
                selectedCorner = brCorner;
                break;
            case DistrictCorners.BOTTOM_LEFT:
                selectedCorner = blCorner;
                break;
        }

        switch (state)
        {
            case CornerStates.DISABLED:
                selectedCorner.SetActive(false);
                break;
            case CornerStates.INNER:
                selectedCorner.SetActive(true);
                selectedCorner.GetComponent<SpriteRenderer>().sprite = innerCornerSprite;
                break;
            case CornerStates.OUTER:
                selectedCorner.SetActive(true);
                selectedCorner.GetComponent<SpriteRenderer>().sprite = outerCornerSprite;
                break;
        }
    }
}
