using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDish : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // taco dish //////////////////////////////////////////////////////////////////////
        DishData taco = new DishData();
        taco.dishName = "Taco";
        taco.category = DishCategory.MEXICAN;
        taco.requiredFoodSlots.Add(FoodTypes.PROTEIN);
        taco.requiredFoodSlots.Add(FoodTypes.STARCH);

        taco.optionalFoodSlots.Add(FoodTypes.DAIRY);
        DishData.ExportJSON(taco, "Taco.json");

        // enchilada dish///////////////////////////////////////////////////////////////////////
        DishData enchilada = new DishData();
        enchilada.dishName = "Enchilada";
        enchilada.category = DishCategory.MEXICAN;
        enchilada.requiredFoodSlots.Add(FoodTypes.DAIRY);
        enchilada.requiredFoodSlots.Add(FoodTypes.SAUCE);

        enchilada.optionalFoodSlots.Add(FoodTypes.PROTEIN);
        enchilada.optionalFoodSlots.Add(FoodTypes.STARCH);
        enchilada.optionalFoodSlots.Add(FoodTypes.MISC);
        DishData.ExportJSON(enchilada, "Enchillada.json");

        // quesadilla dish//////////////////////////////////////////////////////////////////
        DishData quesadilla = new DishData();
        quesadilla.dishName = "Quesadilla";
        quesadilla.category = DishCategory.MEXICAN;
        quesadilla.requiredFoodSlots.Add(FoodTypes.STARCH);
        quesadilla.requiredFoodSlots.Add(FoodTypes.DAIRY);

        quesadilla.optionalFoodSlots.Add(FoodTypes.MISC);
        quesadilla.optionalFoodSlots.Add(FoodTypes.SAUCE);
        quesadilla.optionalFoodSlots.Add(FoodTypes.PROTEIN);
        DishData.ExportJSON(quesadilla, "Quesadilla.json");

        // pizza dish////////////////////////////////////////////////////////////////////
        DishData pizza = new DishData();
        pizza.dishName = "Pizza";
        pizza.category = DishCategory.ITALIAN;
        pizza.requiredFoodSlots.Add(FoodTypes.STARCH);
        pizza.requiredFoodSlots.Add(FoodTypes.SAUCE);

        pizza.optionalFoodSlots.Add(FoodTypes.PROTEIN);
        pizza.optionalFoodSlots.Add(FoodTypes.DAIRY);
        pizza.optionalFoodSlots.Add(FoodTypes.MISC);
        DishData.ExportJSON(pizza, "Pizza.json");

        // spaghetti dish////////////////////////////////////////////////////////////////////
        DishData spaghetti = new DishData();
        spaghetti.dishName = "Spaghetti";
        spaghetti.category = DishCategory.ITALIAN;
        spaghetti.requiredFoodSlots.Add(FoodTypes.STARCH);
        spaghetti.requiredFoodSlots.Add(FoodTypes.SAUCE);

        spaghetti.optionalFoodSlots.Add(FoodTypes.PROTEIN);
        spaghetti.optionalFoodSlots.Add(FoodTypes.DAIRY);
        spaghetti.optionalFoodSlots.Add(FoodTypes.MISC);
        DishData.ExportJSON(spaghetti, "Spahgetti.json");

        // panini dish////////////////////////////////////////////////////////////////////
        DishData panini = new DishData();
        panini.dishName = "Panini";
        panini.category = DishCategory.ITALIAN;
        panini.requiredFoodSlots.Add(FoodTypes.STARCH);
        panini.requiredFoodSlots.Add(FoodTypes.DAIRY);

        panini.optionalFoodSlots.Add(FoodTypes.PROTEIN);
        panini.optionalFoodSlots.Add(FoodTypes.SAUCE);
        panini.optionalFoodSlots.Add(FoodTypes.MISC);
        DishData.ExportJSON(panini, "Panini.json");

        // burger dish////////////////////////////////////////////////////////////////////
        DishData burger = new DishData();
        burger.dishName = "Burger";
        burger.category = DishCategory.AMERICAN;
        burger.requiredFoodSlots.Add(FoodTypes.STARCH);
        burger.requiredFoodSlots.Add(FoodTypes.PROTEIN);

        burger.optionalFoodSlots.Add(FoodTypes.DAIRY);
        burger.optionalFoodSlots.Add(FoodTypes.SAUCE);
        burger.optionalFoodSlots.Add(FoodTypes.MISC);
        DishData.ExportJSON(burger, "Burger.json");

        // chili dish////////////////////////////////////////////////////////////////////
        DishData chili = new DishData();
        chili.dishName = "Chili";
        chili.category = DishCategory.AMERICAN;
        chili.requiredFoodSlots.Add(FoodTypes.MISC);
        chili.requiredFoodSlots.Add(FoodTypes.PROTEIN);

        chili.optionalFoodSlots.Add(FoodTypes.DAIRY);
        chili.optionalFoodSlots.Add(FoodTypes.SAUCE);
        chili.optionalFoodSlots.Add(FoodTypes.STARCH);
        DishData.ExportJSON(chili, "Chili.json");

        // gumbo dish////////////////////////////////////////////////////////////////////
        DishData gumbo = new DishData();
        gumbo.dishName = "Gumbo";
        gumbo.category = DishCategory.AMERICAN;
        gumbo.requiredFoodSlots.Add(FoodTypes.STARCH);
        gumbo.requiredFoodSlots.Add(FoodTypes.SAUCE);

        gumbo.optionalFoodSlots.Add(FoodTypes.DAIRY);
        gumbo.optionalFoodSlots.Add(FoodTypes.MISC);
        gumbo.optionalFoodSlots.Add(FoodTypes.PROTEIN);
        DishData.ExportJSON(gumbo, "Gumbo.json");
    }
	
}
