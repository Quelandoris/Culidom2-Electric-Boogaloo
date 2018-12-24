using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController {

    private static GameController instance = null;
    private static Object lockObj = new Object();

    public UIController mainUI;
    private Player playerDataControls;
    public SwapPortraits swapPortraitScript;
    public VoicePacks voiceScript;
    private PlayerData playerWithBestTurn;

    public TextureGenerator world;

    public PlayerData activePlayer;
    public PlayerData[] player;
    public int biddingPlayer = 0;

    public int playerCount = 2;
    private int turn = 0;
    int totalProperty = 0;

    public double moderateDishCostThreshold = 5.00;
    public double expensiveDishCostThreshold = 15.00;




    private GameController() {
        playerDataControls = Object.FindObjectOfType<Player>();
        player = new PlayerData[playerCount];
        for (int i = 0; i < playerCount; i++) {
            player[i] = new PlayerData();
            player[i].SetMoney(playerDataControls.SetPlayerStartingMoney());
            player[i].SetTechPointRate(playerDataControls.SetPlayerStartingTechPointRate());
            Debug.Log("Player " + (i + 1) + " was created");
        }
        activePlayer = player[0];
        mainUI = Object.FindObjectOfType<UIController>();
        world = Object.FindObjectOfType<TextureGenerator>();
        swapPortraitScript = Object.FindObjectOfType<SwapPortraits>();
        voiceScript = Object.FindObjectOfType<VoicePacks>();
    }

    public GameController(int num) {
        playerCount = num;
        playerDataControls = Object.FindObjectOfType<Player>();
        player = new PlayerData[playerCount];
        for (int i = 0; i < playerCount; i++)
        {
            player[i] = new PlayerData();
            player[i].SetMoney(playerDataControls.SetPlayerStartingMoney());
            player[i].SetTechPointRate(playerDataControls.SetPlayerStartingTechPointRate());
            Debug.Log("Player " + (i+1) + " was created");
        }
        activePlayer = player[0];
        mainUI = Object.FindObjectOfType<UIController>();
        world = Object.FindObjectOfType<TextureGenerator>();
        swapPortraitScript = Object.FindObjectOfType<SwapPortraits>();
        voiceScript = Object.FindObjectOfType<VoicePacks>();
    }

    public static GameController Instance() {
        lock (lockObj) //There can be only one
        {
            if (instance == null) {
                instance = new GameController();
            }
        }
        return instance;

    }

    public void EndTurn() {
        Debug.Log("swapPortraitScript is " + swapPortraitScript.GetInstanceID() + " mainUI is " + mainUI.GetInstanceID());
        swapPortraitScript.SwitchThePictures();
        //Update money or the like at end of turn. (If at beginning, player 2 will start with more money on his first turn)

        for (int i = 0; i < activePlayer.ownedChefs.Count; i++) {
            //activePlayer.ownedChefs[i].chefXP += 1;
            //activePlayer.ownedChefs[i].CheckChefLevel();
        }

        //Close UI (get Antonio's stuff here too)
        mainUI.recipeButton.ClearContent();
        //mainUI.chefEmpireContent.DeleteContent();
       // mainUI.chefRestaurantContent.DeleteContent();

        //mainUI.CloseUI();
        Camera.main.GetComponent<MouseSelect>().UnClick();

        mainUI.AddTechPoints(activePlayer.GetTechPointRate()); // update the UI 

        //Change activePlayer and update turn count
        turn++;
        
        if (turn % playerCount == 0)
        {
            double bestTurnRevenue = double.MinValue;
            playerWithBestTurn = null;
            //customers go
            //mainUI.CustomerWaitUI.SetActive(true);
            SimulateCustomers();
            //mainUI.CustomerWaitUI.SetActive(false);
            //payout
            for(int i = 0; i < player.Length; i++)
            {
                player[i].CalculateRevenue();
                player[i].AddRevenue();
               
                if (player[i].GetTurnRevenue() > bestTurnRevenue)
                {
                    bestTurnRevenue = player[i].GetTurnRevenue();
                    playerWithBestTurn = player[i];
                }
            }
        }

        if (GetRoundNumber() > 50)
        {
            int winnerPlayer = WinByMoney();
            if (winnerPlayer != -1)
            {
                // winner with most money after 50 turns
                voiceScript.PlayWinVO((int)GameController.Instance().player[winnerPlayer].playerFaction.voice);
                // end game?
            }
        }

        if (WinByProperty() != -1)
        {
            int winnerPlayer = WinByProperty();
            voiceScript.PlayWinVO((int)GameController.Instance().player[winnerPlayer].playerFaction.voice);
            // end game?
        }


        activePlayer = player[turn % playerCount];

        //Update Per Turn Stuff: //////////////////////////// Start of next persons turn /////////////////////////////
        Debug.Log(activePlayer.savedRecipies.Count);
        //mainUI.recipeButton.CreateContent();
        //mainUI.chefEmpireContent.CreateContent();
        //mainUI.chefRestaurantContent.CreateContent();
        mainUI.UpdateUI();
        if (activePlayer == playerWithBestTurn) // What defines a good turn?
        {
            try
            {
                Debug.Log(activePlayer.GetPlayerName() + ", best");
                voiceScript.PlayGoodTurnVO((int)GameController.Instance().activePlayer.playerFaction.voice);
            }
            catch { }
        }
        else if (activePlayer.GetTurnRevenue() < 0) // what defines a bad turn
        {
            try
            {
                Debug.Log(activePlayer.GetPlayerName() + ", bad");
                voiceScript.PlayBadTurnVO((int)GameController.Instance().activePlayer.playerFaction.voice);
            }
            catch { }
        }
        else // What defines a neutrel win
        {
            try
            {
                Debug.Log(activePlayer.GetPlayerName() + ", meh");
                voiceScript.PlayNeutralTurnVO((int)GameController.Instance().activePlayer.playerFaction.voice);
            }
            catch { }
        }

    }

    private void SimulateCustomers()
    {
        
        Debug.Log("Buying dishes");
        List<WorldTile> residentTiles = new List<WorldTile>();
        List<WorldTile> restaurantTiles = new List<WorldTile>();
        foreach (GameObject tile in world.allTiles)
        {
            try
            {
                WorldTile tileScript = tile.GetComponent<WorldTile>();
                if (tileScript.building.GetType() == typeof(BuildingResidential))
                {
                    residentTiles.Add(tileScript);
                }
                else if (tileScript.building.GetType() == typeof(BuildingRestaurant))
                {
                    restaurantTiles.Add(tileScript);
                }
            }
            catch
            {
                //tile was deleted
            }
            
        }
        foreach (WorldTile residential in residentTiles)
        {
            
            foreach (Pop customer in ((BuildingResidential)residential.building).residents)
            {
                int[] scores = new int[restaurantTiles.Count];
                int favoriteScore = 0;
                //Determines favorite restaurant
                for (int i = 0; i < restaurantTiles.Count; i++)
                {
                    //Restrict buying to same district for now
                    if(restaurantTiles[i].building.tile.district == residential.district)
                    {
                        List<DishCategory> foodCategories = new List<DishCategory>();
                        List<RecipeIngredient> ingredients = new List<RecipeIngredient>();
                        List<RestaurantRecipe> recipes = ((BuildingRestaurant)restaurantTiles[i].building).recipes;
                        double averageDishCost = 0;
                        for (int j = 0; j < recipes.Count; j++) {
                            averageDishCost += recipes[j].sellingPrice;
                            if (!foodCategories.Contains(recipes[j].recipe.dishCategory)) {
                                foodCategories.Add(recipes[j].recipe.dishCategory);
                            }
                            foreach (TieredIngredient ti in recipes[j].recipe.ingredients) {
                                if (!ingredients.Contains(ti.ingredient)) {
                                    ingredients.Add(ti.ingredient);
                                }
                                if (ti.ingredient == customer.favoriteIngredient) {
                                    favoriteScore++;
                                }
                                
                            }

                            if (((BuildingRestaurant)restaurantTiles[i].building).GetTechUpgrades().Contains(Tech.RECIPE_BOOST))
                            {
                                favoriteScore++;
                            }
                        }
                        averageDishCost = averageDishCost / recipes.Count;

                        //Score based off customer preference
                        int prefScore = 0;
                        if (customer.preference == FoodPreference.NONE) {
                            prefScore = 2;
                        }
                        else if (!foodCategories.Contains(Pop.ToCategory(customer.preference))) {
                            prefScore = 1;
                        }
                        else if (foodCategories.Contains(Pop.ToCategory(customer.preference)) && foodCategories.Count == 1) {
                            prefScore = 4;
                        }
                        else {
                            prefScore = 3;
                        }

                        //Income vs price
                        int priceScore = 0;
                        IncomeLevel restaurantCost;
                        if (priceScore <= moderateDishCostThreshold) {
                            restaurantCost = IncomeLevel.LOW;
                        }
                        else if (priceScore <= expensiveDishCostThreshold) {
                            restaurantCost = IncomeLevel.MIDDLE;
                        }
                        else {
                            restaurantCost = IncomeLevel.HIGH;
                        }

                        if (restaurantCost == customer.income) {
                            if (restaurantCost == IncomeLevel.MIDDLE) {
                                priceScore = 3;
                            }
                            else {
                                priceScore = 4;
                            }
                        }
                        else if ((restaurantCost == IncomeLevel.HIGH && customer.income == IncomeLevel.LOW) || (restaurantCost == IncomeLevel.LOW && customer.income == IncomeLevel.HIGH)) {
                            priceScore = 0;
                        }
                        else {
                            priceScore = 1;
                        }

                        //todo - accurate distance
                        int distScore = 0;
                        if (restaurantTiles[i].building.tile.district == residential.district) {
                            distScore += 4;
                            
                        }
                        else {
                            if (((BuildingRestaurant)restaurantTiles[i].building).GetTechUpgrades().Contains(Tech.SAUCE_BAR))
                            {
                                distScore += 2;
                            }
                        }

                        int aversionScore = 0;
                        if (customer.hatedIngredient != RecipeIngredient.EMPTY && ingredients.Contains(customer.hatedIngredient)) {
                            aversionScore -= 4;
                        }
                        if (((BuildingRestaurant)restaurantTiles[i].building).GetTechUpgrades().Contains(Tech.AMBIENT_MUSIC)) {
                            aversionScore += 2;
                        }

                            scores[i] = Mathf.Max(0, favoriteScore + prefScore + priceScore + distScore + aversionScore + Mathf.RoundToInt((float)((BuildingRestaurant)restaurantTiles[i].building).GetRating()));
                    }

                    
                }

                /*
                #region temporary winner selection
                int bestScore = -100;
                int bestIndex = -1;
                for (int i = 0; i < score.Length; i++)
                {
                    if (score[i] > bestScore)
                    {
                        bestIndex = i;
                        bestScore = score[i];
                    }
                }
                #endregion
                */

                #region Chance-based winner selection
                int baseStayIn = 22;
                int totalPoints = baseStayIn;
                foreach(int sc in scores)
                {
                    totalPoints += sc;
                }

                int bestIndex = -1;
                int roll = Random.Range(0, totalPoints) + 1;
                

                    int cumulativeSeek = 0;
                for(int i = 0; i < scores.Length; i++)
                {
                    cumulativeSeek += scores[i];
                    if(cumulativeSeek >= roll)
                    {
                        bestIndex = i;
                    }
                }
                #endregion

                

                if (bestIndex > -1)
                {
                    List<RestaurantRecipe> winners = ((BuildingRestaurant)restaurantTiles[bestIndex].building).recipes;
                    //Added 0.1 tech per customer due to upgrade
                    if(((BuildingRestaurant)restaurantTiles[bestIndex].building).GetTechUpgrades().Contains(Tech.PLACE_HOLDER)) {
                        //Add 0.1 tech to the player (tech is an int right now)
                    }
                    //Perhaps fixes permanent "please wait"
                    if(winners.Count>0) {
                        int buy = Random.Range(0, winners.Count);
                        if(((BuildingRestaurant)restaurantTiles[bestIndex].building).GetTechUpgrades().Contains(Tech.SUPER_SIZE)) {
                            if(Random.Range(1, 5) == 4) {
                                winners[buy].quantitySold++;
                                Debug.Log("You got an extra sold from Super size tech");
                            }
                        }
                        //calculate review then add it to the restaurant
                        ((BuildingRestaurant)restaurantTiles[bestIndex].building).AddReview(winners[buy].CalculateReview());
                        winners[buy].quantitySold++;
                        Debug.Log("bought " + winners[buy].recipe.name);
                    }
                }
            }
        }
        
    }

    public int WinByMoney() {
        int winnerPlayer = -1;
        double highestAmount = 0.00;

        for (int i = 0; i < GameController.Instance().player.Length; i++) {
            if (GameController.Instance().player[i].GetMoney() >= highestAmount) {
                highestAmount = GameController.Instance().player[i].GetMoney();
                winnerPlayer = i;
            }
        }

        return winnerPlayer;
    }

    public int WinByProperty() {
        int winnerPlayer = -1;


        if (totalProperty == 0)
        {
            Debug.Log(world);
            Debug.Log(world.allTiles);
            for (int i = 0; i < world.allTiles.Count; i++)
            {
                WorldTile tileScript = world.allTiles[i].GetComponent<WorldTile>();
                if (tileScript.building.GetType() == typeof(BuildingVacant) || tileScript.building.GetType() == typeof(BuildingRestaurant))
                {
                    totalProperty++;
                }
            }
        }

        int bestPropertyCount = (int)(totalProperty * 0.85);

        for (int i = 0; i < GameController.Instance().player.Length; i++) {
            if (GameController.Instance().player[i].ownedRestaurants.Count > bestPropertyCount) {
                bestPropertyCount = GameController.Instance().player[i].ownedRestaurants.Count;
                winnerPlayer = i;
            }
        }

        return winnerPlayer;
    }

    public int GetRoundNumber() {
        return (turn / playerCount) + 1;
    }


    public int GetPlayerNumber() {
        return ((turn % playerCount) + 1);
    }

    public void UIConstructedAll(int size) {
        foreach (PlayerData pd in player) {
            pd.UIConstructed(size);
        }
    }

    public void SetStartingMoney(double money) {
        foreach (PlayerData p in player) {
            p.SetMoney(money);
        }
    }

    public void SetStartingTechPointRate(int tech) {
        foreach (PlayerData p in player) {
            p.SetTechPointRate(tech);
        }
    }

    public void SetNumPlayers(int num) {
        playerCount = num;
        //playerDataControls = Object.FindObjectOfType<Player>();
        List<PlayerData> listOfPlayers = new List<PlayerData>(player);
        while(listOfPlayers.Count < num)
        {
            listOfPlayers.Add(new PlayerData());
            //Debug.Log("We made a new player, now there are "+listOfPlayers.Count);
            listOfPlayers[listOfPlayers.Count - 1].SetMoney(playerDataControls.SetPlayerStartingMoney());
            listOfPlayers[listOfPlayers.Count - 1].SetTechPointRate(playerDataControls.SetPlayerStartingTechPointRate());
        }
        while(listOfPlayers.Count>num)
        {
            listOfPlayers.RemoveRange(listOfPlayers.Count - (listOfPlayers.Count - num), (listOfPlayers.Count - num));
        }

        player = new PlayerData[playerCount];
        //Debug.Log("Num is "+num+"\nPlayerCount is "+playerCount+"\nListofPlayer.Count is "+listOfPlayers.Count);
        for (int i = 0; i < listOfPlayers.Count; i++)
        {
            player[i] = listOfPlayers[i];
            //Debug.Log("Created Player "+(i+1));
        }
        activePlayer = player[0];
        Debug.Log("player nu is " + player.Length);
    }
}
