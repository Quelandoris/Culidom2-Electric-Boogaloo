using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMenuRecipes : MonoBehaviour {
    public RectTransform content;
    public GameObject menuButton;
    GameObject newButton;
    public GameObject resturnatPopMenu;

    BuildingRestaurant thisResturant;

    RestaurantRecipe createMenuRecipe;
    Recipe thisRecipe;

    public void CreateMenuButton(Button button, Recipe recipe) {
        bool addRecipe = true;
        thisRecipe = recipe;
        newButton = Instantiate(menuButton);
        newButton.transform.parent = content;
        content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 20);
        Debug.Log("Name of the recipe I have right now is (Create Menu Recipe) " + recipe.name);
        newButton.GetComponentInChildren<Text>().text = recipe.name;
        newButton.transform.localScale = new Vector3(1, 1, 1);
        RecipeCost recipeCost = newButton.gameObject.GetComponent<RecipeCost>();

        for (int i = 0; i < thisResturant.recipes.Count; i++) {
            if (thisResturant.recipes[i].recipe == recipe) {
                addRecipe = false;
                break;
            }
        }
        if (addRecipe)
        {
            thisResturant.AddRecipe(recipe);
        }
        Debug.Log("CreateMenuRecipes thisResturnat = " + thisResturant.GetInstanceID());
        thisResturant.recipeButtons.Add(newButton.gameObject);
        recipeCost.SetUp(thisRecipe, thisResturant);

    }

    //This is an attempt at repopulating the menu, not so successful
    //called for making the button only. Not adding a recipe to the restaurant
    public void CreateMenuButton(RestaurantRecipe rr) {
        GameObject b = Instantiate(menuButton);
        b.transform.parent = content;
        content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 40);
        Debug.Log("Name of the recipe I have right now is (Create Menu Recipe) " + rr.recipe.name);
        b.GetComponentInChildren<Text>().text = rr.recipe.name;
        b.transform.localScale = new Vector3(1, 1, 1);
        RecipeCost recipeCost = b.gameObject.GetComponent<RecipeCost>();
        thisResturant.recipeButtons.Add(b.gameObject);
        //recipeCost.SetUp(thisRecipe, thisResturant);
        recipeCost.SetUp(thisRecipe, thisResturant);
    }

    public void PopulateMenuButtons(RestaurantRecipe rr)
    {
        GameObject b = Instantiate(menuButton);
        b.transform.parent = content;
        content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 40);
        b.GetComponentInChildren<Text>().text = rr.recipe.name;
        b.transform.localScale = new Vector3(1, 1, 1);
        RecipeCost recipeCost = b.gameObject.GetComponent<RecipeCost>();
        recipeCost.SetUp(rr);
       
    }

    public void FillBuildingRestaurant() {
        thisResturant = resturnatPopMenu.GetComponent<RestaurantUI>().building;
    }

   // These get and set functions Might not be neccessary /////////////////////////////////////////////////////////////////////////////
    public Recipe GetRecipe() {
        return thisRecipe;
    }

    public RestaurantRecipe GetRestaurantRecipe() {
        return createMenuRecipe;
    }

    public void SetThisResturant(BuildingRestaurant restuant) {
        thisResturant = restuant;
    }

    public void PopulateMenu() {
        thisResturant = resturnatPopMenu.GetComponent<RestaurantUI>().building;
        foreach (RestaurantRecipe r in thisResturant.recipes) {
            PopulateMenuButtons(r);
            Debug.Log("Created a menu button");
        }
    }

    public void PopulateMenu(BuildingRestaurant rest) {
        foreach (RestaurantRecipe rr in rest.recipes) {
            CreateMenuButton(rr);
            Debug.Log("Created a menu button");
        }
    }

    public void ClearMenu(BuildingRestaurant rest) {
        foreach (Transform child in content) {
            Destroy(child.gameObject);
            Debug.Log("Destroyed child");
        }
       

        foreach (GameObject button in rest.recipeButtons) {
            Destroy(button);
            Debug.Log("Destroyed stuff");
        }
    }

    public void ClearMenu()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
            Debug.Log("Destroyed child");
        }
    }
}
