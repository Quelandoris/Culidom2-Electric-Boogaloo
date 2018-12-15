using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateScrollView : MonoBehaviour {

    public GameObject restaurantInfoPrefab, chefInfoPrefab, recipeInfoPrefab;

    public Text chefName, chefType, chefLevel, chefLocation, chefCost;
    public Text buildingName, buildingDistrict, buldingProfit, buildingScience, buildingUpkeep, buildingWorkers;
    public Image satisfaction;

    public void CreateRestaurantContent(RectTransform content)
    {
        for (int i = 0; i < GameController.Instance().activePlayer.ownedRestaurants.Count; i++)
        {
            GameObject newRestaurant = Instantiate(restaurantInfoPrefab);
            newRestaurant.transform.SetParent(content);
            //content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y + 60);
            newRestaurant.transform.localScale = new Vector3(1.42f, 1.42f, 1.42f);
            BuildingRestaurantButton newRestaurantInfo = newRestaurant.GetComponent<BuildingRestaurantButton>();

            //BuildingRestaurantButton buildingReference = newRestaurant.GetComponent<BuildingRestaurantButton>();
    
            newRestaurantInfo.buildingName = GameController.Instance().activePlayer.ownedRestaurants[i].name;
            //buildingDistrict.text = GameController.Instance().activePlayer.ownedRestaurants[i].name; // need a reference to the district rest is in
            newRestaurantInfo.buildingEstimatedProfit = GameController.Instance().activePlayer.ownedRestaurants[i].CalculateTurnRevenueWithouUpkeep().ToString("F2");
            newRestaurantInfo.buildingEstimatedScience = GameController.Instance().activePlayer.ownedRestaurants[i].GetTechRate().ToString();
            //buildingReference.buildingSatisfaction = GameController.Instance().activePlayer.ownedRestaurants[i].GetRating().ToString("F1");
            newRestaurantInfo.buildingSatisfaction = Mathf.Round((float)GameController.Instance().activePlayer.ownedRestaurants[i].GetRating()) / 10;
            //buildingReference.buildingTurnsTillUpgrade = GameController.Instance().activePlayer.ownedRestaurants[i].name;// how long upgrade will be in queue
            newRestaurantInfo.buildingTotalUpkeep = GameController.Instance().activePlayer.ownedRestaurants[i].CalculateUpkeep().ToString("F2");
            newRestaurantInfo.buildingWorkers = GameController.Instance().activePlayer.ownedRestaurants[i].staff.ToString();
            newRestaurantInfo.UpdateText();

        }
    }

    /*public void CreateChefContent(RectTransform content)
    {
        for (int i = 0; i < GameController.Instance().activePlayer.ownedChefs.Count; i++)
        {
            GameObject newChef = Instantiate(chefInfoPrefab);
            newChef.transform.SetParent(content);
            content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 60);
            newChef.transform.localScale = new Vector3(1f, 1f, 1f);

            newChef.GetComponent<ChefScript>().chefClass = GameController.Instance().activePlayer.ownedChefs[i];

            chefName.text = GameController.Instance().activePlayer.ownedChefs[i].chefName;
            chefType.text = GameController.Instance().activePlayer.ownedChefs[i].chefType.ToString();
            chefLevel.text = GameController.Instance().activePlayer.ownedChefs[i].chefRank.ToString();
            chefCost.text = GameController.Instance().activePlayer.ownedChefs[i].chefCost.ToString();
            chefLocation.text = GameController.Instance().activePlayer.ownedChefs[i].myRestaurant.name;
        }
    }*/

    public void CreateSavedRecipeContent(RectTransform content)
    {
        for (int i = 0; i < GameController.Instance().activePlayer.savedRecipies.Count; i++)
        {
            GameObject savedRecipe = Instantiate(recipeInfoPrefab);
            savedRecipe.transform.parent = content;
            //content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 20);
            savedRecipe.GetComponentInChildren<Text>().text = GameController.Instance().activePlayer.savedRecipies[i].name;
            savedRecipe.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void DeleteContent(RectTransform content)
    {
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


    }
}
