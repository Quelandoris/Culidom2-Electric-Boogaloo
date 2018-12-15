using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDishPopulator : MonoBehaviour {

    public MenuButtons[] buttons;
    public RestaurantUI restaurantUI;
    BuildingRestaurant thisRest;

    private void OnEnable()
    {
        thisRest = restaurantUI.building;
        try
        {
            for (int i = 0; i < thisRest.recipes.Count; i++)
            {
                if (i == 3)
                {
                    break;
                }
                buttons[i].Setup(GameController.Instance().activePlayer.restaurantClicked.recipes[i]);
            }
        }
        catch { }
    }

    private void OnDisable()
    {
        for (int i = 0; i < buttons.Length; i++) {
            GameObject DishInfo = buttons[i].transform.Find("DishInfo").gameObject;
            DishInfo.SetActive(false);
            GameObject selectText = buttons[i].transform.Find("Text(SelectRecipe)").gameObject;
            selectText.SetActive(true);
        }
    }
}
