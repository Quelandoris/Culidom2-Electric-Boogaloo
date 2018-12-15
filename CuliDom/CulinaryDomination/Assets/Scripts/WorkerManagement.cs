using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerManagement : MonoBehaviour
{

    public Text staffAmount;
    public Text staffUpkeep;

    private void Update()
    {
        staffAmount.text = GameController.Instance().activePlayer.restaurantClicked.staff.ToString();
        staffUpkeep.text = "Upkeep: " + (GameController.Instance().activePlayer.restaurantClicked.staff * GameController.Instance().activePlayer.restaurantClicked.staffCost).ToString();
    }

    public void BuyWorkers()
    {
        GameController.Instance().activePlayer.restaurantClicked.BuyStaff();
    }

    public void SellWorkers()
    {
        if (GameController.Instance().activePlayer.restaurantClicked.staff > 0)
        {
            GameController.Instance().activePlayer.restaurantClicked.SellStaff();
        }
    }
}
