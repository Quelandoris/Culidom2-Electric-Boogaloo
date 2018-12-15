using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DishCategory {
    MEXICAN,
    AMERICAN,
    ITALIAN
}

public class Recipe{

    public TieredIngredient[] ingredients;
    public string dishTemplate;
    public string name;
    public DishCategory dishCategory;

    public Recipe(int slots)
    {
        ingredients = new TieredIngredient[slots];
    }
}
