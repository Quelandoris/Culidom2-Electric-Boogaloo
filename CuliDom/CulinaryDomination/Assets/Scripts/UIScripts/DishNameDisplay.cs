using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishNameDisplay : MonoBehaviour {

    public Text dishName;
    

    //mexican food
    public void TacoButton()
    {
        dishName.text = "Taco";
    }

    public void EnchilladaButton()
    {
        dishName.text = "Enchillada";
    }

    public void QuesadillaButton()
    {
        dishName.text = "Quesadilla";
    }

    //italian food
    public void PizzaButton()
    {
        dishName.text = "Pizza";
    }

    public void SpahgettiButton()
    {
        dishName.text = "Spahgetti";
    }

    public void PaniniButton()
    {
        dishName.text = "Panini";
    }

    //American food
    public void BurgerButton()
    {
        dishName.text = "Burger";
    }

    public void ChilliButton()
    {
        dishName.text = "ChilliButton";
    }

    public void GumboButton()
    {
        dishName.text = "Gumbo";
    }

    public void closeRecipeBuilder()
    {
        dishName.text = "";
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            dishName.text = "";
        }
    }
}
