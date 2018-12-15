using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantOnEnable : MonoBehaviour {

    private void OnEnable()
    {
        MainNavigation.instance.CheckHomeElements();
    }

    public void OnDisable()
    {
        
    }
}
