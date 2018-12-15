using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingChefs : MonoBehaviour
{
    Chef boughtChef;
    public RestaurantUI restaurantUI;
    public RectTransform content;
    public RectTransform empireContent;
    public GameObject chefInRestaurantPrefab;
    Button chefButton;

    ChefScrollView chefScrollScript;

    public void Awake()
    {
        chefScrollScript = empireContent.GetComponent<ChefScrollView>();
    }




    public void BuyChef(GameObject chefButton)
    {
        BuildingRestaurant selectedRestaurant = restaurantUI.building;
        Chef selectedChef = chefButton.GetComponent<Chef>();

        if (selectedChef.GetChefCost() < GameController.Instance().activePlayer.GetMoney())
        {
            if (selectedRestaurant.chefs.Count < 3)
            {
                selectedRestaurant.AddChef(selectedChef); // adds chef to BuildingRestaurant
                GameController.Instance().activePlayer.AddChef(selectedChef); // adds chef to activePlaeyr PlayerData
                chefScrollScript.AddAChefButton(selectedChef); // Gives the chef to the Empire Screen
                GameObject newButtonPrefab = Instantiate(chefInRestaurantPrefab);
                selectedRestaurant.chefButtons.Add(newButtonPrefab); // Adds chefButton to BuildingRestaurant
                newButtonPrefab.transform.SetParent(content);
                newButtonPrefab.transform.localScale = new Vector3(1f, 1f, 1f);
                Chef chefInRestButton = newButtonPrefab.GetComponent<Chef>(); // Hopefully copying over Chef info to the other chef

                chefInRestButton.SetName(selectedChef.GetName());
                chefInRestButton.SetLevel(selectedChef.GetChefLevel());
                chefInRestButton.SetType(selectedChef.GetChefType());
                chefInRestButton.SetCost(selectedChef.GetChefCost());
                chefInRestButton.SetXP(selectedChef.GetChefXP());
                chefInRestButton.UpdateChefText();

                Destroy(chefButton.GetComponent<Chef>());
                chefButton.AddComponent<Chef>();
                Chef newCreatedChef = chefButton.GetComponent<Chef>();
                newCreatedChef.UpdateChefText();
                // selectedChef.ResetChef();

            }
            else
            {
                Debug.Log("There are too many chefs at the restaurant");
            }
        }
        else
        {
            Debug.Log("You dont have enough money for this chef");
        }
    }


}
