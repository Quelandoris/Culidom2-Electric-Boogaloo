using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeOptions : MonoBehaviour {

    public GameObject[] recipeTemplateButtons;

    private void OnEnable()
    {
        for (int i = 0; i < recipeTemplateButtons.Length; i++) {
            recipeTemplateButtons[i].SetActive(true);
        }

        if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.AMERICAN)
        {
            for (int i = 0; i < 3; i++)
            {
                recipeTemplateButtons[i].SetActive(false);
            }
        }
        else if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.MEXICAN)
        {
            for (int i = 3; i < 6; i++)
            {
                recipeTemplateButtons[i].SetActive(false);
            }
        }
        else if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.ITALIAN) {
            for (int i = 6; i < 9; i++)
            {
                recipeTemplateButtons[i].SetActive(false);
            }
        }
    }
}
