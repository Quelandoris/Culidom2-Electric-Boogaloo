using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RecipeIngredient
{
    EMPTY = -1,
    //Protein
    CHICKEN = 0,
    PORK,
    BEEF,
    VIENNA,
    LOBSTER,
    //Dairy
    MILK,
    CHEESE,
    BUTTER,
    DAWIZ,
    PARMIGIANO,
    //Starch
    WHEAT,
    RICE,
    POTATOES,
    CORN,
    TAPIOCA,
    //Sauce
    BECHAMEL,
    REDSAUCE,
    GRAVY,
    BEER,
    COQ,
    //Misc
    TOMATOES,
    GARLIC,
    LETTUCE,
    LIMES,
    ARTICHOKE
}

public struct TieredIngredient
{
    public RecipeIngredient ingredient;
    public int tier;

    public TieredIngredient(RecipeIngredient ingredient, int tier)
    {
        this.ingredient = ingredient;
        this.tier = tier;
    }

    public override string ToString()
    {
        return "TODO";
    }

    
}

public static class Ingredient {
    public static readonly int OPTIONS_COUNT = 15; //Count of ingredients, ignoring "Empty"

    public static string IngredientToString(RecipeIngredient ingredient)
    {
        switch (ingredient)
        {
            case RecipeIngredient.EMPTY:
                return "Empty";
            case RecipeIngredient.CHICKEN:
                return "Chicken";
            case RecipeIngredient.PORK:
                return "Pork";
            case RecipeIngredient.BEEF:
                return "Beef";
            case RecipeIngredient.VIENNA:
                return "Vienna";
            case RecipeIngredient.LOBSTER:
                return "Lobster";
            case RecipeIngredient.MILK:
                return "Milk";
            case RecipeIngredient.CHEESE:
                return "Cheese";
            case RecipeIngredient.BUTTER:
                return "Butter";
            case RecipeIngredient.DAWIZ:
                return "DaWiz";
            case RecipeIngredient.PARMIGIANO:
                return "Parmigiano";
            case RecipeIngredient.WHEAT:
                return "Wheat";
            case RecipeIngredient.RICE:
                return "Rice";
            case RecipeIngredient.POTATOES:
                return "Potatoes";
            case RecipeIngredient.CORN:
                return "Corn";
            case RecipeIngredient.TAPIOCA:
                return "Tapioca";
            case RecipeIngredient.BECHAMEL:
                return "Bechamel";
            case RecipeIngredient.REDSAUCE:
                return "Redsauce";
            case RecipeIngredient.GRAVY:
                return "Gravy";
            case RecipeIngredient.BEER:
                return "Beer";
            case RecipeIngredient.COQ:
                return "Coq";
            case RecipeIngredient.TOMATOES:
                return "Tomatoes";
            case RecipeIngredient.GARLIC:
                return "Garlic";
            case RecipeIngredient.LETTUCE:
                return "Lettuce";
            case RecipeIngredient.LIMES:
                return "Limes";
            case RecipeIngredient.ARTICHOKE:
                return "Artichokes";
            default:
                return "Error";
        }
    }

    public static double IngredientCost(RecipeIngredient ingredient)
    {
        switch (ingredient)
        {
            case RecipeIngredient.EMPTY:
                return 0.0;
            case RecipeIngredient.CHICKEN:
                return 0.75;
            case RecipeIngredient.PORK:
                return 1.0;
            case RecipeIngredient.BEEF:
                return 1.25;
            case RecipeIngredient.VIENNA:
                return 0.5;
            case RecipeIngredient.LOBSTER:
                return 1.5;
            case RecipeIngredient.MILK:
                return 0.75;
            case RecipeIngredient.CHEESE:
                return 1.0;
            case RecipeIngredient.BUTTER:
                return 1.25;
            case RecipeIngredient.DAWIZ:
                return 0.5;
            case RecipeIngredient.PARMIGIANO:
                return 1.5;
            case RecipeIngredient.WHEAT:
                return 0.75;
            case RecipeIngredient.RICE:
                return 1.0;
            case RecipeIngredient.POTATOES:
                return 1.25;
            case RecipeIngredient.CORN:
                return 0.5;
            case RecipeIngredient.TAPIOCA:
                return 1.5;
            case RecipeIngredient.BECHAMEL:
                return 0.75;
            case RecipeIngredient.REDSAUCE:
                return 1.0;
            case RecipeIngredient.GRAVY:
                return 1.25;
            case RecipeIngredient.BEER:
                return 0.5;
            case RecipeIngredient.COQ:
                return 1.5;
            case RecipeIngredient.TOMATOES:
                return 0.75;
            case RecipeIngredient.GARLIC:
                return 1.0;
            case RecipeIngredient.LETTUCE:
                return 1.25;
            case RecipeIngredient.LIMES:
                return 0.5;
            case RecipeIngredient.ARTICHOKE:
                return 1.5;
            default:
                Debug.Log("Food cost error");
                return 1;
        }
    }

    public static double TierToMultiplier(int tier)
    {
        switch (tier)
        {
            case 0:
                return 0.5;
            case 1:
                return 1.0;
            case 2:
                return 2.0;
            case 3:
                return 4.0;
            case 4:
                return 8.0;
            default:
                return 1.0;

        }
    }
}
