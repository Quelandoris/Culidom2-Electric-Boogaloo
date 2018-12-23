using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{



    public Text tutorial;

    private int player1Step = -6, player2Step = -6, player3Step = -6, player4Step = -6;

    private int step = -6, currentPlayer = 1;

    public GameObject tutorialDisplayH, tutorial_GO;

    public Image tutorialImagesHorizontal;

    public FactionsUI factionsSetup;
    CameraMovement camera;

    public int activePlayers;


    public Sprite s_logo, s_vacantLot, s_districtPanel, s_districtBoarders, s_wholeMap, s_threeRestaurants, empireTabButton,
        s_empireManager, s_chefScreenManager, s_restaurantManager, s_satisfactionDisplay, s_staffManager, s_chefManager, s_constructionque,
        s_menuWindow, s_addDishWindow, s_recipeSlider, s_techTree, s_savedRecipes, s_createRecipe, s_ingredientScreen,
        s_upgradeIngredientButton, s_ingredientCatagoryTabs, s_questionMarkButton;

    public Sprite s_money_science, s_resourceDisplay, s_closeButton, s_ownedRestaurant, s_ChefmanagerTab, s_recipesTab, s_recipeScreen, s_createScreen,
        s_ingredientSlot, s_ingredientsMenu, s_ingredientsScreen, s_techTab, s_winnerScreen;

    void Awake()
    {
        step = -6;
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
        if (step == -6)
        {

            tutorialImagesHorizontal.sprite = s_logo;
            tutorial.text = "Welcome to Culinary Domination! In this tutorial we'll teach you about the various mechanics that will build your culinary empire.";
        }
        if (step == -5)
        {

            tutorialImagesHorizontal.sprite = s_resourceDisplay;
            tutorial.text = "First lets look at our resources in the top left corner. In culinary domination there are two global resources. Money and Science.";
        }
        if (step == -4)
        {

            tutorialImagesHorizontal.sprite = s_money_science;
            tutorial.text = "Money is used for purchasing new restaurants and creating new expensive recipes. Science is used for researching new techs. More money is gained at the beginning of each turn. Science can be upgraded but how much science you have is how much is being used for research for each turn;";
        }
        if (step == -3)
        {

            tutorialImagesHorizontal.sprite = s_districtBoarders;
            tutorial.text = "Now let's have a look at the map. The map is divided into different counties and districts indicated by the colored borders.";
        }
        if (step == -2)
        {

            tutorialImagesHorizontal.sprite = s_districtPanel;
            tutorial.text = "Clicking on the map will open up the district window displaying various information regarding the district. It displays the customers preferences, incomes, and ingredient likes and dislikes.";
        }
        if (step == -1)
        {

            tutorialImagesHorizontal.sprite = s_districtPanel;
            tutorial.text = "Districts also determine where customers are more likely to go based the distance of the restaurant to the district. Ingredient preferences are also important, customers are more likely to go to restaurant if they see an ingredient they prefer.";
        }
        if (step == 0)
        {

            tutorialImagesHorizontal.sprite = s_vacantLot;
            tutorial.text = "Now why don't we start by creating our first restaurant. Click on a vacant lot and select (Start Bidding)";
        }
        if (step == 1)
        {

            tutorialImagesHorizontal.sprite = s_ownedRestaurant;
            tutorial.text = "After bidding, the winner owns that vacant plot and has created their very own restaurant";
        }
        if (step == 2)
        {

            tutorialImagesHorizontal.sprite = empireTabButton;
            tutorial.text = "If the player owns any restaurants, they can view all the restaurants they own in the empire managment screen. To access this screen click on the empire tab in the top left corner.(The Crown)";
        }
        if (step == 3)
        {

            tutorialImagesHorizontal.sprite = s_empireManager;
            tutorial.text = "The empire screen is where players can manage all their restaurants and chefs.";
        }
        if (step == 4)
        {

            tutorialImagesHorizontal.sprite = s_empireManager;
            tutorial.text = "If a player clicks on the restaurant displayed in the manager, then the game will take the player straight to the restaurant on the map.";
        }
        if (step == 5)
        {

            tutorialImagesHorizontal.sprite = s_closeButton;
            tutorial.text = "However if the player simply wants to close the empire manager, they can press the close button in the top right corner, or press the (esc) button on their keyboard";
        }
        if (step == 6)
        {

            tutorialImagesHorizontal.sprite = s_ownedRestaurant;
            tutorial.text = "Let's return to our restaurant. By selecting it we can manage that restaurant in particular";
        }
        if (step == 7)
        {

            tutorialImagesHorizontal.sprite = s_restaurantManager;
            tutorial.text = "In the restaurant manager we can make decisions that directly effect the restaurant we've selected.";
        }
        if (step == 8)
        {

            tutorialImagesHorizontal.sprite = s_restaurantManager;
            tutorial.text = "Here we can see a variety of tools and panels. There's a satisfaction display, a staff manager, a chef manager, and a customizable menu.";
        }
        if (step == 9)
        {

            tutorialImagesHorizontal.sprite = s_satisfactionDisplay;
            tutorial.text = "First let's look at the satisfaction display, here we can see what the public thinks about your restaurant. The more satisfaction the more likely customers will choose your restaurant over others.";
        }
        if (step == 10)
        {

            tutorialImagesHorizontal.sprite = s_staffManager;
            tutorial.text = "Next we'll look at the staff manager Here we can hire more staff (or even fire them) Staff helps improve the science points produced by the restaurant.";
        }
        if (step == 11)
        {

            tutorialImagesHorizontal.sprite = s_chefManager;
            tutorial.text = "Now we'll look at the chef manager. Here we can hire chefs to the restaurant.";
        }
        if (step == 12)
        {

            tutorialImagesHorizontal.sprite = s_chefScreenManager;
            tutorial.text = "Each restaurant can have up to three chefs. Chefs provide bonuses including satisfaction,science, and money at the end of each turn. Like staff they require an upkeep. Chefs can also be managed within the empire screen.";
        }
        if (step == 13)
        {

            tutorialImagesHorizontal.sprite = s_ChefmanagerTab;
            tutorial.text = "To manage chefs in the empire screen, return to the empire screen and click the manage chefs tab. Once you're done, return to your restaurant.";
        }
        if (step == 14)
        {

            tutorialImagesHorizontal.sprite = s_menuWindow;
            tutorial.text = "Next we have our menu. Each menu for each restaurant can be customized. Before we can add anything to our menu, we first need to build our own recipe.";
        }

        if (step == 15)
        {

            tutorialImagesHorizontal.sprite = s_ingredientsMenu;
            tutorial.text = "Before we build a new recipe let's have a look at our ingredients. Click the ingredient tab button in the top left corner.(The Ingredient Bowls)";
        }

        if (step == 16)
        {

            tutorialImagesHorizontal.sprite = s_ingredientsScreen;
            tutorial.text = "In the ingredient manager, we can upgrade our ingredients, and see what tiers we have.";
        }

        if (step == 17)
        {

            tutorialImagesHorizontal.sprite = s_ingredientsScreen;
            tutorial.text = "Tiers effect the quality and pricing of an ingredient. Higher quailty ingredients leads to more customer satisfaction, but is more expensive to produce.";
        }

        if (step == 18)
        {

            tutorialImagesHorizontal.sprite = s_upgradeIngredientButton;
            tutorial.text = "To upgrade your ingredients select which catagory you want to upgrade, then in the available upgrades panel choose which tier you want to unlock.";
        }

        if (step == 19)
        {

            tutorialImagesHorizontal.sprite = s_recipesTab;
            tutorial.text = "Moving on to recipes! To build a recipe first we need to start by going into the recipe manager. To get there just click on the recipe tab in the top left(Marked with the menu icon)";
        }
        if (step == 20)
        {

            tutorialImagesHorizontal.sprite = s_recipeScreen;
            tutorial.text = "Welcome to the recipe manager! Here we can see our saved recipes, and create new recipes. As you can see we have yet to create any recipes.";
        }
        if (step == 21)
        {

            tutorialImagesHorizontal.sprite = s_createRecipe;
            tutorial.text = "To create a recipe start by click the dish blueprint from any of your owned dishes. The highlighted buttons mean the player owns these dishes.";
        }
        if (step == 22)
        {

            tutorialImagesHorizontal.sprite = s_createScreen;
            tutorial.text = "After selecting the dish you want to create, the player will be taken to the recipe creation screen. Here we can see multiple slots for various ingredients.";
        }
        if (step == 23)
        {

            tutorialImagesHorizontal.sprite = s_createScreen;
            tutorial.text = "As we can see each dish comes with a different combination of available ingredient slots. There are always 2 locked slots and 1 unlocked slot.";
        }
        if (step == 24)
        {

            tutorialImagesHorizontal.sprite = s_ingredientSlot;
            tutorial.text = "The slots that are labeled means you have to choose an ingredient restricted to that label. To pick an ingredient left click on the slot, then choose what tier ingredient you want to use.";
        }
        if (step == 25)
        {

            tutorialImagesHorizontal.sprite = s_questionMarkButton;
            tutorial.text = "The (?) slot gives players the freedom of putting whatever catagory of they choose into the slot. In the ingredient panel to the right there'll be tabs that'll guide the player and help them select the ingredient type they want to choose.";
        }
        if (step == 26)
        {

            tutorialImagesHorizontal.sprite = s_createScreen;
            tutorial.text = "Once the player has finished customizing their dish, be sure to name it then click the save button.";
        }
        if (step == 27)
        {

            tutorialImagesHorizontal.sprite = s_closeButton;
            tutorial.text = "After pressing save, the player should see their recipe appear in the saved recipes window back in the recipe manager. Press close or (esc) and return to the restaurant.";
        }
        if (step == 28)
        {

            tutorialImagesHorizontal.sprite = s_menuWindow;
            tutorial.text = "To assign the recipe to a restaurant the player needs to click in the menu window on the button saying (Select a recipe). Then the saved recipes window should appear.";
        }
        if (step == 29)
        {

            tutorialImagesHorizontal.sprite = s_addDishWindow;
            tutorial.text = "The player should then be able to select their recipe and assign it to their menu.";
        }
        if (step == 30)
        {

            tutorialImagesHorizontal.sprite = s_recipeSlider;
            tutorial.text = "Once the recipe is in the menu, the player should see a price slider. This allows the player to set the price for the customers. Higher prices means the player will lose satisfaction.";
        }
        if (step == 31)
        {

            tutorialImagesHorizontal.sprite = s_techTab;
            tutorial.text = "Before we want to end our turn we want to begin research in the tech tree. To go to the tech tree press the tech tab in the top left corner.(the Science Icon)";
        }
        if (step == 32)
        {

            tutorialImagesHorizontal.sprite = s_techTree;
            tutorial.text = "In the tech tree there are 3 catagories of tech. Mexican, American, and Italian. Each have their own playstyles.";
        }
        if (step == 33)
        {

            tutorialImagesHorizontal.sprite = s_techTree;
            tutorial.text = "Mexican food focuses on boosting customer satisfaction, and attracting more customers per restaurant.";
        }
        if (step == 34)
        {

            tutorialImagesHorizontal.sprite = s_techTree;
            tutorial.text = "American food focuses on conquring more restaurants and spreading wide to make the most profits.";
        }
        if (step == 35)
        {

            tutorialImagesHorizontal.sprite = s_techTree;
            tutorial.text = "Italian food focuses on creating high quality ingredients and increasing how much science they gain per turn.";
        }
        if (step == 36)
        {

            tutorialImagesHorizontal.sprite = s_techTree;
            tutorial.text = "Most techs are locked behind the prequistes that preceeds it. You must unlock techs to build down the tree.";
        }
        if (step == 37)
        {

            tutorialImagesHorizontal.sprite = s_techTree;
            tutorial.text = "To begin research simply left click on a tech you're interested in. You can even queue more than one so that when your tech is researched, the next one starts researching automatically.";
        }
        if (step == 38)
        {

            tutorialImagesHorizontal.sprite = s_techTree;
            tutorial.text = "Once you're done with the tech tree feel free to return to the map.";
        }
        if (step == 39)
        {

            tutorialImagesHorizontal.sprite = s_winnerScreen;
            tutorial.text = "The last thing we'll cover is win conditions.";
        }
        if (step == 40)
        {

            tutorialImagesHorizontal.sprite = s_winnerScreen;
            tutorial.text = "There are two ways of achieving victory. Conquest and Economic.";
        }
        if (step == 41)
        {

            tutorialImagesHorizontal.sprite = s_winnerScreen;
            tutorial.text = "Conquest victory is achieved if a player controls 90% of the avaiable restaurants and vacant lots.";
        }
        if (step == 42)
        {

            tutorialImagesHorizontal.sprite = s_winnerScreen;
            tutorial.text = "Economic victory is achieved through having the most amount of money after 50 turns.";
        }
        if (step == 43)
        {

            tutorialImagesHorizontal.sprite = s_logo;
            tutorial.text = "Once you're done making all your turn 1 decisions feel free to press (End Turn) and pass the helm to the next player.";
        }

    }
}
