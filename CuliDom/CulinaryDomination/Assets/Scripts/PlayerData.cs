using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tech
{
    //Starter upgrades
    AMERICAN_STARTER,
    MEXICAN_STARTER,
    ITALIAN_STARTER,
    //Mexican Tech Trees
    CHIPS_SALSA,
    MEXICAN_SODAS,
    SAUCE_BAR,
    QUINCEIRA,
    CHEAPER_INGREDIENTS,
    RECIPE_BOOST,
    AMBIENT_MUSIC,
    GRANDMAS_COOKING,
    INDOOR_FOUNTAIN,
    MIRAACHI_BAND,
    //Italian Tech Trees
    SCIENCE_INCREASE,
    CITY_SIDE,
    REMOTE_LOCATION,
    FANCY_STAFF,
    TRAINED_CHEFS,
    CATERING,
    GARLIC_BREAD,
    FRESH_PRODUCE,
    PLACE_HOLDER,
    EXPENSIVE_CLIENTLE,
    FINE_DINING,
    //American Tech Trees
    LIMITED_TIME_OFFER,
    EVERY_CORNER,
    CHEAP_UPKEEP,
    CHEAP_WORKERS,
    STEAK_HOUSE,
    CUTTING_CORNERS,
    BIRTHDAY_PARTY,
    SUPER_SIZE,
    SPONSERSHIPS,
    CHAIN_RESTAURANT,
    BRANDED_MICROWAVE_FOODS

}

public class PlayerData {
    //Now need a function or the like for starting the player with certain tech having since gotten rid of the 'unlocked' bool on each tech

    private double money = 0;
    private int techPointRate = 3;
    public int ingredientPoints = 1;

    public List<BuildingRestaurant> ownedRestaurants = new List<BuildingRestaurant>();

    public List<TechPurchase> techQueue;

    public List<Chef> ownedChefs = new List<Chef>();


    private List<Tech> knownTech;

    public List<GameObject> knownTierUpgrades = new List<GameObject>();


    public List<Recipe> savedRecipies = new List<Recipe>();

    public int[] techProgress;
    public FactionData playerFaction = null;
    public BuildingRestaurant restaurantClicked;

    private double turnRevenue;

    private string playerName;
    private string empireName;
    private string voiceName;

    //note that a negative value indicated having tier 0 available, but the |value| represents the max tier
    public int[] ingredientTiers = new int[5]{ 1, 1, 1, 1, 1 };
    //protein, dairy, starch, sauce, misc

    public PlayerData()
    {
        techQueue = new List<TechPurchase>();
        knownTech = new List<Tech>();
    }

    //pass the level of tier being unlocked, and then int of 0-4 with 0 being protein then dairy, starch, sauce, and misc as 4
    public void SetIngredientTier(int level, int type) {
        if(level==0) {
            ingredientTiers[type] = -ingredientTiers[type];
        }
        else if (ingredientTiers[type]<0) {
            ingredientTiers[type] = -level;
        }
        else {
            ingredientTiers[type] = level;
        }
    }

    //called by GameController, create an array of correct size
    public void UIConstructed (int size) {
        techProgress = new int[size];
    }

    public double GetMoney()
    {
        return money;
    }

    public void AddMoney(double value)
    {
        money += value;
    }

    public void SetMoney(double value)
    {
        money = value;
    }

    public void SetPlayerName(string name) {
        playerName = name;
    }

    public string GetPlayerName() {
        return playerName;
    }

    public void AddChef(Chef newChef) {
        ownedChefs.Add(newChef);
    }

    public void SubtractMoney(double value) {
        money -= value;
    }

    
    public int GetTechPointRate()
    {
        //rather than being stored here, this may be a result of buildings you own
        return techPointRate;
    }

    public void AddTechPointRate(int value)
    {
        techPointRate += value;
    }

    public void SetTechPointRate(int value)
    {
        techPointRate = value;
    }

    public bool HaveTech(Tech tech)
    {
        return knownTech.Contains(tech);
    }

    public void LearnTech(Tech tech)
    {
        if (!knownTech.Contains(tech))
        {
            knownTech.Add(tech);
            ingredientPoints++;
        }
    }

    public void CalculateRevenue() {
        turnRevenue = 0;
        foreach (BuildingRestaurant restaurant in ownedRestaurants) {
            turnRevenue += restaurant.GetTurnRevenue();
        }
    }

    public double PerdictRevenue() {
        double perdiction = 0;
        foreach (BuildingRestaurant restaurant in ownedRestaurants) {
            perdiction += restaurant.GetTurnRevenuePerdiction();
        }
        return perdiction;
    }

    public void AddRevenue() {
        money += turnRevenue;
    }

    public double GetTurnRevenue()
    {
        return turnRevenue;
    }

    public void ReadWhatIGot() {

        for (int i = 0; i < savedRecipies[0].ingredients.Length; i++) {
            //Debug.Log("Saved recipie slot choice is: " + Ingredient.IngredientToString(savedRecipies[0].ingredients[i]));
        }
    }

    public bool IsQueued(Tech queueCheck) {
        foreach (TechPurchase techQ in techQueue) {
            if (techQ.thisTech == queueCheck) {
                return true;
            }
        }
        return false;
    }

    public int IndexOfTech(Tech t) {
        foreach (TechPurchase techQ in techQueue) {
            if (techQ.thisTech == t) {
                return techQueue.IndexOf(techQ);
            }
        }
        return -1;
    }

    public void AddRecipe(Recipe recipe) {
        if (!savedRecipies.Contains(recipe))
        {
            savedRecipies.Add(recipe);
        }
    }

    public void UpdateRecipe(Recipe original, Recipe updated)
    {
        int index = savedRecipies.IndexOf(original);
        if(index >= 0)
        {
            savedRecipies[index] = updated;
        }
    }

    public bool HaveRestaurant(BuildingRestaurant restaurant) {
        return ownedRestaurants.Contains(restaurant);
    }

    public void AddResteraunt(BuildingRestaurant restaurant) {
        ownedRestaurants.Add(restaurant);

        //Hey, for this line instead of finding it you should put a reference to it in the UIManager and get it from there.
        //Find is convenient but can be a bit slow and will break if someone renames the component
        //RestaurantLocalScrollView localButton = GameObject.Find("LocationScrollView").GetComponent<RestaurantLocalScrollView>(); // creates a reference of the resturant for the empire panel, so we can add chefs to them
        Debug.Log("Added Resteraunt to list that cost: " + ownedRestaurants[ownedRestaurants.Count - 1].price);
    }

}
