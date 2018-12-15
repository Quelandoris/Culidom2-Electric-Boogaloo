using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalRecipes : MonoBehaviour {

    GameController gameController;
    RecipieManagerPanel recipieManagerScript;
    DishButtonManager saveRecipeScript;
    string name;
    string dairyString, proteinString, starchString, sauceString, miscString;

    Recipe recipeToLoad;

    private void Awake()
    {
        recipieManagerScript = FindObjectOfType<RecipieManagerPanel>();
        saveRecipeScript = FindObjectOfType<DishButtonManager>();
        //int count = GetComponentInParent<CreateSavedRecipeButtons>().listRecipes.Count -1;
        //recipeToLoad = GetComponentInParent<CreateSavedRecipeButtons>().listRecipes[count];
    }

    public void OnClick() {/*
        recipieManagerScript.SwitchPanelUpdateRecipe();
        CreateSavedRecipeButtons savedRecipes = GetComponentInParent<CreateSavedRecipeButtons>();
        for (int i = 0; i < savedRecipes.listRecipes.Count; i++) {
            if (recipeToLoad == savedRecipes.listRecipes[i]) {
                // Call Dishbutton manager method to recreate this recipe. With all the ingredients created 
            }
        }
        */
    }

    public void Start()
    {
        gameController = GameController.Instance();
        name = GetComponentInChildren<Text>().text;
    }

    public void DeleteRecipe()
    {
        GameController.Instance().activePlayer.savedRecipies.Remove(GameController.Instance().activePlayer.savedRecipies.Find(r => r.name == name));
        Destroy(this.gameObject);
    }


}
