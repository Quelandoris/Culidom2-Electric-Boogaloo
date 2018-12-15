using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResidentUI : MonoBehaviour {

    public Text nameText;
    public Text populationText;
    public Text incomeText;
    public Text preferenceText;
    public Text likesText;
    public Text hatesText;
    public Text debugIncome;
    public Text debugPref;
    public BuildingResidential building;

    public void FillFields(ResSummary sum)
    {
        nameText.text = sum.name;
        populationText.text = "Population Units: " + sum.population;
        incomeText.text = "Income Level: " + sum.income;
        preferenceText.text = "Preferences: " + sum.preference;
        likesText.text = "Favorites: " + sum.favorites;
        hatesText.text = "Dislikes: " + sum.hates;
        debugIncome.text = "Debug: " + sum.debugIncome;
        debugPref.text = "Debug: " + sum.debugPref;
    }
}
