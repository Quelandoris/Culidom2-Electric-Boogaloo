using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientUpgrades : MonoBehaviour {

    public GameObject tier0Upgrade, tier2Upgrade, tier3Upgrade;

   // public Button otherUpgrade1, otherUpgrade2, otherUpgrade3, otherUpgrade4;

    public GameObject[] Tier0Displays,Tier2Displays,Tier3Displays;
    public GameObject[] Tier0Buttons, Tier2Buttons, Tier3Buttons;

    private bool tier0 = false, tier2 = false, tier3 = false;

    void Start()
    {
        /*foreach(GameObject go in Tier0Displays)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in Tier2Displays)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in Tier3Displays)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in Tier0Buttons)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in Tier2Buttons)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in Tier3Buttons)
        {
            go.SetActive(false);
        }*/

    }
	
    void CloseUpgrade()
    {
        tier2Upgrade.gameObject.SetActive(false);
        tier0Upgrade.gameObject.SetActive(false);
        tier3Upgrade.gameObject.SetActive(false);
    }

	void Update () {
        //when the player clicks on the other ingredient upgrades the button on the current one closes
        //otherUpgrade1.onClick.AddListener(CloseUpgrade);
        //otherUpgrade2.onClick.AddListener(CloseUpgrade);
        //otherUpgrade3.onClick.AddListener(CloseUpgrade);
        //otherUpgrade4.onClick.AddListener(CloseUpgrade);
        /*if (GameController.Instance().activePlayer.ingredientPoints > 0)
        {

            ingredientUpgrade.gameObject.SetActive(true);
            if (tier0 == true && tier2 == true && tier3 == true)
            {
                ingredientUpgrade.gameObject.SetActive(false);

            }

        }
        else if (GameController.Instance().activePlayer.ingredientPoints <= 0)
        {
            ingredientUpgrade.gameObject.SetActive(false);
            tier2Upgrade.gameObject.SetActive(false);
            tier0Upgrade.gameObject.SetActive(false);
            tier3Upgrade.gameObject.SetActive(false);
        }*/

    }

    public void UpgradeIngredientsButton()
    {
        if (tier2 == false)
        {
            tier2Upgrade.gameObject.SetActive(true);
            tier0Upgrade.gameObject.SetActive(false);
            tier3Upgrade.gameObject.SetActive(false);
        }
        else if (tier2 == true)
        {
            tier2Upgrade.gameObject.SetActive(false);
            if(tier0 == false)
            {
                tier0Upgrade.gameObject.SetActive(true);
                
            }
            if(tier3 == false)
            {
                tier3Upgrade.gameObject.SetActive(true);
            }
        }
    }

    public void Tier2UpgradeButton()
    {
        tier2 = true;
        GameController.Instance().activePlayer.ingredientPoints = GameController.Instance().activePlayer.ingredientPoints - 1;
        foreach (GameObject go in Tier2Displays)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in Tier2Buttons)
        {
            go.SetActive(true);
        }
        tier2Upgrade.gameObject.SetActive(false);
        tier0Upgrade.gameObject.SetActive(true);
        tier3Upgrade.gameObject.SetActive(true);
    }

    public void Tier3UpgradeButton()
    {
        tier3 = true;
        GameController.Instance().activePlayer.ingredientPoints = GameController.Instance().activePlayer.ingredientPoints - 1;
        foreach (GameObject go in Tier3Displays)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in Tier3Buttons)
        {
            go.SetActive(true);
        }
        tier3Upgrade.gameObject.SetActive(false);
    }

    public void Tier0UpgradeButton()
    {
        tier0 = true;
        GameController.Instance().activePlayer.ingredientPoints = GameController.Instance().activePlayer.ingredientPoints - 1;
        foreach (GameObject go in Tier0Displays)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in Tier0Buttons)
        {
            go.SetActive(true);
        }
        tier0Upgrade.gameObject.SetActive(false);
    }



    //make a button for each upgrade tier where it turns the bools true
}
