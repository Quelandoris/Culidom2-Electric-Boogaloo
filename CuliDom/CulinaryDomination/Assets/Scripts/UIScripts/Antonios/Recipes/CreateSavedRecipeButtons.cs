using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSavedRecipeButtons : MonoBehaviour {

    public RectTransform content;
    public Button buttonPrefab;
    public GameObject restaurantUI;

    DishButtonManager saveRecipeScript;
    GameController gameController;
    Recipe createSaveRecipe;
    public List<Recipe> listRecipes = new List<Recipe>();

    public void Awake()
    {
        gameController = GameController.Instance();
        saveRecipeScript = FindObjectOfType<DishButtonManager>();
    }

    public void Start()
    {
    
    }
    public void CreateAButton(Recipe recipe) {
        createSaveRecipe = recipe;
        listRecipes.Add(recipe);
        GameObject newButton = Instantiate(buttonPrefab.gameObject);
        newButton.transform.parent = content;
        content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y + 60);
        newButton.GetComponentInChildren<Text>().text = recipe.name;
        for (int i = 0; i < newButton.transform.childCount; i++) {
            Transform child = newButton.transform.GetChild(i);
            Image childImage = null;
            if ((childImage = child.GetComponent<Image>()) != null) {
                
                childImage.sprite = recipe.picture;
                break;
                
            }
        }
        newButton.transform.localScale = new Vector3(1, 1, 1);
    }

    public void CreateContent() {
        //Debug.Log("Checked Content Count of: " + gameController.activePlayer.savedRecipies.Count);
        try
        {
            for (int i = 0; i < gameController.activePlayer.savedRecipies.Count; i++)
            {
                GameObject newButton = Instantiate(buttonPrefab.gameObject);
                newButton.transform.parent = content;
                content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 20);
                newButton.GetComponentInChildren<Text>().text = gameController.activePlayer.savedRecipies[i].name;
                newButton.transform.GetChild(2).GetComponent<Image>().sprite = gameController.activePlayer.savedRecipies[i].picture;
                for (int j = 0; j < newButton.transform.childCount; j++)
                {
                    Transform child = newButton.transform.GetChild(j);
                    Image childImage = null;
                    if ((childImage = child.GetComponent<Image>()) != null)
                    {
                        childImage.sprite = gameController.activePlayer.savedRecipies[i].picture; 
                        break;
                        
                    }
                }
                newButton.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        catch { }
    }

    public void ClearContent() {

        int count = 0;
        GameObject[] destroyButtons;

        foreach (Transform childTransform in transform) {
            count++;
        }

        destroyButtons = new GameObject[count];
        count = 0;

        foreach (Transform childTransform in transform) {
            destroyButtons[count] = childTransform.gameObject;
            count++;
        }

        for (int i = 0; i < destroyButtons.Length; i++) {
            Destroy(destroyButtons[i]);
        }
    }

    public void CreateBuildingReferences() {
        Debug.Log("Checked Content Count of: " + gameController.activePlayer.savedRecipies.Count);
        for (int i = 0; i < gameController.activePlayer.savedRecipies.Count; i++) {
            GameObject newButton = Instantiate(buttonPrefab.gameObject);
            newButton.transform.parent = content;
            content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 20);
            newButton.GetComponentInChildren<Text>().text = gameController.activePlayer.savedRecipies[i].name;
            newButton.transform.localScale = new Vector3(1, 1, 1);
            MenuAddButton buttonScript= newButton.GetComponentInChildren<MenuAddButton>();
            BuildingRestaurant thisRestaurant = restaurantUI.GetComponent<RestaurantUI>().building;
            Debug.Log("UI null " + (restaurantUI == null).ToString());
            Debug.Log("building null " + (thisRestaurant == null).ToString());
            Debug.Log("recipe: " + gameController.activePlayer.savedRecipies[i] + " restaurant" + thisRestaurant);
            buttonScript.thisRecipe = gameController.activePlayer.savedRecipies[i];
            //Must fill the reference to the building restaurant
            buttonScript.thisRestaurant = thisRestaurant;
            
        }
    }

    public Recipe GetRecipe() {
        Debug.Log("Get recipe says recipe name is " + createSaveRecipe.name);
        return createSaveRecipe;
    }
}
