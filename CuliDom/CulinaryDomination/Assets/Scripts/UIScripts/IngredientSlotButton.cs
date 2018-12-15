using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSlotButton : MonoBehaviour {
    public FoodTypes type;
    public int position;

    public DishButtonManager manager;

    public void Click()
    {
        manager.IngredientButtonPress(type, position);
    }
}
