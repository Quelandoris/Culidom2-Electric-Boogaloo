using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownResturant : MonoBehaviour {

    WorldTile tile;
    Building restaurant;

    public void OnMouseDown()
    {
        Debug.Log("We are clicking a something now");
        tile = GetComponentInParent<WorldTile>();
        restaurant = tile.GetBuilding();

        if (restaurant != null)
        {
            Debug.Log("We got a resturant inside me");
        }
        else {
            Debug.Log("We ait got no resturnat");
        }
    }
}
