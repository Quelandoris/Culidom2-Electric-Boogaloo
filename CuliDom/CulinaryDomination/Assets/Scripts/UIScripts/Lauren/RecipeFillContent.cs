using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeFillContent : MonoBehaviour {

    PopulateScrollView createContentScript;
    PlayerData activePlayer;

    public GameObject mainUI;
    public RectTransform recipeContent;

    public List<Button> americanFood;
    public List<Button> italianFood;
    public List<Button> mexicanFood;
    public List<GameObject> americanDisabled;
    public List<GameObject> italianDisabled;
    public List<GameObject> mexicanDisabled;

    private void Awake()
    {
        activePlayer = GameController.Instance().activePlayer;
        createContentScript = mainUI.GetComponent<PopulateScrollView>();
        americanFood = new List<Button>();
        italianFood = new List<Button>();
        mexicanFood = new List<Button>();
    }

    private void OnEnable()
    {
        if(activePlayer.HaveTech(Tech.AMERICAN_STARTER))
        {
            americanFood.ForEach(b => b.enabled = true);
            americanDisabled.ForEach(b => b.SetActive(false));
        }
        if (activePlayer.HaveTech(Tech.ITALIAN_STARTER))
        {
            italianFood.ForEach(b => b.enabled = true);
            italianDisabled.ForEach(b => b.SetActive(false));
        }
        if (activePlayer.HaveTech(Tech.MEXICAN_STARTER))
        {
            mexicanFood.ForEach(b => b.enabled = true);
            mexicanDisabled.ForEach(b => b.SetActive(false));
        }

        createContentScript.CreateSavedRecipeContent(recipeContent);
    }

    private void OnDisable()
    {
        createContentScript.DeleteContent(recipeContent);
    }
}
