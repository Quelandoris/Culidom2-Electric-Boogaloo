using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateADish : MonoBehaviour {

    DishData currentDish;
    RecipeScreenInfo recipeScreenScript;
    public GameObject recipeCreationScreen;
    public GameObject recipeManagerScreen;

    public Text foodType;
    public Image foodImage;
    public InputField inputText;
    public Sprite burgerSprite, chiliSprite, gumboSprite, qeusadillaSprite, enchiladaSprite, tacoSprite, spaghettiSprite, pizzaSprite, paniniSprite;

    private void Awake()
    {
        recipeScreenScript = recipeCreationScreen.GetComponent<RecipeScreenInfo>();
    }


    public void CreateThisDish(string dishType)
    {
        switch (dishType)
        {
            
            case "burger":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.AMERICAN)
                {
                    foodType.text = "Burger";
                    foodImage.sprite = burgerSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
            break;
        
            case "gumbo":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.AMERICAN)
                {
                    foodType.text = "Gumbo";
                    foodImage.sprite = gumboSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
            case "chili":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.AMERICAN)
                {
                    foodType.text = "Chili";
                    foodImage.sprite = chiliSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
            case "quesadilla":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.MEXICAN)
                {
                    foodType.text = "Quesadilla";
                    foodImage.sprite = qeusadillaSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
            case "enchilada":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.MEXICAN)
                {
                    foodType.text = "Enchillada";
                    foodImage.sprite = enchiladaSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
            case "taco":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.MEXICAN)
                {
                    foodType.text = "Taco";
                    foodImage.sprite = tacoSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
            case "spaghetti":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.ITALIAN)
                {
                    foodType.text = "Spaghetti";
                    foodImage.sprite = spaghettiSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
            case "pizza":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.ITALIAN)
                {
                    foodType.text = "Pizza";
                    foodImage.sprite = pizzaSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
            case "panini":
                if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.ITALIAN)
                {
                    foodType.text = "Panini";
                    foodImage.sprite = paniniSprite;
                    inputText.text = "";

                    recipeCreationScreen.SetActive(true);
                    recipeManagerScreen.SetActive(false);
                }
                break;
        }
    }
}
