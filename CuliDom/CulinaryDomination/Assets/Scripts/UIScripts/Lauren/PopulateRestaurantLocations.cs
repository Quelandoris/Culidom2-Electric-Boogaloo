using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateRestaurantLocations : MonoBehaviour {

    /*public GameObject restaurantLocationPrefab, chefInfoPrefab;
    public RectTransform content;

    private void PopulateRestaurants()
    {
        for (int i = 0; i < GameController.Instance().activePlayer.ownedRestaurants.Count; i++)
        {
            if (GameController.Instance().activePlayer.ownedRestaurants[i] != chefInfoPrefab.GetComponent<ChefScript>().chefClass.myRestaurant)
            {
                GameObject restaurantLocation = Instantiate(restaurantLocationPrefab);
                restaurantLocation.transform.SetParent(content);
                content.sizeDelta = new Vector2(content.sizeDelta.x, content.sizeDelta.y + 60);
                restaurantLocation.transform.localScale = new Vector3(1f, 1f, 1f);

                restaurantLocation.GetComponentInChildren<Text>().text = GameController.Instance().activePlayer.ownedRestaurants[i].name;

                AssignChefToRestaurant tempAssignScript = restaurantLocation.GetComponent<AssignChefToRestaurant>();
                tempAssignScript.targetChef = chefInfoPrefab.GetComponent<ChefScript>().chefClass;
                tempAssignScript.targetRestaurant = GameController.Instance().activePlayer.ownedRestaurants[i];
            }
        }
    }*/
}
