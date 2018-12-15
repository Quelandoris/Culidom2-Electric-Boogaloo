using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantRecipe {

    //recipe string array
    public Recipe recipe;

    public double sellingPrice;
    public double manufacturingCost;
    public double theoreticalManufacturingCost;
    public int quantitySold = 1;        // Chnage this to how many people eat our food once we get that ability
    public double baseCost;

    // \\\\\\\\\\\\\\\\\ references to the menuUI button that this ResturantRecipe is attached to \\\\\\\\\\\\\\\\
    public float multiplier; // the slider value, "Multiplier: "
    public double profit;    // the profit text: "Profit: $"

    public RestaurantRecipe(double userInputCost, Recipe recipeInfo, List<Tech> upgrades)
    {
        manufacturingCost = 0.0;
        recipe = recipeInfo;
        for (int i = 0; i < recipeInfo.ingredients.Length; i++) {

            double ingredientPrice = 0;
            ingredientPrice = (Ingredient.IngredientCost(recipe.ingredients[i].ingredient) * (Ingredient.TierToMultiplier(recipe.ingredients[i].tier)));
            
            if (upgrades.Contains(Tech.STEAK_HOUSE) && (int)recipe.ingredients[i].ingredient < 5 && (int)recipe.ingredients[i].ingredient >= 0) {
                ingredientPrice *= 0.95;
                Debug.Log("Your meat costs 5% less due to steak house upgrade");
            }
            if (upgrades.Contains(Tech.CUTTING_CORNERS) && recipe.ingredients[i].tier == 0) {
                ingredientPrice *= 0.90;
                Debug.Log("Your tier 0 ingredient costs 10% less due to cutting corners upgrade");
            }
            if (upgrades.Contains(Tech.FRESH_PRODUCE) && (int)recipe.ingredients[i].ingredient >= 20) {
                ingredientPrice *= 0.90;
                Debug.Log("Your misc ingredient costs 10% less due to fresh produce upgrade");
            }
            if (upgrades.Contains(Tech.CHEAPER_INGREDIENTS)) {
                ingredientPrice *= 0.90;
                Debug.Log("Your ingredients costs 10% less due to cheaper ingredients upgrade");
            }
            manufacturingCost += ingredientPrice;
            
            Debug.Log("Manu facturing cost is " + manufacturingCost + " right now");
        }
        
        sellingPrice = userInputCost;   //Set selling Price
        baseCost = userInputCost;
        profit = 0.0;
        multiplier = 1f;
        theoreticalManufacturingCost = manufacturingCost;
    }

    //Issues of not changing the player's selling price and base cost cost means they could have recipe now sell for more than the bounds normally allow.
    public void RecalculateRecipeManufacturingCost(List<Tech> upgrades) {
        manufacturingCost = 0.0;
        for (int i = 0; i < recipe.ingredients.Length; i++) {
            double ingredientPrice = 0;
            ingredientPrice = (Ingredient.IngredientCost(recipe.ingredients[i].ingredient) * (Ingredient.TierToMultiplier(recipe.ingredients[i].tier)));
            
            if(upgrades.Contains(Tech.STEAK_HOUSE) && (int)recipe.ingredients[i].ingredient<5 && (int)recipe.ingredients[i].ingredient>=0) {
                ingredientPrice *= 0.95;
                Debug.Log("Your meat costs 5% less due to steak house upgrade");
            }
            if(upgrades.Contains(Tech.CUTTING_CORNERS)&&recipe.ingredients[i].tier==0) {
                ingredientPrice *= 0.90;
                Debug.Log("Your tier 0 ingredient costs 10% less due to steak house upgrade");
            }
            if (upgrades.Contains(Tech.FRESH_PRODUCE) && (int)recipe.ingredients[i].ingredient >= 20) {
                ingredientPrice *= 0.90;
                Debug.Log("Your misc ingredient costs 10% less due to fresh produce upgrade");
            }
            manufacturingCost += ingredientPrice;
            
            Debug.Log("Manu facturing cost is " + manufacturingCost + " right now");
        }

        //update the below values relative to change
        //sellingPrice = ;   //Set selling Price
        //baseCost = ;
    }

    public void ChangeRecipeCost(double costMultiplier) {
        double newCost = baseCost * costMultiplier;
        sellingPrice = newCost;
        profit = newCost - baseCost;
        multiplier = (float)costMultiplier;
        Debug.Log("The multiplier for the this RR is " + multiplier);
        Debug.Log("The new cost for this recipe is " + sellingPrice);
    }

    public RestaurantRecipe(Recipe recipeInfo) {
        manufacturingCost = 0.0;
        recipe = recipeInfo;
        for (int i = 0; i < recipeInfo.ingredients.Length; i++)
        {
            manufacturingCost += (Ingredient.IngredientCost(recipeInfo.ingredients[i].ingredient) * (Ingredient.TierToMultiplier(recipeInfo.ingredients[i].tier)));
            Debug.Log("Manu facturing cost is " + manufacturingCost + " right now");
        }
        sellingPrice = manufacturingCost*2;   //Set selling Price automatically to a default
        baseCost = manufacturingCost * 2;
        profit = 0.0;
        multiplier = 1f;
    }
    
    //troubles here getting it plugged into the actually unity game correctly, perhaps make the class MonoBehavior and prefab based, but then constructor issues
    public void ChangeSellingPrice(double newPrice) {
        sellingPrice = newPrice;
    }


    public double GetAverageTier() {
        int numOfIngredients = 0;
        int totalTier = 0;
        foreach(TieredIngredient i in recipe.ingredients) {
            numOfIngredients++;
            totalTier += i.tier;
        }
        return totalTier / numOfIngredients;
    }

    //recalculating because I'm not sure about how profit is calculated (or if it is) right now
    public double GetProfit() {
        return sellingPrice - manufacturingCost;
    }

    public double CalculateReview() {
        return (GetProfit() / (theoreticalManufacturingCost - GetAverageTier()) + (1 / GetAverageTier()));
    }
}
