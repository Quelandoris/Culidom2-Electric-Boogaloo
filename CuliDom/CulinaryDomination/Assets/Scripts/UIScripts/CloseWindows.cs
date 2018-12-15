using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWindows : MonoBehaviour {


    public GameObject window;

    CameraMovement cameraScript;

    //sound stuff
    GameObject AudioManager;

    public void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
        MainNavigation.instance.CheckHomeElements();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            window.gameObject.SetActive(false);
        }
    }

    public void CloseWindow()
    {
        TurnOffWindow();
        UnclickTile();
        cameraScript.TurnCanMoveTrue();

    }

    void TurnOffWindow()
    {
        // put closing window sound here
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();

        window.gameObject.SetActive(false);
    }

    void UnclickTile()
    {
        try
        {
            window.GetComponent<DistrictUI>().building.tile.UnClick();
        }
        catch { }
        try
        {
            window.GetComponent<ResidentUI>().building.tile.UnClick();
        }
        catch { }
        try
        {
            window.GetComponent<VacantUI>().building.tile.UnClick();
        }
        catch { }
        try
        {
            window.GetComponent<RestaurantUI>().building.tile.UnClick();
        }
        catch { }
    }
}
