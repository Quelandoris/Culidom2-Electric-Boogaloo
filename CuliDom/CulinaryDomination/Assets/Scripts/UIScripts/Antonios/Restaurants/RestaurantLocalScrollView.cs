using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantLocalScrollView : MonoBehaviour {

    public GameObject restauratButtonPrefab;
    public RectTransform content;


    /*public void CreateContent() {

        for (int i = 0; i < GameController.Instance().activePlayer.ownedRestaurants.Count; i++) {
            GameObject newRestaurantButton = Instantiate(restauratButtonPrefab);
            newRestaurantButton.transform.SetParent(content);
            if (content == null)
            {
                Debug.Log("Is null");
            }
            else {
                Debug.Log("Is not null");
            }
            content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y + 60);
            newRestaurantButton.transform.localScale = new Vector3(1f, 1f, 1f);

            BuildingRestaurantButton buildingReference = newRestaurantButton.GetComponent<BuildingRestaurantButton>();
            // just getting the name of the restaurant
            buildingReference.buildingName = GameController.Instance().activePlayer.ownedRestaurants[i].name; 
            buildingReference.buildingDistrict = GameController.Instance().activePlayer.ownedRestaurants[i].name; // need a reference to the district rest is in
            // Calculated the Turn Revenue, this is without Upkeep
            buildingReference.buildingEstimatedProfit = GameController.Instance().activePlayer.ownedRestaurants[i].CalculateTurnRevenueWithouUpkeep().ToString("F2"); 
            // Got the amount of tech the rest has
            buildingReference.buildingEstimatedScience = GameController.Instance().activePlayer.ownedRestaurants[i].GetTechRate().ToString(); 
            // called GetRating, to get the rating in a numerical way
            buildingReference.buildingSatisfaction = GameController.Instance().activePlayer.ownedRestaurants[i].GetRating().ToString("F1");
            // Might be wrong but looked at the last upgrade that the restaurant has
           // buildingReference.buildingUpgrade = GameController.Instance().activePlayer.ownedRestaurants[i].GetTechUpgrades()[GameController.Instance().activePlayer.ownedRestaurants[i].GetTechUpgrades().Count - 1].ToString();
            buildingReference.buildingTurnsTillUpgrade = GameController.Instance().activePlayer.ownedRestaurants[i].name;// how long upgrade will be in queue
            // ran the method to get the upkeep
            buildingReference.buildingTotalUpkeep = GameController.Instance().activePlayer.ownedRestaurants[i].CalculateUpkeep().ToString("F2");
            buildingReference.buildingWorkers = GameController.Instance().activePlayer.ownedRestaurants[i].staff.ToString();
            buildingReference.UpdateText();

        }

    }

    public void DeleteContent() {
        int count = 0;
        GameObject[] destroyThese;
        if (content.transform.childCount > 0)
        {
            foreach (Transform childTransform in content.transform)
            {
                count++;
            }
            destroyThese = new GameObject[count];
            count = 0;

            foreach (Transform childTransform in content.transform)
            {
                destroyThese[count] = childTransform.gameObject;
            }

            for (int i = 0; i < destroyThese.Length; i++)
            {
                Destroy(destroyThese[i]);
            }
        }

        // probaly should also delete the amount I am adding to the size delta


    }*/
}
