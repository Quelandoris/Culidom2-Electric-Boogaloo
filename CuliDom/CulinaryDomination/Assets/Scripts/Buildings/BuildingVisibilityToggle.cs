using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingVisibilityToggle : MonoBehaviour
{

    GameObject geo;

    public bool tallBuilding;
    /*
    bool tallsOn;
    bool toggle;
    bool visible;
    bool allOff;
    */
    int visMode;


    private void Awake()
    {
        geo = transform.Find("Model").Find("Geometry").gameObject;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            ToggleTalls();
        }

        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            ToggleAll();

        }*/

        if(Input.GetKeyDown(KeyCode.Slash))
        {
            if (visMode == 0)
            {
                TallsOff();
            }
            else if (visMode == 1)
            {
                AllOff();
            }
            else if (visMode == 2)
            {
                AllOn();
            }
        }
    }

    void AllOn()
    {
        visMode = 0;
        geo.SetActive(true);
    }

    void TallsOff()
    {
        visMode = 1;
        if(tallBuilding)
        {
            geo.SetActive(false);
        }
    }

    void AllOff()
    {
        visMode = 2;
        geo.SetActive(false);
    }
    /* TWO BUTTON TOGGLE - NOT FULLY WORKING
        void ToggleTalls()
        {
            if (allOff)
            {
                return;
            }
            else if (visible && tallsOn)
            {
                if (tallBuilding)
                {
                    geo.SetActive(false);
                    visible = false;
                }
                tallsOn = false;
                allOff = false;
            }
            else if (!tallsOn)
            {
                if (visible)
                {
                    tallsOn = true;
                    allOff = false;
                }
                if (!visible && tallBuilding)
                {
                    geo.SetActive(true);
                    visible = true;
                    tallsOn = true;
                    allOff = false;
                }


            } 
        }

        void ToggleAll()
        {
            if (visible)
            {
                // turn off visibility
                if (tallsOn) // if talls are showing
                {

                    geo.SetActive(false); // just hide everything
                    visible = false;
                    tallsOn = false;
                    allOff = true;
                }
                else if (!tallsOn && !allOff) // if talls are not showing
                {
                    if (!tallBuilding) // hide all short stuff
                    {
                        geo.SetActive(false);
                        visible = false;

                    }
                    allOff = true;
                }
            }
            else
            {
                if (allOff)
                {
                    geo.SetActive(true);
                    visible = true;
                    tallsOn = true;
                    allOff = false;
                }
                else if (tallsOn) // if talls are showing but everything else is not showing
                {
                    //show everything else
                    if (!tallBuilding)
                    {
                        geo.SetActive(true);
                        visible = true;

                    }
                    allOff = false;

                }
                else if (!tallsOn && allOff) // if EVERYTHING is not showing
                {
                    geo.SetActive(true); // just show everything
                    visible = true;
                    tallsOn = true;
                    allOff = false;
                }
            }
        }

    */




    /* THIS IS FOR MATERIAL ALPHA TOGGLE

    Renderer rend;
    public int visMode;

	// Use this for initialization
	void Start () {
        rend = transform.Find("Model").GetComponentInChildren<Renderer>();
        visMode = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Slash))
        {
            if (visMode == 0)
            {
                HalfVis();
            } else if (visMode == 1)
            {
                NoVis();
            } else if (visMode == 2)
            {
                FullVis();
            }
        }
	}

    void FullVis()
    {
        visMode = 0;
        rend.material.SetFloat("_Cutoff", 0f);
    }

    void HalfVis()
    {
        visMode = 1;
        rend.material.SetFloat("_Cutoff", 0.18f);
    }

    void NoVis()
    {
        visMode = 2;
        rend.material.SetFloat("_Cutoff", 0.85f);
    }
    */
}
