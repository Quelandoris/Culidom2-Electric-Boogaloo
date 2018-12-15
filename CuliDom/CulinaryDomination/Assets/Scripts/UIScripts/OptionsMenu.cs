using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    CameraMovement cameraScript;

    //public GameObject homeElements;

    //public GameObject optionsMenu, saveGameMenu, loadGameMenu, mainButtonsTab, techTreeUI, empireUI, recipeManagerUI,
        //recipeBuilder, popUpMenu, endTurnButton,portraits,tutorial,optionsButton,mainCanvas,startCanvas;


   // public Transform MikesUI;

    //sound
    GameObject AudioManager;

    //I'm dumb and need this bool because of how dumb I am - Dylan
    //bool dontPlayThisTime = false;

    void Update()
    {
        //CheckingIfMenusOff();

        /*if ((GameObject.FindWithTag("popUpMenu") == false) && (saveGameMenu.gameObject.activeInHierarchy == false) && (loadGameMenu.gameObject.activeInHierarchy == false)
            && (empireUI.gameObject.activeInHierarchy == false) && (techTreeUI.gameObject.activeInHierarchy == false) && (recipeManagerUI.gameObject.activeInHierarchy == false)
            && (recipeBuilder.gameObject.activeInHierarchy == false) && (optionsMenu.activeInHierarchy == false))
        {
            portraits.SetActive(true);
            endTurnButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                optionsMenu.gameObject.SetActive(true);
                mainButtonsTab.gameObject.SetActive(false);
                portraits.gameObject.SetActive(false);
                endTurnButton.gameObject.SetActive(false);

                AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

                dontPlayThisTime = true;
            }

        } else
        {
            portraits.SetActive(false);
            endTurnButton.SetActive(false);
        }*/

        /*if (Input.GetKeyUp(KeyCode.Escape))
        {
            //add menu closing functionality
            if(homeElements.activeSelf == true)
            {
                optionsMenu.SetActive(true);
            }
            if (loadGameMenu.gameObject.activeSelf == true)
            {
                loadGameMenu.gameObject.SetActive(false);
                mainButtonsTab.gameObject.SetActive(true);
                optionsButton.gameObject.SetActive(true);
                portraits.gameObject.SetActive(true);
                endTurnButton.gameObject.SetActive(true);
            }
            if (saveGameMenu.gameObject.activeSelf == true)
            {
                saveGameMenu.gameObject.SetActive(false);
                mainButtonsTab.gameObject.SetActive(true);
                optionsButton.gameObject.SetActive(true);
                portraits.gameObject.SetActive(true);
                endTurnButton.gameObject.SetActive(true);
            }
            
            empireUI.gameObject.SetActive(false);
            techTreeUI.gameObject.SetActive(false);
            empireUI.gameObject.SetActive(false);
            recipeManagerUI.gameObject.SetActive(false);
            recipeBuilder.gameObject.SetActive(false);

            if (!dontPlayThisTime)
            {
                AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
            }
            else
            {
                dontPlayThisTime = false;
            }

        }*/
    }

    public void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();

    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    /*public void OpenOptionsMenu()
    {
        if (MikesUI.Find("ResidentPanel(Clone)"))
        {
            Destroy(MikesUI.Find("ResidentPanel(Clone)").gameObject);

        }
        else if (MikesUI.Find("VacantPanel(Clone)"))
        {
            Destroy(MikesUI.Find("VacantPanel(Clone)").gameObject);
        }
        else if (MikesUI.Find("PopUpMenu(Clone)"))
        {
            Destroy(MikesUI.Find("PopUpMenu(Clone)").gameObject);
        }
        else
        {
            Debug.Log("I didnt find any of the panels I thought I would");
        }
        optionsMenu.gameObject.SetActive(true);
        techTreeUI.gameObject.SetActive(false);
        empireUI.gameObject.SetActive(false);
        recipeManagerUI.gameObject.SetActive(false);
        recipeBuilder.gameObject.SetActive(false);
        cameraScript.TurnCanMoveFalse();
        cameraScript.TurnOffEndTurn();
        mainButtonsTab.gameObject.SetActive(false);
        portraits.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
        // play menu enter
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }*/

    /*public void ResumeGame()
    {
        cameraScript.TurnCanMoveTrue();

        optionsMenu.gameObject.SetActive(false);
        mainButtonsTab.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        portraits.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
        // play menu select
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }*/

    /*public void ExitToMainMenu()
    {
        mainCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }*/

    /*public void OpenSaveGame()
    {
        saveGameMenu.gameObject.SetActive(true);
        mainButtonsTab.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        techTreeUI.gameObject.SetActive(false);
        empireUI.gameObject.SetActive(false);
        recipeManagerUI.gameObject.SetActive(false);
        recipeBuilder.gameObject.SetActive(false);
        portraits.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
    }

    public void CloseSaveGame()
    {
        saveGameMenu.gameObject.SetActive(false);
        mainButtonsTab.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        portraits.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
    }

    public void OpenLoadGame()
    {
        loadGameMenu.gameObject.SetActive(true);
        mainButtonsTab.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        techTreeUI.gameObject.SetActive(false);
        empireUI.gameObject.SetActive(false);
        recipeManagerUI.gameObject.SetActive(false);
        recipeBuilder.gameObject.SetActive(false);
        portraits.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
    }

    public void CloseLoadGame()
    {
        loadGameMenu.gameObject.SetActive(false);
        mainButtonsTab.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        portraits.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
    }*/


    public void QuitGame()
    {
        Application.Quit();
    }
}