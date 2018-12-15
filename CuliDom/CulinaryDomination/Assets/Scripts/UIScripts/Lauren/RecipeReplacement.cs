using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeReplacement : MonoBehaviour {

    public Recipe replacementRecipe;
    public MenuButtons replacementButton;

    public void ReplaceRecipe()
    {
        if (GameController.Instance().activePlayer.restaurantClicked.recipes.Count > replacementButton.recipeIndex)
        {
            GameController.Instance().activePlayer.restaurantClicked.recipes[replacementButton.recipeIndex] = new RestaurantRecipe(replacementRecipe);
        }
        else
        {
            GameController.Instance().activePlayer.restaurantClicked.recipes.Add(new RestaurantRecipe(replacementRecipe));
        }

        GameController.Instance().activePlayer.restaurantClicked.recipes[replacementButton.recipeIndex].recipe.name = GameController.Instance().activePlayer.restaurantClicked.recipes[replacementButton.recipeIndex].recipe.name.Replace("<current>", "");
        replacementButton.Setup();
        MainNavigation.instance.ClosePopupMenus();
    }
}
