using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientScreenInfo : MonoBehaviour {

    public GameObject beefTier0, beefTier2, beefTier3, milkTier0, milkTier2, milkTier3, wheatTier0, wheatTier2, wheatTier3, 
        redSauceTier0, redSauceTier2, redSauceTier3, garlicTier0, garlicTier2, garlicTier3;

    public Text ingredientUpgradePoints;

    public GameObject proteinButtonTier0, proteinButtonTier2, proteinButtonTier3;
    public GameObject dairyButtonTier0, dairyButtonTier2, dairyButtonTier3;
    public GameObject starchButtonTier0, starchButtonTier2, starchButtonTier3;
    public GameObject sauceButtonTier0, sauceButtonTier2, sauceButtonTier3;
    public GameObject miscButtonTier0, miscButtonTier2, miscButtonTier3;

    public List<GameObject> allButtons = new List<GameObject>();
    public List<GameObject> allIngredients = new List<GameObject>();


    private void OnEnable()
    {
        ingredientUpgradePoints.text = GameController.Instance().activePlayer.ingredientPoints.ToString();

        if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(beefTier2))
        {
            proteinButtonTier2.SetActive(true);
        }
        else
        {
            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(beefTier0))
            {
                proteinButtonTier0.SetActive(true);
            }

            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(beefTier3))
            {
                proteinButtonTier3.SetActive(true);
            }
        }

        if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(milkTier2))
        {
            dairyButtonTier2.SetActive(true);
        }
        else
        {
            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(milkTier0))
            {
                dairyButtonTier0.SetActive(true);
            }

            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(milkTier3))
            {
                dairyButtonTier3.SetActive(true);
            }
        }

        if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(wheatTier2))
        {
            starchButtonTier2.SetActive(true);
        }
        else
        {
            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(wheatTier0))
            {
                starchButtonTier0.SetActive(true);
            }

            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(wheatTier3))
            {
                starchButtonTier3.SetActive(true);
            }
        }

        if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(redSauceTier2))
        {
            sauceButtonTier2.SetActive(true);
        }
        else
        {
            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(redSauceTier0))
            {
                sauceButtonTier0.SetActive(true);
            }

            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(redSauceTier3))
            {
                sauceButtonTier3.SetActive(true);
            }
        }

        if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(garlicTier2))
        {
            miscButtonTier2.SetActive(true);
        }
        else
        {
            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(garlicTier0))
            {
                miscButtonTier0.SetActive(true);
            }

            if (!GameController.Instance().activePlayer.knownTierUpgrades.Contains(garlicTier3))
            {
                miscButtonTier3.SetActive(true);
            }
        }

        for (int i = 0; i < allIngredients.Count; i++) {

            if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(allIngredients[i])){
                allIngredients[i].SetActive(true);
            }
        }

    }

    private void OnDisable()
    {
        allButtons.ForEach(p => p.SetActive(false));
        allIngredients.ForEach(p => p.SetActive(false));
    }
}
