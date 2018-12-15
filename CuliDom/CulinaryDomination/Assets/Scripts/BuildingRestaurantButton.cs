using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingRestaurantButton : MonoBehaviour {

    public Text restaurantName, districtLocation, estimatedProfit, estimatedScience, upgradeName, turnsUntilFinishedUpgrade, totalUpkeep, workerText;
    public string buildingName, buildingDistrict, buildingEstimatedProfit, buildingEstimatedScience, buildingUpgrade, buildingTurnsTillUpgrade, buildingTotalUpkeep, buildingWorkers;
    public Image satisfaction;
    public float buildingSatisfaction;

    public void UpdateText() {
        restaurantName.text = buildingName;
        districtLocation.text = buildingDistrict;
        estimatedProfit.text = buildingEstimatedProfit;
        estimatedScience.text = buildingEstimatedScience;
        totalUpkeep.text = buildingTotalUpkeep;
        workerText.text =  buildingWorkers;
        satisfaction.fillAmount = buildingSatisfaction;
        upgradeName.text = buildingUpgrade;
        turnsUntilFinishedUpgrade.text = buildingTurnsTillUpgrade;
    }


}
