using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapPortraits : MonoBehaviour {

    public Image portrait1, portrait2;
    public int currentPic = 1;
    public int numPortraits;

	void Start () {
        portrait1.sprite = GameController.Instance().activePlayer.playerFaction.playerPortrait;
        numPortraits = GameController.Instance().playerCount;
	}

    private void OnEnable()
    {
        GameController.Instance().swapPortraitScript = this;
    }

    public void SwitchThePictures() {
        Debug.Log("SwithThePanels method is being called in SwapPortraits");

        if (numPortraits == 2)
        {
            switch (currentPic)
            {
                case 1:
                    portrait2.sprite = GameController.Instance().player[1].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 2:
                    portrait1.sprite = GameController.Instance().player[0].playerFaction.playerPortrait;
                    currentPic++;
                    break;
            }

            if (currentPic > 2) {
                currentPic = 1;
            }
        }
        else if (numPortraits == 3)
        {
            switch (currentPic)
            {
                case 1:
                    portrait2.sprite = GameController.Instance().player[1].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 2:
                    portrait1.sprite = GameController.Instance().player[2].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 3:
                    portrait2.sprite = GameController.Instance().player[0].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 4:
                    portrait1.sprite = GameController.Instance().player[1].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 5:
                    portrait2.sprite = GameController.Instance().player[2].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 6:
                    portrait1.sprite = GameController.Instance().player[0].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                

            }

            if (currentPic > 6) {
                currentPic = 1;
            }
        }

        else if (numPortraits == 4) {

            switch (currentPic)
            {
                case 1:
                    portrait2.sprite = GameController.Instance().player[1].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 2:
                    portrait1.sprite = GameController.Instance().player[2].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 3:
                    portrait2.sprite = GameController.Instance().player[3].playerFaction.playerPortrait;
                    currentPic++;
                    break;
                case 4:
                    portrait1.sprite = GameController.Instance().player[0].playerFaction.playerPortrait;
                    currentPic++;
                    break;

            }

            if (currentPic > 4) {
                currentPic = 1;
            }
        }

        

    }
}
