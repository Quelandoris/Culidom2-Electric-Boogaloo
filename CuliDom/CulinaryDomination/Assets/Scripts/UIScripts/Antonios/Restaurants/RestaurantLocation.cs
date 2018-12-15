using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantLocation : MonoBehaviour {

    public BuildingRestaurant thisRestaurant = null;
   // public ChefScrollView chefScrollView;
    Chef addChef;
    bool isFilled = false;
    GameController gameController;

    public Text restaurantName;

    public void Awake()
    {
        gameController = GameController.Instance();
    }

    public void Update()
    {
        if (!isFilled) {
            for (int i = 0; i < gameController.activePlayer.ownedRestaurants.Count; i++) {
                if (gameController.activePlayer.ownedRestaurants[i].onChefScreen)
                {
                    continue;
                }
                else {
                    gameController.activePlayer.ownedRestaurants[i].onChefScreen = true;
                    thisRestaurant = gameController.activePlayer.ownedRestaurants[i];
                    restaurantName.text = gameController.activePlayer.ownedRestaurants[i].name;
                    isFilled = true;
                    // Only have 1 RestaurantLocal Button in the chef Manager, once it has been filled
                    // Instantiate another one in the Scroll View
                    break;
                }
            }
            UpdateText();
        }
    }

    public void UpdateText() {
        restaurantName.text = thisRestaurant.name;
    }

}
