using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerInfo : MonoBehaviour {

    public Text playerNumber, roundNumber, playerMoney, playerScience;

    GameController gameController;

    private void Awake()
    {
        gameController = GameController.Instance();
    }

    public void UINewTurn ()
    {
        playerNumber.text = gameController.GetPlayerNumber().ToString();
        playerMoney.text = Mathf.Floor((float)gameController.activePlayer.GetMoney()).ToString();
        roundNumber.text = GameController.Instance().GetRoundNumber().ToString();
        playerScience.text = gameController.activePlayer.GetTechPointRate().ToString();
    }
}
