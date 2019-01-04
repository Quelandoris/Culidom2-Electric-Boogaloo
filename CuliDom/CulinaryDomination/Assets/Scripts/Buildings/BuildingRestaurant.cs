using System.Collections;
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
    TextureGenerator TileGenerator;

    public void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
        reviews = new int[numberOfReviewToKeep];
        voiceScript = FindObjectOfType<VoicePacks>();
        TileGenerator = FindObjectOfType<TextureGenerator>();
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
            if (upgrades.Contains(Tech.CHEAPER_INGREDIENTS))
            {
                turnRevenue += CheaperIngredientTech(r);

            } else if (upgrades.Contains(Tech.STEAK_HOUSE)) {

                turnRevenue += SteakHouseTech(r);
            } else if (upgrades.Contains(Tech.CUTTING_CORNERS)) {

                turnRevenue += CuttingCornersTech(r);
            } else if (upgrades.Contains(Tech.FRESH_PRODUCE)) {
                turnRevenue += FreshProduceTech(r);
            }
            else {
                turnRevenue += (r.sellingPrice - r.manufacturingCost) * r.quantitySold;
            }
            r.quantitySold = 0;
        }
        //EveryCorner
        if (upgrades.Contains(Tech.EVERY_CORNER))
        {
            if (TileGenerator.SameDistrict(this))
            { // looks through all the tiles every turn. Which slows the game down a lot. Has to be a better way
                turnRevenue *= 1.05;
            }
        }
        // City SIde
        if (upgrades.Contains(Tech.CITY_SIDE)) {
            int cityBlocks = TileGenerator.AmountOfCityBlocks(this);
            GameController.Instance().activePlayer.AddTechPointRate(cityBlocks);
        }
        // Remote Location
        if (upgrades.Contains(Tech.REMOTE_LOCATION)) {
            int ruralAreas = TileGenerator.AmountOfRuralBlocks(this);
            GameController.Instance().activePlayer.AddTechPointRate(ruralAreas);
        }

        if (upgrades.Contains(Tech.BRANDED_MICROWAVE_FOODS)) {
            turnRevenue += 100;
        }

        if (upgrades.Contains(Tech.FINE_DINING)) {
            turnRevenue += 1.1;
        }


        //Limited Time Event
        if (upgrades.Contains(Tech.LIMITED_TIME_OFFER) && GameController.Instance().GetRoundNumber()%10==0) {
            turnRevenue += 150;
            Debug.Log("You got an extra 150 per restaurant for your Limited Time Offer tech");
        }

        if (upgrades.Contains(Tech.CHAIN_RESTAURANT)) {
            turnRevenue *= 1.1;
        }
      

        return turnRevenue;

        
    }

    double CheaperIngredientTech(RestaurantRecipe rr) {
        double newManufacturingCost = rr.manufacturingCost * 0.9;
        return (rr.sellingPrice - newManufacturingCost) * rr.quantitySold;

    }

    double SteakHouseTech(RestaurantRecipe rr) {
        double steakHouseModifier = 100.00;
        foreach (TieredIngredient i in rr.recipe.ingredients)
        {
            if (i.ingredient == RecipeIngredient.CHICKEN || i.ingredient == RecipeIngredient.PORK || i.ingredient == RecipeIngredient.BEEF ||
                i.ingredient == RecipeIngredient.VIENNA || i.ingredient == RecipeIngredient.LOBSTER)
            {
                steakHouseModifier -= 0.05;
            }
        }
        double newManufacturingCost = rr.manufacturingCost * steakHouseModifier;
        return (rr.sellingPrice - newManufacturingCost) * rr.quantitySold;

    }

    double CuttingCornersTech(RestaurantRecipe rr) {
        double cuttingCornerModifier = 100.00;
        foreach (TieredIngredient i in rr.recipe.ingredients) {
            if (i.tier == 0) {
                cuttingCornerModifier -= 0.10;
            }
        }
        double newMaunfacturingCost = rr.manufacturingCost * cuttingCornerModifier;
        return (rr.sellingPrice - newMaunfacturingCost) * rr.quantitySold;
    }

    double FreshProduceTech(RestaurantRecipe rr) {
        double freshProduceModifier = 100.00;
        foreach (TieredIngredient i in rr.recipe.ingredients)
        {
            if (i.ingredient == RecipeIngredient.TOMATOES || i.ingredient == RecipeIngredient.GARLIC || i.ingredient == RecipeIngredient.LETTUCE ||
                i.ingredient == RecipeIngredient.LIMES || i.ingredient == RecipeIngredient.ARTICHOKE)
            {
                freshProduceModifier -= 0.1;
            }
        }

        double newManufacturingCost = rr.manufacturingCost * freshProduceModifier;
        return (rr.sellingPrice - newManufacturingCost) * rr.quantitySold;
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
        if (GameController.Instance().activePlayer.HaveTech(Tech.CHEAP_WORKERS))
        {
            if (GameController.Instance().activePlayer.GetMoney() >= (staffCost * 0.75))
            {
                GameController.Instance().activePlayer.AddMoney(-(staffCost * 0.75));

                staff++;
                CalculateUpkeep(); //Does this really need to be called?

            }
            else {
                GameController.Instance().activePlayer.AddMoney(-staffCost);
            }
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
        } else if(reviewCount < reviews.Length) {
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
        // Add in rating tech bonuses //
        if (upgrades.Contains(Tech.CHIPS_SALSA)) { 
            ret += 0.2;
            if (ret > 10.0) {
                ret = 10.0;
            }
        }

        if (upgrades.Contains(Tech.SAUCE_BAR)) {
            ret += 0.4;
            if (ret > 10.0)
            {
                ret = 10.0;
            }
        }

        if (upgrades.Contains(Tech.MIRAACHI_BAND))
        {
            ret += 1.0;
            if (ret > 10.0)
            {
                ret = 10.0;
            }
        }

        if (upgrades.Contains(Tech.GARLIC_BREAD))
        {
            ret += 1.0;
            if (ret > 10.0)
            {
                ret = 10.0;
            }
        }

        if (upgrades.Contains(Tech.FINE_DINING)) {
            ret += 2.0;
            if (ret > 10.0) {
                ret = 10.0;
            }
            
        }

        if (upgrades.Contains(Tech.CHAIN_RESTAURANT))
        {
            ret -= 0.5;
            if (ret < 0.0)
            {
                ret = 0.0;
            }
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
        if (upgrades.Contains(Tech.INDOOR_FOUNTAIN)) {
            newRating -= 2;
            if (newRating < 0) {
                newRating = 0;
            }
        }
        Debug.Log("Added Review of " + newRating.ToString());
    }

    public int GetTechRate() {
        CalculateTechPointRate();
        return techPointRate;
    }
    //Make function that calculates what dish each population unit chooses
    //It should fill/overwrite the 'quantitySold" of each RestaurantRecipe in recipes
}
