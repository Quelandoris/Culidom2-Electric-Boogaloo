using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootlegIngredientTiersCheck : MonoBehaviour {

    public GameObject beefTier0, beefTier2, beefTier3, milkTier0, milkTier2, milkTier3, wheatTier0, wheatTier2, wheatTier3,
        redSauceTier0, redSauceTier2, redSauceTier3, garlicTier0, garlicTier2, garlicTier3;

    public List<GameObject> allProteinTier0 = new List<GameObject>();
    public List<GameObject> allProteinTier2 = new List<GameObject>();
    public List<GameObject> allProteinTier3 = new List<GameObject>();

    public List<GameObject> allDairyTier0 = new List<GameObject>();
    public List<GameObject> allDairyTier2 = new List<GameObject>();
    public List<GameObject> allDairyTier3 = new List<GameObject>();

    public List<GameObject> allStarchTier0 = new List<GameObject>();
    public List<GameObject> allStarchTier2 = new List<GameObject>();
    public List<GameObject> allStarchTier3 = new List<GameObject>();

    public List<GameObject> allSauceTier0 = new List<GameObject>();
    public List<GameObject> allSauceTier2 = new List<GameObject>();
    public List<GameObject> allSauceTier3 = new List<GameObject>();

    public List<GameObject> allMiscTier0 = new List<GameObject>();
    public List<GameObject> allMiscTier2 = new List<GameObject>();
    public List<GameObject> allMiscTier3 = new List<GameObject>();

    private void OnEnable()
    {
        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(beefTier0)){
            allProteinTier0.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(beefTier2))
        {
            allProteinTier2.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(beefTier3))
        {
            allProteinTier3.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(milkTier0))
        {
            allDairyTier0.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(milkTier2))
        {
            allDairyTier2.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(milkTier3))
        {
            allDairyTier3.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(wheatTier0))
        {
            allStarchTier0.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(wheatTier2))
        {
            allStarchTier2.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(wheatTier3))
        {
            allStarchTier3.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(redSauceTier0))
        {
            allSauceTier0.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(redSauceTier2))
        {
            allSauceTier2.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(redSauceTier3))
        {
            allSauceTier3.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(garlicTier0))
        {
            allMiscTier0.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(garlicTier2))
        {
            allMiscTier2.ForEach(p => p.SetActive(true));
        }

        if (GameController.Instance().activePlayer.knownTierUpgrades.Contains(garlicTier3))
        {
            allMiscTier3.ForEach(p => p.SetActive(true));
        }
    }
}
