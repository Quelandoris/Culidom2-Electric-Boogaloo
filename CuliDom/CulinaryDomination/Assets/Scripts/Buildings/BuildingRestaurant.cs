﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRestaurant : Building {

    GameObject window;
    public int price;
    public int staff;
    public List<Chef> chefs = new List<Chef>();
    public List<GameObject> chefButtons = new List<GameObject>();
    private List<Tech> upgrades = new List<Tech>();
    public int techPointRate;
    public double turnRevenue;
    public double upkeep;
    public bool onChefScreen = false;
    private int[] reviews;
    private int reviewCount = 0;
    public int numberOfReviewToKeep = 1000;
    [Tooltip("If no reviews are in, this will be the restaurants rating")]
    public double defaultRating = 6.0;

    //perhaps variables that won't need to be later
    public int staffCost = 100;
    public int valuePerTechChef = 1;

    //Must have recipes
    public List<RestaurantRecipe> recipes = new List<RestaurantRecipe>(3);
    public List<GameObject> recipeButtons = new List<GameObject>();
    //public List<string[]> activeRecipies = new List<string[]>();
    //selling price of each recipe

    CameraMovement cameraScript;
    VoicePacks voiceScript;

    public void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
        reviews = new int[numberOfReviewToKeep];
        voiceScript = FindObjectOfType<VoicePacks>();
    }

    public override void Click()
    {
        if(GameController.Instance().activePlayer.HaveRestaurant(this)) {
            window = canvas.GetComponentInChildren<TilePopupUIManager>().OpenOwnedRestaurant(); 
            cameraScript.TurnCanMoveFalse();

            RestaurantUI ui = window.GetComponent<RestaurantUI>();
            ui.building = this;
            ui.UpdateRating();
            GameController.Instance().activePlayer.restaurantClicked = this;
            Debug.Log("Set restaurant reference" + this.GetInstanceID());
            ui.FillFields(name);
            //ui.FillChefs(); // fills chefs into the little scroll view on restaurant

            try
            {
                voiceScript.PlaySelectRestaurantVO((int)GameController.Instance().activePlayer.playerFaction.voice);
            }
            catch { }
        }
        else {
            window = canvas.GetComponentInChildren<TilePopupUIManager>().OpenEnemyRestaurant();
            RestaurantUI ui = window.GetComponent<RestaurantUI>();
            ui.building = this;
            GameController.Instance().activePlayer.restaurantClicked = this;
            //cameraScript.TurnCanMoveFalse();
        }
    }

    public override void UnClick() {
        //added a menu clear function
        RestaurantUI ui = window.GetComponent<RestaurantUI>();
        ui.building = this;
        //ui.DeleteChefs();
        foreach (GameObject button in recipeButtons) {
           // Destroy(button);  // This was deleting all the buttons in menu hopefully it didn't mess something else up
        }
        canvas.GetComponentInChildren<TilePopupUIManager>().CloseUI();
    }

    //really should only be called if one of the determining variables is changed
    public double CalculateUpkeep() {
        upkeep = 200 + staff*5 + chefs.Count*5; // to get chef upkeep do a foreach and add together each chef's upkeep (GetUpkeep) //
        //Update display
        /*foreach(RestaurantRecipe rr in recipes)
        {
            for(int i = 0; i < rr.quantitySold; i++)
            {
                GameController.Instance().activePlayer.AddMoney(-rr.manufacturingCost);
            }
        }*/
        Debug.Log("The upkeep for this player is " + upkeep);
        //Unnamed Tech "Overall Upkeep of a restaurant is reduced by 5%"
        if(upgrades.Contains(Tech.CHEAP_UPKEEP)) {
            upkeep *= 0.95;
            Debug.Log("Your upkeep is 95% becuase of upgrade");
        }
        return upkeep;
    }

    public double CalculateTurnRevenue() {
        
        turnRevenue = 0 - CalculateUpkeep(); 
        Debug.Log("Have " + recipes.Count + " recipies");
        foreach (RestaurantRecipe r in recipes) {
            Debug.Log("Sold " + r.quantitySold + " units of " + r.recipe.name);
            turnRevenue += (r.sellingPrice - r.manufacturingCost) * r.quantitySold;
            r.quantitySold = 0;
        }
        //EveryCorner
        /*if("You have another restaurant in this district")    {
         * turnRevenue *= 1.05;
         * Debug.Log("You got 105% the revenue for having more than one restaurant here");
         * } */
        //Limited Time Event
        if (upgrades.Contains(Tech.LIMITED_TIME_OFFER) && GameController.Instance().GetRoundNumber()%10==0) {
            turnRevenue += 150;
            Debug.Log("You got an extra 150 per restaurant for your Limited Time Offer tech");
        }
        //Branded Microwae Foods
        if (GameController.Instance().activePlayer.HaveTech(Tech.BRANDED_MICROWAVE_FOODS)) {
            turnRevenue += 100;
            Debug.Log("You got an extra 100 per restaurant for your Branded Microwave Foods");
        }

        Debug.Log("The turn revenue for this player is " + turnRevenue);

        return turnRevenue;

        
    }

    public double CalculateTurnRevenueWithouUpkeep()
    {

        turnRevenue = 0;
        Debug.Log("Have " + recipes.Count + " recipies");
        foreach (RestaurantRecipe r in recipes)
        {
            Debug.Log("Sold " + r.quantitySold + " units of " + r.recipe.name);
            turnRevenue += (r.sellingPrice - r.manufacturingCost) * r.quantitySold; // randomize how many customers
           // r.quantitySold = 0;
        }
        //EveryCorner
        /*if("You have another restaurant in this district")    {
         * turnRevenue *= 1.05;
         * Debug.Log("You got 105% the revenue for having more than one restaurant here");
         * } */
        //Limited Time Event
        if (upgrades.Contains(Tech.LIMITED_TIME_OFFER) && GameController.Instance().GetRoundNumber() % 10 == 0)
        {
            turnRevenue += 150;
            Debug.Log("You got an extra 150 per restaurant for your Limited Time Offer tech");
        }
        //Branded Microwae Foods
        if (GameController.Instance().activePlayer.HaveTech(Tech.BRANDED_MICROWAVE_FOODS))
        {
            turnRevenue += 100;
            Debug.Log("You got an extra 100 per restaurant for your Branded Microwave Foods");
        }

        Debug.Log("The turn revenue for this player is " + turnRevenue);

        return turnRevenue;


    }

    //should return the net revenue of this restaurant from this turn
    public double GetTurnRevenue() {
       
        return CalculateTurnRevenue();  //Pointless method is pointless. xD
    }

    public double GetTurnRevenuePerdiction() {
        double perdiction = 0-CalculateUpkeep();
        //not sure how this is gonna work. It's gotta take an average of the customer's choices/possibilities I reckon
        return perdiction;
    }

    public void CalculateTechPointRate() {
        double italianUpgradeBonuses = 0;
        if (upgrades.Contains(Tech.SCIENCE_INCREASE)) {
            foreach(RestaurantRecipe r in recipes) {
                if(r.recipe.dishCategory==DishCategory.ITALIAN) {
                    Debug.Log("Science Increase added 0.5 for an italian recipe");
                    italianUpgradeBonuses += 0.5f;
                }
            }
        }
        if (upgrades.Contains(Tech.FANCY_STAFF)) {
            Debug.Log("fancy staff added 2 per staff");
            italianUpgradeBonuses += staff * 2;
        }
        techPointRate = 1 + (int)italianUpgradeBonuses + CalculateTechChefs();   //later replace with appropriate formula

    }

    public void BuyStaff()
    {
        if (GameController.Instance().activePlayer.GetMoney() >= staffCost)
        {
            //Cheaper staff tech
            if (upgrades.Contains(Tech.CHEAP_WORKERS))
            {
                GameController.Instance().activePlayer.AddMoney(-staffCost * 0.75);
                Debug.Log("Your staff cost 25% less thanks to Cheaper Staff");
            }
            else
            {
                GameController.Instance().activePlayer.AddMoney(-staffCost);
            }
            staff++;
            CalculateUpkeep(); //Does this really need to be called?

            try
            {
                // AudioManager.Play() "Buy staff"
            }
            catch { }
        }
        
    }

    public void AddChef(Chef newChef) {
        chefs.Add(newChef);
        GameController.Instance().activePlayer.AddMoney(-newChef.GetChefCost());
        try
        {
            voiceScript.PlayHireChefVO((int)GameController.Instance().activePlayer.playerFaction.voice);
        }
        catch { }
        Debug.Log("Chef was added to this restaurant");
    }

    public void DeleteChef() {

        try
        {
            // AudioManager.Play() "Hire a chef"
        }
        catch { }
    }

    public void SellStaff()
    {
        staff--;
        CalculateUpkeep();

        try
        {
            // AudioManager.Play() "sell staff"
        }
        catch { }
    }

    //basically an example function
    private int CalculateTechChefs() {
        int techBonus = 0;
        foreach (Chef c in chefs) {
            if (c.GetChefType() == ChefType.TECHNOLOGY) {
                techBonus += valuePerTechChef;
                //techBonus += c.chefBoost;
            }
        }
        return techBonus;
    }

    //add recipe to restaurant with selling price of userInputCost
    public void AddRecipe(double userInputCost, Recipe recipeInfo) {
        RestaurantRecipe current = new RestaurantRecipe(userInputCost, recipeInfo, upgrades);
        recipes.Add(current);
    }

    //add recipe to restaurant without the selling price detail
    public void AddRecipe(Recipe recipeInfo) {
        RestaurantRecipe current = new RestaurantRecipe(recipeInfo);
        recipes.Add(current);
    }

    //I believe this is the user changing the slider cost of a menu item
    public void UpdateRecipeCosts(double costMultiplier, Recipe checkRecipe) {
        for (int i = 0; i < recipes.Count; i++) {
            if (recipes[i].recipe != checkRecipe)
            {
                continue;
            }
            else {
                Debug.Log("We found the ResturnatRecipe, and we are multipling " + costMultiplier);
                recipes[i].ChangeRecipeCost(costMultiplier);
            }
        }
    }

    public List<Tech> GetTechUpgrades() {
        return upgrades;
    }

    //Never called
    /*public void AddChefXP(double xpGain) {
        // if there are more than 1 chef with higer lvls, there is a formula to level chefs up quicker;
        foreach(Chef c in chefs) {
            c.GainXP(xpGain);
            if(upgrades.Contains(Tech.TRAINED_CHEFS)) {
                Debug.Log("Your chef gained 50% more xp from Trained Chefs");
                c.GainXP(xpGain*0.5);
            }
        }
    }*/

    public void AddTech(Tech t) {
        upgrades.Add(t);
        foreach (RestaurantRecipe r in recipes) {
            r.RecalculateRecipeManufacturingCost(upgrades);
        }
    }

    public double GetRating() {
        double ret = 0.0;
        if(reviewCount == 0) {
            //returns default ratingMultiplyer
            ret = defaultRating;
        } else if(reviewCount<reviews.Length) {
            for (int i = 0; i<reviewCount; i++) {
                ret += reviews[i];
            }
            ret = ret /reviewCount;
        } else if (reviewCount>reviews.Length) {
            foreach (int r in reviews) {
                ret += r;
            }
            ret = ret / reviews.Length;
        }
        return ret;
        //value from 0 - 10 is rating
    }

    //int should be a rating multipler from 0 to 13.5 or higher(?)
    public void AddReview(double ratingMultipler) {
        int newRating = -1;

        //converts a ratingMultipler into a rating using game design chart
        if(ratingMultipler<=1) {
            newRating = 10;
        } else if(ratingMultipler<=2.5){
            newRating = 8;
        } else if(ratingMultipler<=4.5){
            newRating = 6;
        } else if(ratingMultipler<=7){
            newRating = 4;
        } else if(ratingMultipler<=10){
            newRating = 2;
        }
        else {
            newRating = 0;
        }

        reviewCount++;
        reviews[reviewCount%reviews.Length] = newRating;

        Debug.Log("Added Review of " + newRating.ToString());
    }

    public int GetTechRate() {
        CalculateTechPointRate();
        return techPointRate;
    }
    //Make function that calculates what dish each population unit chooses
    //It should fill/overwrite the 'quantitySold" of each RestaurantRecipe in recipes
}