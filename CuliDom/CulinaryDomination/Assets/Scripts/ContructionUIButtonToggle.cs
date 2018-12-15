using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContructionUIButtonToggle : MonoBehaviour {

    public GameObject currentMenu;
    public GameObject completedMenu;

    VoicePacks voiceScript;

    public void Awake()
    {
        voiceScript = FindObjectOfType<VoicePacks>();
    }

    public void CurrentConstructionMenu()
    {
        completedMenu.SetActive(false);
        currentMenu.SetActive(true);

        try
        {
            voiceScript.PlayBuildQueOpenVO((int)GameController.Instance().activePlayer.playerFaction.voice);
        }
        catch { }
    }

    public void CompletedConstructionMenu()
    {
        completedMenu.SetActive(true);
        currentMenu.SetActive(false);
    }
}
