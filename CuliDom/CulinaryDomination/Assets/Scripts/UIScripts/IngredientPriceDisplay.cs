using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientPriceDisplay : MonoBehaviour {

    public Text textTop, textMid, textBot;


    //displaying the price of the top tier of ingredients
    public void Tier0Top()
    {
        textTop.text = "0.37";
        textMid.text = "";
        textBot.text = "";
    }

    public void Tier1Top()
    {
        textTop.text = "0.75";
        textMid.text = "";
        textBot.text = "";
    }

    public void Tier2Top()
    {
        textTop.text = "1.50";
        textMid.text = "";
        textBot.text = "";
    }

    public void Tier3Top()
    {
        textTop.text = "3.00";
        textMid.text = "";
        textBot.text = "";
    }
    //displaying the price of the middle tier of ingredients
    public void Tier0Mid()
    {
        textMid.text = ".50";
        textTop.text = "";
        textBot.text = "";
    }

    public void Tier1Mid()
    {
        textMid.text = "1.00";
        textTop.text = "";
        textBot.text = "";
    }

    public void Tier2Mid()
    {
        textMid.text = "2.0";
        textTop.text = "";
        textBot.text = "";
    }

    public void Tier3Mid()
    {
        textMid.text = "4.00";
        textTop.text = "";
        textBot.text = "";
    }
    //displaying the price of the bottom tier of ingredients
    public void Tier0Bot()
    {
        textBot.text = "0.63";
        textTop.text = "";
        textMid.text = "";
    }

    public void Tier1Bot()
    {
        textBot.text = "1.25";
        textTop.text = "";
        textMid.text = "";
    }

    public void Tier2Bot()
    {
        textBot.text = "2.50";
        textTop.text = "";
        textMid.text = "";
    }

    public void Tier3Bot()
    {
        textBot.text = "5.00";
        textTop.text = "";
        textMid.text = "";
    }

    public void closeRecipeBuilder()
    {
        textBot.text = "";
        textTop.text = "";
        textMid.text = "";
    }
}
