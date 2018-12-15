using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierUpgradeButton : MonoBehaviour {

    public GameObject chickentier0, chickentier2, chickentier3, beeftier0, beeftier2, beeftier3, porktier0, porktier2, porktier3;
    public GameObject milktier0, milktier2, milktier3, buttertier0, buttertier2, buttertier3, cheesetier0, cheesetier2, cheesetier3;
    public GameObject ricetier0, ricetier2, ricetier3, wheattier0, wheattier2, wheattier3, potatotier0, potatotier2, potatotier3;
    public GameObject redtier0, redtier2, redtier3, bachtier0, bachtier2, bachtier3, gravytier0, gravytier2, gravytier3;
    public GameObject garlictier0, garlictier2, garlictier3, lettucetier0, lettucetier2, lettucetier3, tomatotier0, tomatotier2, tomatotier3;

    public GameObject ingredientScreen;

    public void OnGUI() {
        //needs to update all the on/off of the tier buttons
    }

    public void UpgradeProtein(int tier)
    {
        if (GameController.Instance().activePlayer.ingredientPoints > 0)
        {
            GameController.Instance().activePlayer.SetIngredientTier(tier, 0);
            switch (tier)
            {
                case 0:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(chickentier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(beeftier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(porktier0);
                    break;
                case 2:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(chickentier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(beeftier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(porktier2);
                    break;
                case 3:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(chickentier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(beeftier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(porktier3);
                    break;
            }

            ingredientScreen.SetActive(false);
            ingredientScreen.SetActive(true);
        }
    }

    public void UpgradeDairy(int tier)
    {
        if (GameController.Instance().activePlayer.ingredientPoints > 0)
        {
            GameController.Instance().activePlayer.SetIngredientTier(tier, 1);
            switch (tier)
            {
                case 0:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(milktier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(cheesetier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(buttertier0);
                    break;
                case 2:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(milktier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(cheesetier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(buttertier2);
                    break;
                case 3:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(milktier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(cheesetier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(buttertier3);
                    break;
            }

            ingredientScreen.SetActive(false);
            ingredientScreen.SetActive(true);
        }
    }

    public void UpgradeStarch(int tier)
    {
        if (GameController.Instance().activePlayer.ingredientPoints > 0)
        {
            GameController.Instance().activePlayer.SetIngredientTier(tier, 2);
            switch (tier)
            {
                case 0:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(ricetier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(wheattier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(potatotier0);
                    break;
                case 2:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(ricetier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(wheattier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(potatotier2);
                    break;
                case 3:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(ricetier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(wheattier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(potatotier3);
                    break;
            }

            ingredientScreen.SetActive(false);
            ingredientScreen.SetActive(true);
        }
    }

    public void UpgradeSauce(int tier)
    {
        if (GameController.Instance().activePlayer.ingredientPoints > 0)
        {
            GameController.Instance().activePlayer.SetIngredientTier(tier, 3);
            switch (tier)
            {
                case 0:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(redtier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(bachtier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(gravytier0);
                    break;
                case 2:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(redtier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(bachtier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(gravytier2);
                    break;
                case 3:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(redtier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(bachtier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(gravytier3);
                    break;
            }

            ingredientScreen.SetActive(false);
            ingredientScreen.SetActive(true);
        }
    }

    public void UpgradeMisc(int tier)
    {
        if (GameController.Instance().activePlayer.ingredientPoints > 0)
        {
            GameController.Instance().activePlayer.SetIngredientTier(tier, 4);
            switch (tier)
            {
                case 0:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(garlictier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(lettucetier0);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(tomatotier0);
                    break;
                case 2:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(garlictier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(lettucetier2);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(tomatotier2);
                    break;
                case 3:
                    GameController.Instance().activePlayer.ingredientPoints -= 1;
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(garlictier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(lettucetier3);
                    GameController.Instance().activePlayer.knownTierUpgrades.Add(tomatotier3);
                    break;
            }

            ingredientScreen.SetActive(false);
            ingredientScreen.SetActive(true);
        }
    }
}
