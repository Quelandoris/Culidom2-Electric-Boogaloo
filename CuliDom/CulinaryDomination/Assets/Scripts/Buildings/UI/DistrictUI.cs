using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DistrictUI : MonoBehaviour {

    public Building building;

    public Text nameText;
    public Text populationText;

    public PieChart prefChart;
    public Text ameriPref;
    public Text italPref;
    public Text mexiPref;
    public Text noPref;

    public PieChart incomeChart;
    public Text lowIncome;
    public Text midIncome;
    public Text highIncome;

    public Text[] likes;
    public Text[] dislikes;

    public void Update()
    {
        if (Input.GetMouseButtonDown(1)) { // turns off the dsitrict thing
            this.gameObject.SetActive(false);
        }
    }

    public void FillFields(Building selectedBuilding)
    {
        nameText.text = "District Name";

        int population = 0;
        int[] preferences = new int[4];
        int[] incomes = new int[3];

        int maxIngredientNum = System.Enum.GetValues(typeof(RecipeIngredient)).Cast<int>().Max();
        int[] favorites = new int[maxIngredientNum+1];
        int[] hates = new int[maxIngredientNum+1];

        int district = selectedBuilding.tile.district;
        List<GameObject> tiles = selectedBuilding.world.allTiles;
        foreach(GameObject tile in tiles)
        {
            try
            {
                WorldTile tileScript = tile.GetComponent<WorldTile>();
                if(tileScript.district != district)
                {
                    continue;
                }
                if(tileScript.building.GetType() != typeof(BuildingResidential))
                {
                    continue;
                }
                BuildingResidential building = (BuildingResidential)tileScript.building;
                foreach(Pop resident in building.residents)
                {
                    population++;
                    switch (resident.preference)
                    {
                        case FoodPreference.AMERICAN:
                            preferences[0]++;
                            break;
                        case FoodPreference.ITALIAN:
                            preferences[1]++;
                            break;
                        case FoodPreference.MEXICAN:
                            preferences[2]++;
                            break;
                        default:
                            preferences[3]++;
                            break;
                    }

                    switch (resident.income)
                    {
                        case IncomeLevel.LOW:
                            incomes[0]++;
                            break;
                        case IncomeLevel.MIDDLE:
                            incomes[1]++;
                            break;
                        case IncomeLevel.HIGH:
                            incomes[2]++;
                            break;
                    }


                    if(resident.favoriteIngredient != RecipeIngredient.EMPTY)
                    {
                        favorites[(int)resident.favoriteIngredient]++;
                    }


                    if(resident.hatedIngredient != RecipeIngredient.EMPTY)
                    {
                        hates[(int)resident.hatedIngredient]++;
                    }
                }
            }
            catch
            {
                //Do nothing
            }
        }
        populationText.text = "Population: " + population;

        float popCount = population;
        ameriPref.text = "American: " + (100* preferences[0] / popCount).ToString("F0") + "%";
        italPref.text = "Italian: " + (100 * preferences[1] / popCount).ToString("F0") + "%";
        mexiPref.text = "Mexican: " + (100 * preferences[2] / popCount).ToString("F0") + "%";
        noPref.text = "None: " + (100 * preferences[3] / popCount).ToString("F0") + "%";
        prefChart.SetChart(preferences);

        lowIncome.text = "Low: " + (100 * incomes[0] / popCount).ToString("F0") + "%";
        midIncome.text = "Middle: " + (100 * incomes[1] / popCount).ToString("F0") + "%";
        highIncome.text = "High: " + (100 * incomes[2] / popCount).ToString("F0") + "%";
        incomeChart.SetChart(incomes);

        List<IngredientRank> rankedFavorites = new List<IngredientRank>();
        List<IngredientRank> rankedHates = new List<IngredientRank>();
        for(int i = 0; i < favorites.Length; i++)
        {
            rankedFavorites.Add(new IngredientRank(i, favorites[i]));
            rankedHates.Add(new IngredientRank(i, hates[i]));
        }

        rankedFavorites.Sort();
        rankedFavorites.Reverse();
        for(int i = 0; i < likes.Count(); i++)
        {
            try
            {
                string ingredient = Ingredient.IngredientToString(rankedFavorites[i].ingredient);
                if(ingredient.Length > 8)
                {
                    ingredient = ingredient.Substring(0, 8);
                }
                likes[i].text = (i + 1) + ". " + ingredient + ": " + (100 * rankedFavorites[i].count / popCount).ToString("F0") + "%";
            }
            catch
            {
                likes[i].text = "";
            }
            
        }

        rankedHates.Sort();
        rankedHates.Reverse();
        for (int i = 0; i < dislikes.Count(); i++)
        {
            try
            {
                string ingredient = Ingredient.IngredientToString(rankedFavorites[i].ingredient);
                if (ingredient.Length > 8)
                {
                    ingredient = ingredient.Substring(0, 8);
                }
                dislikes[i].text = (i + 1) + ". " + ingredient + ": " + (100 * rankedHates[i].count / popCount).ToString("F0") + "%";
            }
            catch
            {
                dislikes[i].text = "";
            }
        }
    }

    private class IngredientRank : IComparable<IngredientRank>
    {
        public RecipeIngredient ingredient;
        public int count;

        public IngredientRank(int ingredient, int count)
        {
            this.ingredient = (RecipeIngredient)ingredient;
            this.count = count;
        }

        public int CompareTo(IngredientRank other)
        {
            return count.CompareTo(other.count);
        }
    }
}
