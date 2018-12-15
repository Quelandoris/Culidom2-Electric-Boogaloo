using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {



    public Text tutorial;

    private int player1Step = -1, player2Step = -1, player3Step = -1, player4Step = -1;

    private int step = -1, currentPlayer = 1;

    public GameObject tutorialDisplayH, tutorialDisplayV, tutorialDisplaySquare, tutorialDisplayF, tutorial_GO;

    public Image tutorialImagesHorizontal;
    public Image tutorialImagesVertical;
    public Image tutorialImagesSquare;
    public Image tutorialImagesFlat;

    public FactionsUI factionsSetup;
    CameraMovement camera;

    public int activePlayers;


    public Sprite s_logo, s_vacantLot, s_restaurantManager, s_empireScreenButton, s_empireScreen, s_restaurantScreenButton, s_restaurantScreen,
        s_escapeButton, s_MenuButton, s_menuPanel, addDishPanel, s_adjustingPriceSlider, s_recipesTab, s_RecipeManagerPic, s_ingredientsTab, s_createRecipeButton,
        s_dishtab, s_dishBlueprint, s_ingredientDisplay, s_ingredientPanel, s_residentPanel, s_tierDisplay, s_SaveRecipeButton, s_SavedRecipesButton, s_staffPanel, s_chefPanel,
        s_constructionQueue, s_chefManagmentTab, s_chefManagerScreen, s_assignChefPanel, s_techTab, s_techTreeWindow, s_queueTech, s_resourceDisplay, IngredientPointDisplay, s_upgradingIngredients,
        s_constructionBuildButton, s_endTurnButton, s_satisfaction;

    void Awake()
    {
        factionsSetup = GetComponent<FactionsUI>();
        camera = FindObjectOfType<CameraMovement>();
    }

    void Update()
    {
        UpdateText();
        if (currentPlayer == 1)
        {
            step = player1Step;
        }
        else
        if (currentPlayer == 2)
        {
            step = player2Step;
        }
        else
        if (currentPlayer == 3)
        {
            step = player3Step;
        }
        else
         if (currentPlayer == 4)
        {
            step = player4Step;
        }
    }
    /*GetComponent<FactionsUI>().numPlayers == 2*/
    public void ChangePlayer()
    {
        //if there's 2 players
        if (activePlayers == 2)
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else if (currentPlayer == 2)
            {
                currentPlayer = 1;
            }
        }
        //if there's 3 players
        if (activePlayers == 3)
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else if (currentPlayer == 2)
            {
                currentPlayer = 3;
            }
            else if (currentPlayer == 3)
            {
                currentPlayer = 1;
            }
        }
        //If there's 4 players
        if (activePlayers == 4)
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else if (currentPlayer == 2)
            {
                currentPlayer = 3;
            }
            else if (currentPlayer == 3)
            {
                currentPlayer = 4;
            }
            else if (currentPlayer == 4)
            {
                currentPlayer = 1;
            }
        }
    }

    //Open and Closing the tutorial
    public void CloseTutorial()
    {
        tutorial_GO.SetActive(false);
        camera.tutorialOn = false;
    }

    public void OpenTutorial()
    {
        tutorial_GO.SetActive(true);
        camera.tutorialOn = true;
    }
    //Moves the tutorial Forward
    public void ForwardTutorial()
    {
        if (currentPlayer == 1)
        {
            player1Step++;
        }
        else if (currentPlayer == 2)
        {
            player2Step++;
        }
        else if (currentPlayer == 3)
        {
            player3Step++;
        }
        else if (currentPlayer == 4)
        {
            player4Step++;
        }
        Debug.Log("step + 1");
    }
    //Moves the tutorial Forward
    public void BackwardTutorial()
    {
        if (currentPlayer == 1)
        {
            player1Step--;
        }
        else if (currentPlayer == 2)
        {
            player2Step++;
        }
        else if (currentPlayer == 3)
        {
            player3Step++;
        }
        else if (currentPlayer == 4)
        {
            player4Step++;
        }
        Debug.Log("step - 1");
    }

    public void TwoPlayerGame()
    {
        activePlayers = 2;
    }
    public void ThreePlayerGame()
    {
        activePlayers = 3;
    }
    public void FourPlayerGame()
    {
        activePlayers = 4;
    }


    // Updates the text and images of the tutorial
    public void UpdateText()
    {
        if (step == -1)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_logo;
            tutorial.text = "Welcome to Culinary Domination, in this tutorial we'll teach you about the various mechanics that will build your culinary empire.";
        }
        if (step == 0)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_vacantLot;
            tutorial.text = "Before we do anything why don't we start by creating our first restaurant. Click on a vancant lot and select purchase.";
        }
        if (step == 1)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_empireScreenButton;
            tutorial.text = "Awesome! Now that we own a restaurant we can view it in the empire management screen by clicking the empire button.";
        }
        if (step == 2)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_restaurantScreenButton;
            tutorial.text = "In the empire screen we can manage our restaurant and chefs. For now let's go to the restaraunt manager";
        }
        if (step == 3)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_restaurantScreen;
            tutorial.text = "In the restaurant screen we can view and manage all of our restaurants.";
        }
        if (step == 4)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_escapeButton;
            tutorial.text = "Now let's close out of the empire screen and return to our restaurant.(Press (Esc) to close)";
        }
        if (step == 5)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_restaurantManager;
            tutorial.text = "Reselect your restaurant and you'll see in the UI there's a variety of tools that enable us to control our restaurant.";
        }
        if (step == 6)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_MenuButton;
            tutorial.text = "First we'll look at the menu button.";
        }
        if (step == 7)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_menuPanel;

            tutorial.text = "Here we have can choose to add or delete recipes that we've created.";
        }
        if (step == 8)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_recipesTab;
            tutorial.text = "To create a recipe first we'll have to go to the recipe manager by clicking on the recipe tab.";
        }
        if (step == 9)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_RecipeManagerPic;
            tutorial.text = "In the recipe manager we can view the different dishes and ingredients available to us.";
        }
        if (step == 10)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_createRecipeButton;
            tutorial.text = "To create a recipe we can click the (Create) button to take us to the recipe builder.";
        }
        if (step == 11)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_dishtab;
            tutorial.text = "First things first, lets select the type of dish we want to create";
        }
        if (step == 12)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialImagesSquare.sprite = s_dishBlueprint;
            tutorial.text = "Dishes act as a blueprint and determine what type of ingredient can be used.";
        }
        if (step == 13)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_ingredientDisplay;
            tutorial.text = "Now let's select an ingredient we want to customize.";
        }
        if (step == 14)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_ingredientPanel;
            tutorial.text = "Here we can view the different types of ingredients you own and what tiers you have.";
        }
        if (step == 15)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_residentPanel;
            tutorial.text = "In Culinary Domination different customers will have different prefrences in ingredients.(You can access this information by select a resident tile)";
        }
        if (step == 16)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_ingredientPanel;
            tutorial.text = "The ingredient determines how likely someone is to come to your restaurant";
        }
        if (step == 17)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_tierDisplay;
            tutorial.text = "Tiers determine how expensive and high quality a recipe is. Higher quality recipes lead to more customer satisfaction";
        }
        if (step == 18)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_tierDisplay;
            tutorial.text = "By default players start with only tier 1. More tiers can be unlocked with ingredient points in the recipe manager";
        }
        if (step == 19)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_SaveRecipeButton;
            tutorial.text = "Let's be sure to fill out all the ingredients, and name our new recipe then click save.";
        }
        if (step == 20)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_SavedRecipesButton;
            tutorial.text = "Now we can view the new recipe in the saved recipes panel. Let's go return to our restaurant and assign it";
        }
        if (step == 21)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_menuPanel;
            tutorial.text = "Return to the restaurant, click on the menu button, then we can view our menu panel.";
        }
        if (step == 22)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = addDishPanel;
            tutorial.text = "Next we can click the (add) button to open up the add dish panel. Now let's click on our new recipe.";
        }
        if (step == 23)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_adjustingPriceSlider;
            tutorial.text = "We can see that the recipe is assigned to this restaurant, now let's use the slider to adjust the price.";
        }
        if (step == 24)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_satisfaction;
            tutorial.text = "Higher prices will lead to less customer satisfaction, but leads to more money per customer. How the price is set is up to the player.";
        }
        if (step == 25)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_residentPanel;
            tutorial.text = "Customers will also have a factor to determine how much money they're willing to spend";
        }
        if (step == 26)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_staffPanel;
            tutorial.text = "Now we'll be learning about staff and chefs!";
        }
        if (step == 27)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_staffPanel;
            tutorial.text = "On the right we'll find the staff panel, here we can hire more staff to increase our restaurants production.";
        }
        if (step == 28)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_constructionQueue;
            tutorial.text = "Production determines how fast the restaurant's construction queue can build new upgrades.";
        }
        if (step == 29)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_staffPanel;
            tutorial.text = "More staff means more upkeep for the restaurant per turn. Players can sell and buy more staff as they please.";
        }
        if (step == 30)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_chefPanel;
            tutorial.text = "Now we'll learn about managing chefs.";
        }
        if (step == 31)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_chefPanel;
            tutorial.text = "If we click on the chef button next to the staff panel, we can bring up the chef panel.";
        }
        if (step == 32)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_chefPanel;
            tutorial.text = "Here we can see any chefs that've been assigned to the restaurant. As we can see we've yet to assign anyone.";
        }
        if (step == 33)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_empireScreenButton;
            tutorial.text = "To assign a chef let's return to the empire managment screen.";
        }
        if (step == 34)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_chefManagmentTab;
            tutorial.text = "Now we can go and select the chef tab to open the chef manager.";
        }
        if (step == 35)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_chefManagerScreen;
            tutorial.text = "Here we can see that we own four chefs by default. Each have their own name, level, and perk.";
        }
        if (step == 36)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_chefManagerScreen;
            tutorial.text = "Chefs offer bigger bonuses for the player, but have more upkeep.";
        }
        if (step == 37)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(true);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesVertical.sprite = s_assignChefPanel;
            tutorial.text = "Select the chef to bring up the assign chef panel. Then select the restaurant you wish to send him to.";
        }
        if (step == 38)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_techTreeWindow;
            tutorial.text = "Now that we've assigned our chef, lets go to the tech tree and begin researching upgrades.";
        }
        if (step == 39)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_techTab;
            tutorial.text = "Select the (Tech) tab to go to the tech tree.";
        }
        if (step == 40)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_techTreeWindow;
            tutorial.text = "In the tech tree we can research upgrades to construct for our restaurant.";
        }
        if (step == 41)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_techTreeWindow;
            tutorial.text = "There are three different trees.(Mexican,American,and Italian) Each have their own strengths and weaknesses";
        }
        if (step == 42)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_queueTech;
            tutorial.text = "To begin research, select a tech you want to invest in and click it to add it to the queue.";
        }
        if (step == 43)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_resourceDisplay;
            tutorial.text = "We can see it added to the queue. Research speed depends on how much science is being generated in the top left corner.";
        }
        if (step == 44)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_techTreeWindow;
            tutorial.text = "Once a research is complete the player unlock an upgrade for construction, as well as an ingredient point";
        }
        if (step == 45)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_upgradingIngredients;
            tutorial.text = "Ingredient points are utilized in the recipe manager to purchase new ingredients, and unlock new tiers";
        }
        if (step == 46)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(true);
            tutorialImagesHorizontal.sprite = s_restaurantManager;
            tutorial.text = "Now lets return to the restaurant and learn about the construction queue";
        }
        if (step == 47)
        {

            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_constructionBuildButton;
            tutorial.text = "To begin construction click the build button, we'll see a panel appear with potential upgrades.";
        }
        if (step == 48)
        {
            tutorialDisplayF.SetActive(false);
            tutorialDisplaySquare.SetActive(true);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesSquare.sprite = s_constructionQueue;
            tutorial.text = "Once we select an upgrade, we'll see it appear in the queue. Upgrades build after a certain amount of turns.";
        }
        if (step == 49)
        {
            tutorialDisplayF.SetActive(true);
            tutorialDisplaySquare.SetActive(false);
            tutorialDisplayV.gameObject.SetActive(false);
            tutorialDisplayH.gameObject.SetActive(false);
            tutorialImagesFlat.sprite = s_endTurnButton;
            tutorial.text = "Once we're done with our turn, we can head to begin EndTurn button to let the next player go.";
        }
    }
}
