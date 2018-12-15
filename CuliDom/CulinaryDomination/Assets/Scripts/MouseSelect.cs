using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour {
    Camera myCamera;
    WorldTile selected;
    WorldTile lastClicked;
	// Use this for initialization
	void Start () {
        myCamera = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) //If not mousing over a UI element
        {
            RaycastTiles();
        }
        else
        {
            ClearSelection();
        }
	}

    void RaycastTiles()
    {
        RaycastHit tileHit;
        Ray screenRay = myCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(screenRay, out tileHit))
        {

            if (tileHit.collider.CompareTag("Tile"))
            {
                WorldTile newTile = tileHit.collider.GetComponentInParent<WorldTile>();
                if (newTile != selected)
                {
                    if (selected != null)
                    {
                        selected.Deselect();
                    }
                    selected = newTile;
                    selected.Select();
                }
                if (Input.GetMouseButtonDown(0)) //Change this to use virtual buttons later
                {
                    if(lastClicked != null)
                    {
                        try
                        {
                            lastClicked.UnClick();
                        }
                        catch { }
                    }
                    lastClicked = selected;
                    selected.Click();
                }
            }
            else
            {
                ClearSelection();
            }
        }
        else
        {
            ClearSelection();
        }
    }

    private void ClearSelection()
    {
        if (selected != null)
        {
            selected.Deselect();
        }
        selected = null;
    }

    public void UnClick() {
        if(lastClicked != null) {
            lastClicked.UnClick();
        }
    }
}
