using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameController gameController;
    public UIController mainUI;

    [SerializeField]
    private int playerStartingTechPointRate;
    [SerializeField]
    private double playerStartingMoney;

    private void Awake() {
        gameController = GameController.Instance();
    }

    public double SetPlayerStartingMoney()
    {
        return playerStartingMoney;
    }

    public int SetPlayerStartingTechPointRate() {
        return playerStartingTechPointRate;
    }

    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            try
            {
                mainUI.AddTechPoints(gameController.activePlayer.GetTechPointRate());
            }
            catch { }
        }
    }

    public double GetMoney()
    {
        return gameController.activePlayer.GetMoney();
    }
}
