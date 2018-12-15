using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmpireScreenInfo : MonoBehaviour {

    public Image playerPortrait;

    public Text playerName, franchiseName, money, science, trait, traitDescription;

    public GameObject mainUI, restaurantScreen, chefScreen;

    public RectTransform restaurantContent, chefContent;

    PlayerData activePlayer;
    PopulateScrollView createContentScript;

    private void Awake()
    {
        activePlayer = GameController.Instance().activePlayer;
        createContentScript = mainUI.GetComponent<PopulateScrollView>();
    }

    private void OnEnable()
    {
        //playerPortrait.sprite = activePlayer.playerFaction.playerPortrait;
        playerName.text = activePlayer.playerFaction.playerName;
        franchiseName.text = activePlayer.playerFaction.factionName;
        money.text = Mathf.Floor((float)activePlayer.GetMoney()).ToString();
        science.text = activePlayer.GetTechPointRate().ToString();
        trait.text = activePlayer.playerFaction.attributeNames[activePlayer.playerFaction.attribute];
        traitDescription.text = activePlayer.playerFaction.attributeDefinitions[activePlayer.playerFaction.attribute];

        createContentScript.CreateRestaurantContent(restaurantContent);
        //createContentScript.CreateChefContent(chefContent);

        restaurantScreen.SetActive(true);
        chefScreen.SetActive(false);

    }

    private void OnDisable()
    {
        playerPortrait.sprite = null;
        playerName.text = "Name";
        franchiseName.text = "Franchise Name";
        money.text = "$$";
        science.text = "##";
        trait.text = "Trait";
        traitDescription.text = "Description";

        createContentScript.DeleteContent(restaurantContent);
        createContentScript.DeleteContent(chefContent);
    }
}
