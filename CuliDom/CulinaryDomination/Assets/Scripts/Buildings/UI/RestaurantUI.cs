using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantUI : MonoBehaviour {

    //public Text nameText;
    public BuildingRestaurant building;
    public Image restaurantRating;
    public LittleChefScrollView chefRestaurantContent;

    public void FillFields(string name)
    {
        //nameText.text = name;
    }

    /*public void FillChefs() {
        chefRestaurantContent.CreateContent(building);
    }

    public void DeleteChefs() {
        chefRestaurantContent.DeleteContent();
    }*/

    public void Close() {
        building.UnClick();
        //DeleteChefs();
    }

    public void UpdateRating() {
        restaurantRating.fillAmount = Mathf.Round((float)building.GetRating()) / 10;
    }
}
