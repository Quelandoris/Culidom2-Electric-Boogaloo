using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionQueue : MonoBehaviour
{

    public static List<ConstructionQueue> queueButtons = new List<ConstructionQueue>();
    public Dictionary<BuildingRestaurant, GameObject> parentLookup;
    public Dictionary<BuildingRestaurant, int> countdownLookup;
    public string upgradeName;
    public int numTurns;
    public GameObject availableMenu;
    public GameObject inProgress;
    public GameObject completed;
    public Text remainingTurns;

    private void Start()
    {
        queueButtons.Add(this);
        parentLookup = new Dictionary<BuildingRestaurant, GameObject>();
        countdownLookup = new Dictionary<BuildingRestaurant, int>();
        transform.parent = availableMenu.transform;
    }

    private void Update()
    {
        if (GameController.Instance().activePlayer.restaurantClicked != null)
        {
            if (!parentLookup.ContainsKey(GameController.Instance().activePlayer.restaurantClicked))
            {
                transform.parent = availableMenu.transform;
                parentLookup.Add(GameController.Instance().activePlayer.restaurantClicked, transform.parent.gameObject);
            }
            else
            {
                transform.parent = parentLookup[GameController.Instance().activePlayer.restaurantClicked].transform;
            }
            if (countdownLookup.ContainsKey(GameController.Instance().activePlayer.restaurantClicked))
            {
                remainingTurns.text = upgradeName + ":\t\t" + countdownLookup[GameController.Instance().activePlayer.restaurantClicked].ToString() + " Turn(s)";
            }
            else
            {
                remainingTurns.text = upgradeName + ":\t" + numTurns.ToString() + " Turn(s)";
            }
        }
        else
        {
            transform.parent = availableMenu.transform;
            remainingTurns.text = upgradeName + ":\t" + numTurns.ToString() + " Turn(s)";
        }
    }

    public void EndPlayerTurn()
    {
        queueButtons.ForEach(b => b.UpdateCountdown());
    }

    public void UpdateCountdown()
    {
        List<BuildingRestaurant> allKeys = new List<BuildingRestaurant>();
        foreach (KeyValuePair<BuildingRestaurant, int> entry in countdownLookup)
        {
            allKeys.Add(entry.Key);
        }
        allKeys.ForEach(k =>
        {
            if (GameController.Instance().activePlayer.HaveRestaurant(k))
            {
                countdownLookup[k] = Mathf.Clamp(countdownLookup[k] - 1, 0, numTurns);
                if (countdownLookup[k] == 0)
                {
                    Completed(k);
                }
            }
        });
    }

    public void BeginConstruction ()
    {
        if (!countdownLookup.ContainsKey(GameController.Instance().activePlayer.restaurantClicked))
        {
            parentLookup[GameController.Instance().activePlayer.restaurantClicked] = inProgress;
            countdownLookup.Add(GameController.Instance().activePlayer.restaurantClicked, numTurns);
        }
    }

    void Completed (BuildingRestaurant r)
    {
        parentLookup[r] = completed;
    }
}
