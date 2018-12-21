using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTreePanel : MonoBehaviour {

    public GameObject italTechTreem, amerTechTree, mexTechTree, americanName, mexicanName, italianName;

    public void OnEnable()
    {
        if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.AMERICAN) {
            TurnOff();
            Debug.Log("An american is turning on the tech tree");
            amerTechTree.SetActive(true);
            americanName.SetActive(true);
        } else if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.ITALIAN) {
            TurnOff();
            Debug.Log("An italian is turning on the tech tree");
            italianName.SetActive(false);
            italTechTreem.SetActive(false);
        } else if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.MEXICAN) {
            TurnOff();
            Debug.Log("An mexican is turning on the tech tree");
            mexicanName.SetActive(false);
            mexTechTree.SetActive(false);
        }
    }

    void TurnOff() {
        italianName.SetActive(false);
        italTechTreem.SetActive(false);
        mexicanName.SetActive(false);
        mexTechTree.SetActive(false);
        americanName.SetActive(false);
        amerTechTree.SetActive(false);
    }
}
