using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VacantUI : MonoBehaviour {

    public GameObject MexRestaurantFab;
    public Text nameText;
    public Text costText;
    public Button buyButton;
    int cost = int.MaxValue;
    GameController gameController;
    PlayerData player;
    public BuildingVacant building;


    CameraMovement cameraScript;

    private void Awake()
    {
        gameController = GameController.Instance();
        //replaced player with gameController.activePlayer
        //player = gameController.activePlayer;
        cameraScript = FindObjectOfType<CameraMovement>();
    }

    void OnGUI()
    {
        buyButton.interactable = (gameController.activePlayer.GetMoney() >= cost);
    }

    public void FillFields(string name, int cost)
    {
        this.cost = cost;
        nameText.text = name;
        costText.text = "Price: " + cost;
    }

    //function should be pointless now
    public void Buy()
    {
        if (gameController.activePlayer.GetMoney() >= cost)
        {
            cameraScript.TurnCanMoveTrue();
            try
            {
                //Moved Building.Buy to below this (it was here) Because it destroys this script and ends the function
                gameController.activePlayer.AddMoney(-cost);
                // Play succesful purchase sound
                cameraScript.TurnCanMoveTrue(); //might be unnecessary
                building.Buy(MexRestaurantFab);
            }
            catch { }
        }
        else {
            // play unsuccesful purchase sound
        }
    }

    public int GetCost() {
        return cost;
    }
}
