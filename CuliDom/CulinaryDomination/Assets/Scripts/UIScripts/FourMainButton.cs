using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourMainButton : MonoBehaviour {

    /*CameraMovement cameraScript;

    CloseWindows closeWindowScript;

    public GameObject recipieManagerPanel, dishCreationPanel;
    public GameObject empirePanel;
    public GameObject techTreePanel;
    public GameObject popUpMenu;
    public GameObject vacantPanel;
    public GameObject portraits;
    public GameObject endTurnButton;
    public GameObject optionsMenu;

    public RestaurantLocalScrollView restaurantScrollView;

    public Transform MikesUI;

    //sounds
    GameObject AudioManager;


    public void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
        closeWindowScript = FindObjectOfType<CloseWindows>();
    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    public void Update()
    {       //checks if all the panels are off so that the end turn button and character portraits can show
        /*if ((empirePanel.activeSelf == false) && (recipieManagerPanel.activeSelf == false) && (dishCreationPanel.activeSelf == false)
          && (techTreePanel.activeSelf == false) && (optionsMenu.activeSelf == false))
        {
            portraits.gameObject.SetActive(true);
            endTurnButton.gameObject.SetActive(true);
        }
        else
        {
            portraits.gameObject.SetActive(false);
            endTurnButton.gameObject.SetActive(false);
        }
    }

    //done
   public void EmpireButton()
    {
        if ((empirePanel.activeSelf == false))
        {
            // play sound to turn on Empire Panel Screen
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

            cameraScript.TurnCanMoveFalse();
            // Create RestauratScrollView content
            restaurantScrollView.CreateContent();
        }
        else if (empirePanel.activeSelf == true)
        {
            // Play sound to turn off Empire Panel Screen
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();

            cameraScript.TurnCanMoveTrue();
        }
        techTreePanel.gameObject.SetActive(false);
        dishCreationPanel.gameObject.SetActive(false);
        popUpMenu.gameObject.SetActive(false);
        vacantPanel.gameObject.SetActive(false);

        recipieManagerPanel.SetActive(false);
        techTreePanel.SetActive(false);
        //dishCreationPanel.SetActive(false);
        //popUpMenu.SetActive(false);
        //vacantPanel.SetActive(false);
        //residentPanel.SetActive(false);

    }

    //done
    public void RecipiesButton()
    {
        if ((recipieManagerPanel.activeSelf == false))
        {
            //Play sound to turn on Recipe Panel screen
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

            cameraScript.TurnCanMoveFalse();
            recipieManagerPanel.gameObject.SetActive(true);
        }
        else if (recipieManagerPanel.activeSelf == true)
        {
            // Play sound to turn off Recipe Panel screen
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();

            cameraScript.TurnCanMoveTrue();
            recipieManagerPanel.SetActive(false);
        }
        empirePanel.gameObject.SetActive(false);
        techTreePanel.gameObject.SetActive(false);
        popUpMenu.gameObject.SetActive(false);
        vacantPanel.gameObject.SetActive(false);

        //dishCreationPanel.SetActive(false);
        empirePanel.SetActive(false);
        techTreePanel.SetActive(false);
        //popUpMenu.gameObject.SetActive(false);
        //vacantPanel.gameObject.SetActive(false);
        //residentPanel.gameObject.SetActive(false);

    }

    public void TechTreeButton()
    {
        
        if ((techTreePanel.activeSelf == false))
        {
            // Play sound to turn TechTreen panel screen
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

            cameraScript.TurnCanMoveFalse();
            techTreePanel.SetActive(true);
        }
        else if (techTreePanel.activeSelf == true)
        {
            // Play sound to turn off TechTree panel Screen
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();

            cameraScript.TurnCanMoveTrue();
            techTreePanel.SetActive(false);
        }
        dishCreationPanel.gameObject.SetActive(false);
        popUpMenu.gameObject.SetActive(false);
        vacantPanel.gameObject.SetActive(false);
        
    }

    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
    }

    public void ExitUIButton()
    {

        // Play sound to turn off a screen
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();

        recipieManagerPanel.gameObject.SetActive(false);
        empirePanel.gameObject.SetActive(false);
        techTreePanel.gameObject.SetActive(false);
        popUpMenu.gameObject.SetActive(false);
    }*/


}
