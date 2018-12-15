using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

    public GameObject titleScreen, factions, factionCreation, playerPanel, controlScreen;
    public GameObject twoPlayerButton, threePlayerButton, fourPlayerButton;
    public GameObject playerOnePanel, playerTwoPanel, playerThreePanel, playerFourPanel;
    public Transform twoPlayerOff, threePlayerOff, fourPlayerOff;

    //sound
    GameObject AudioManager;

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    public void BackButtonFactions()
    {
        factions.SetActive(false);
        playerPanel.SetActive(true);

        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void BackButtonFactionCreation()
    {
        factions.gameObject.SetActive(true);
        factionCreation.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void BackButtonControlScreen()
    {
        titleScreen.SetActive(true);
        controlScreen.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void BackButtonPlayerScreen() {
        playerPanel.SetActive(false);
        titleScreen.SetActive(true);
        playerOnePanel.SetActive(false);
        playerTwoPanel.SetActive(false);
        playerThreePanel.SetActive(false);
        playerFourPanel.SetActive(false);
        twoPlayerButton.transform.position = twoPlayerOff.position;
        threePlayerButton.transform.position = threePlayerOff.position;
        fourPlayerButton.transform.position = fourPlayerOff.position;

        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void StartButton()
    {
        titleScreen.gameObject.SetActive(false);
        playerPanel.gameObject.SetActive(true);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void CreateButton()
    {
        factions.gameObject.SetActive(false);
        factionCreation.gameObject.SetActive(true);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }


    public void SelectButton()
    {
        factions.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void ControlButton() {
        // when you click on the pink button in title screen
        titleScreen.SetActive(false);
        controlScreen.SetActive(true);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void BackOnMenu() {
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void AdvanceAMenu()
    {
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }

    public void SelectAnyButton()
    {
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }
}
