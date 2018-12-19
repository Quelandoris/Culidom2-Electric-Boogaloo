using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTreePanel : MonoBehaviour {

    public GameObject italTechTreem, amerTechTree, mexTechTree, americanName, mexicanName, italianName;

    public void OnEnable()
    {
        if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.AMERICAN) {
            TurnOff();
            amerTechTree.SetActive(true);
            americanName.SetActive(true);
        } else if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.ITALIAN) {
            TurnOff();
            italianName.SetActive(false);
            italTechTreem.SetActive(false);
        } else if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.MEXICAN) {
            TurnOff();
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
