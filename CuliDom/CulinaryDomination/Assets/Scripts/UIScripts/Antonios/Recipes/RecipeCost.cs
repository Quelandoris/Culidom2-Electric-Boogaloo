using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCost : MonoBehaviour {

    public bool isSetup = false;
    Recipe thisRecipe;
    RestaurantRecipe thisRR;
    BuildingRestaurant thisRestruant;

    RestaurantUI restUIScript;
    public GameObject resturantPopupMenu;
    public Slider costSlider;
    public Text nameText, costText, proftText, multiplierText;
    public Image picture;

    GameObject window;

    //double sliderValue = 0.0;

    public void Start()
    {
        // restUIScript = FindObjectOfType<RestaurantUI>();  // not geting a reference?
        restUIScript = GameObject.FindWithTag("RestUI").GetComponent<RestaurantUI>();
        
        

    }

    public void SetUp(Recipe recipe, BuildingRestaurant building)
    {
        isSetup = true;
        Debug.Log("RecipeCost building = " + building.GetInstanceID());
        thisRecipe = recipe;
        thisRestruant = building;
        Debug.Log("Recipe cost says that this resturANT has " + building.recipes.Count + " resturnat recipes");
        for (int i = 0; i < building.recipes.Count; i++) {
            if (thisRecipe == building.recipes[i].recipe) {
                thisRR = building.recipes[i];
                break;
            }
        }

        costSlider.value = 1;
        UpdateText();
        Debug.Log("Restaurant from PlayerData " + GameController.Instance().activePlayer.restaurantClicked.GetInstanceID());
    }

    public void SetUp(RestaurantRecipe rr)
    {
        isSetup = true;
        thisRecipe = rr.recipe;
        thisRR = rr;
        thisRestruant = GameController.Instance().activePlayer.restaurantClicked;
        costSlider.value = rr.multiplier;
        UpdateText();
    }
    

    public void SliderChange() {
        if (costSlider.value != thisRR.multiplier)
        {
            thisRestruant = GameController.Instance().activePlayer.restaurantClicked;
            Debug.Log("The slider value we just changes it to is " + costSlider.value);
            double sliderValue = (double)costSlider.value;
            thisRR.ChangeRecipeCost(sliderValue);
            UpdateText();
        }
        else {
            Debug.Log("Cost slider and ResturantRecipe multiplier value the same");
        }
    }

    public void UpdateText() {
        nameText.text = (thisRecipe != null) ? thisRecipe.name : "";
        costText.text = (thisRecipe != null) ? "Cost: $" + thisRR.manufacturingCost.ToString("F2"): "";
        proftText.text = (thisRecipe != null) ? "Profit: $" + thisRR.sellingPrice.ToString("F2"): "";
        Debug.Log(thisRR.sellingPrice + " _____ " + thisRR.profit);
        multiplierText.text = (thisRecipe != null) ? (costSlider.value).ToString(): "";
        picture.sprite = thisRecipe.picture;
        //costSlider.value = (float)sliderValue;
    }

   


}
