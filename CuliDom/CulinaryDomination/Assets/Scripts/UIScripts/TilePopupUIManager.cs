using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePopupUIManager : MonoBehaviour {

    public GameObject RoadPopup, VacantPopup, OwnedRestaurantPopup, EnemyRestaurantPopup, DistrictPopup;

    Vector3 origOwned, origEnemy;
    Vector2 origResident, origRoad, origVacant, origDistrict;

    Building currentBuilding;

    private void Awake()
    {
        origOwned = OwnedRestaurantPopup.transform.localPosition;
        origEnemy = EnemyRestaurantPopup.transform.localPosition;

        origRoad = RoadPopup.GetComponent<RectTransform>().anchoredPosition;
        origVacant = VacantPopup.GetComponent<RectTransform>().anchoredPosition;
        origDistrict = DistrictPopup.GetComponent<RectTransform>().anchoredPosition;

        CloseUI();
    }

    public void CloseUI()
    {
        RoadPopup.SetActive(false);
        VacantPopup.SetActive(false);
        OwnedRestaurantPopup.SetActive(false);
        EnemyRestaurantPopup.SetActive(false);
        DistrictPopup.SetActive(false);
    }

    /*
    public GameObject OpenResidential()
    {
        CloseUI();
        ResidentPopup.SetActive(true);
        ResidentPopup.GetComponent<RectTransform>().anchoredPosition = origResident;
        return ResidentPopup;
    }
    */
    public GameObject OpenDistrict()
    {
        CloseUI();
        DistrictPopup.SetActive(true);
        DistrictPopup.GetComponent<RectTransform>().anchoredPosition = origDistrict;
        return DistrictPopup;
    }

    public GameObject OpenRoad()
    {
        CloseUI();
        RoadPopup.SetActive(true);
        RoadPopup.GetComponent<RectTransform>().anchoredPosition = origRoad;
        return RoadPopup;
    }

    public GameObject OpenVacant()
    {
        CloseUI();
        VacantPopup.SetActive(true);
        VacantPopup.GetComponent<RectTransform>().anchoredPosition = origVacant;
        return VacantPopup;
    }

    public GameObject OpenOwnedRestaurant()
    {
        CloseUI();
        OwnedRestaurantPopup.SetActive(true);
        OwnedRestaurantPopup.transform.localPosition = origOwned; // might be the problem for the null reference :Antonio
        return OwnedRestaurantPopup;
    }

    public GameObject OpenEnemyRestaurant()
    {
        CloseUI();
        EnemyRestaurantPopup.SetActive(true);
        EnemyRestaurantPopup.transform.localPosition = origEnemy;
        return EnemyRestaurantPopup;
    }
}
