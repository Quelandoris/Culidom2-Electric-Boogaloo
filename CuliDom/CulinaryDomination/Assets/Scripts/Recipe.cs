using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Sprite picture;

    public Recipe(int slots)
    {
        ingredients = new TieredIngredient[slots];
    }
}
