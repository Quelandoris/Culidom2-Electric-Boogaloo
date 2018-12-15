using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeRecipeButton : MonoBehaviour {

	public void ClearRecipeNameMod()
    {
        foreach(RestaurantRecipe r in GameController.Instance().activePlayer.restaurantClicked.recipes)
        {
            r.recipe.name = r.recipe.name.Replace("<current>", "");
        }
    }
}
