using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantInfoUI : MonoBehaviour {

    public Button constructionQueueButton, finishedUpgradesButton, buildButton, waitersButton, chefbutton;

    public GameObject menuPanel, constructionQueuePanel, finishedUpgradesPanel, upgradesPanel, waiterPanel, chefPanel, popUpMenu;

    CameraMovement cameraScript;

    public void Start()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
    }

    public void Upgrade()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            popUpMenu.gameObject.SetActive(false);
        }
    }

    public void ChefButton()
    {
        waiterPanel.gameObject.SetActive(false);
        chefPanel.gameObject.SetActive(true);
    }

    public void WaitersButton()
    {
        waiterPanel.gameObject.SetActive(true);
        chefPanel.gameObject.SetActive(false);
    }

    public void BuildButton()
    {
        if (upgradesPanel.gameObject.activeSelf == false)
        {
            upgradesPanel.gameObject.SetActive(true);
        }
        else if (upgradesPanel.gameObject.activeSelf == true)
        {
            upgradesPanel.gameObject.SetActive(false);
        }
    }

    public void ConstructionQueButton()
    {
        constructionQueuePanel.gameObject.SetActive(true);
        finishedUpgradesPanel.gameObject.SetActive(false);
    }

    public void FinishedUpgradesButton()
    {
        constructionQueuePanel.gameObject.SetActive(false);
        finishedUpgradesPanel.gameObject.SetActive(true);
        upgradesPanel.gameObject.SetActive(false);
    }

    public void MenuPanelButton()
    {
        menuPanel.gameObject.SetActive(true);
    }
}
