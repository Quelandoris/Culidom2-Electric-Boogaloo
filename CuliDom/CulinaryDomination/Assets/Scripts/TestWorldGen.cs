using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorldGen : MonoBehaviour {

    public RectTransform mainCanvas;
    public GameObject urbanFab;
    public GameObject suburbFab;
    public GameObject roadFab;
    public GameObject emptyLotFab;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 11; i++)
        {
            GameObject tile = Instantiate(urbanFab, new Vector3(-1, 0, i - 5), Quaternion.identity) ;
            WorldTile tileScript = tile.GetComponent<WorldTile>();
            BuildingResidential building = ScriptableObject.CreateInstance<BuildingResidential>();

            building.canvas = mainCanvas;
            building.tile = tileScript;    
            tileScript.building = building;

            building.name = BuildingResidential.GenerateName(ResidentType.URBAN);
            int population = Random.Range(2, 6);
            for(int j = 0; j < population; j++)
            {
                Pop currentPop = new Pop();
                currentPop.income = (IncomeLevel)Random.Range(0, 3);
                currentPop.preference = (FoodPreference)Random.Range(0, 4);
                currentPop.favoriteIngredient = (RecipeIngredient)Random.Range(0, Ingredient.OPTIONS_COUNT);
                if(Random.value > 0.5f)
                {
                    currentPop.hatedIngredient = (RecipeIngredient)Random.Range(1, Ingredient.OPTIONS_COUNT);
                }
                else
                {
                    currentPop.hatedIngredient = RecipeIngredient.EMPTY;
                }
                building.residents.Add(currentPop);
            }
        }

        for (int i = 0; i < 11; i++)
        {
            GameObject tile = Instantiate(suburbFab, new Vector3(0, 0, i - 5), Quaternion.identity);
            WorldTile tileScript = tile.GetComponent<WorldTile>();
            BuildingResidential building = ScriptableObject.CreateInstance<BuildingResidential>();

            building.canvas = mainCanvas;
            building.tile = tileScript;
            tileScript.building = building;

            building.name = BuildingResidential.GenerateName(ResidentType.SUBURB);

            int population = Random.Range(1, 5);
            for (int j = 0; j < population; j++)
            {
                Pop currentPop = new Pop();
                currentPop.income = (IncomeLevel)Random.Range(0, 3);
                currentPop.preference = (FoodPreference)Random.Range(0, 4);
                currentPop.favoriteIngredient = (RecipeIngredient)Random.Range(0, Ingredient.OPTIONS_COUNT);
                if (Random.value > 0.5f)
                {
                    currentPop.hatedIngredient = (RecipeIngredient)Random.Range(1, Ingredient.OPTIONS_COUNT);
                }
                else
                {
                    currentPop.hatedIngredient = RecipeIngredient.EMPTY;
                }
                building.residents.Add(currentPop);
            }
        }

        for (int i = 0; i < 11; i++)
        {
            GameObject tile = Instantiate(roadFab, new Vector3(1, 0, i - 5), Quaternion.identity);
            WorldTile tileScript = tile.GetComponent<WorldTile>();
            BuildingResidential building = ScriptableObject.CreateInstance<BuildingResidential>();

            building.canvas = mainCanvas;
            building.tile = tileScript;
            tileScript.building = building;

            building.name = BuildingResidential.GenerateName(ResidentType.ROAD);

            int population = Random.Range(2, 4);
            for (int j = 0; j < population; j++)
            {
                Pop currentPop = new Pop();
                currentPop.income = (IncomeLevel)Random.Range(0, 3);
                currentPop.preference = (FoodPreference)Random.Range(0, 4);
                currentPop.favoriteIngredient = (RecipeIngredient)Random.Range(0, Ingredient.OPTIONS_COUNT);
                if (Random.value > 0.5f)
                {
                    currentPop.hatedIngredient = (RecipeIngredient)Random.Range(1, Ingredient.OPTIONS_COUNT);
                }
                else
                {
                    currentPop.hatedIngredient = RecipeIngredient.EMPTY;
                }
                building.residents.Add(currentPop);
            }
        }

        for (int i = 0; i < 11; i++)
        {
            GameObject tile = Instantiate(emptyLotFab, new Vector3(2, 0, i - 5), Quaternion.identity);
            WorldTile tileScript = tile.GetComponent<WorldTile>();
            BuildingVacant building = ScriptableObject.CreateInstance<BuildingVacant>();

            building.canvas = mainCanvas;
            building.tile = tileScript;
            tileScript.building = building;

            building.name = "Vacant Lot";

            building.price = 10 * Random.Range(10, 51);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
