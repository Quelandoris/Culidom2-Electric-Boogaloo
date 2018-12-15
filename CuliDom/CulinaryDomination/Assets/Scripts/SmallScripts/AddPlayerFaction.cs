using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayerFaction : MonoBehaviour {

    string[] characterName;
    int playerNum;
    Image portrait;

	// Use this for initialization
	void Start () {
        characterName = this.name.Split(' ');
        playerNum = int.Parse(characterName[1]);
        portrait = this.gameObject.GetComponent<Image>();

        switch (playerNum) {
            case 0:
                portrait.sprite = GameController.Instance().player[playerNum].playerFaction.playerPortrait;
                break;
            case 1:
                portrait.sprite = GameController.Instance().player[playerNum].playerFaction.playerPortrait;
                break;
            case 2:
                portrait.sprite = GameController.Instance().player[playerNum].playerFaction.playerPortrait;
                break;
            case 3:
                portrait.sprite = GameController.Instance().player[playerNum].playerFaction.playerPortrait;
                break;
            case 4:
                portrait.sprite = GameController.Instance().player[playerNum].playerFaction.playerPortrait;
                break;
            
        }
	}
}
