using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

    public Button closeMenuButton, addDishbutton, closeAddDishbutton1, closeAddDishbutton2, closeAddDishbutton3, XAddDishbutton, openMenuButton;

    public GameObject addDishPanel, menuPanel, resturnantPopupPanel, enemyTilePanel;
    public RectTransform menuContent;

    CameraMovement cameraScript;
    RestaurantUI restaurantScript;
    public CreateMenuRecipes menuScript;

    //sound
    GameObject AudioManager;

    private void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
       
    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    public void ClosePopup() {
        resturnantPopupPanel.SetActive(false);
        cameraScript.TurnCanMoveTrue();

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void CloseEnemyTile() {
        enemyTilePanel.SetActive(false);
        cameraScript.TurnCanMoveTrue();

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void OpenMenu()
    {
        restaurantScript = this.GetComponent<RestaurantUI>();
     
        //menuScript.PopulateMenu(restaurantScript.building);
        menuScript.PopulateMenu();

        menuPanel.gameObject.SetActive(true);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void CloseMenu()
    {
        
            menuScript.ClearMenu();
        
        menuPanel.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void OpenAddDishPanel()
    {
        addDishPanel.gameObject.SetActive(true);
        CreateSavedRecipeButtons buttonMananger = addDishPanel.GetComponentInChildren<CreateSavedRecipeButtons>();
        buttonMananger.ClearContent();
        buttonMananger.CreateBuildingReferences();

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void CloseAddDishPanel()
    {
        addDishPanel.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }
}