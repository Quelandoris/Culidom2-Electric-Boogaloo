using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAddButton : MonoBehaviour {

    public Recipe thisRecipe;
    public BuildingRestaurant thisRestaurant;
    Button button;
    CreateMenuRecipes createMenuRecipeScript;
    CreateSavedRecipeButtons savedRecipeScript;

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
        createMenuRecipeScript = FindObjectOfType<CreateMenuRecipes>();
	}

    //Players menus are kept between players, they share one.
    //This only happens once
    public void OnClick() {
        bool addRecipe = true;
        for (int i = 0; i < thisRestaurant.recipes.Count; i++)
        {
            if (thisRestaurant.recipes[i].recipe == thisRecipe) {
                addRecipe = false;
            }

        }

        if (addRecipe) { 
            thisRestaurant.recipes.Add(new RestaurantRecipe(thisRecipe));
        }

        savedRecipeScript = gameObject.GetComponentInParent<CreateSavedRecipeButtons>();
        Debug.Log("Name of the recipe I have right now is (Menu Add Button) " + thisRecipe.name);
        createMenuRecipeScript.FillBuildingRestaurant();                                        // Fills reference of Building Restruant
        if (addRecipe)
        {
            createMenuRecipeScript.CreateMenuButton(button, thisRecipe);                         // Creates the button and then adds it to the list of buttons and recipes 
        }
        RecipeCost recipe = new RecipeCost();

    }

}
