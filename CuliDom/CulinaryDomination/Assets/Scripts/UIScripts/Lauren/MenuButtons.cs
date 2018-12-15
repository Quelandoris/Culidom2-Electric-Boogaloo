using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    public int recipeIndex;
    public RecipeCost rCost;
    public RecipeCreationInfo creationInfo;


    public void Setup()
    {
        rCost.SetUp(GameController.Instance().activePlayer.restaurantClicked.recipes[recipeIndex]);
    }
    public void Setup(RestaurantRecipe rr) {
        rCost.SetUp(rr);
    }

    public void PrepareRecipeSlot()
    {
        creationInfo.replacementButton = this;
        if (GameController.Instance().activePlayer.restaurantClicked.recipes.Count > recipeIndex)
        {
            //GameController.Instance().activePlayer.restaurantClicked.recipes[recipeIndex].recipe.name += "<current>";
        }

    }

    public void Update()
    {
        if (rCost.isSetup)
        {
            rCost.UpdateText();
        }
    }
}
