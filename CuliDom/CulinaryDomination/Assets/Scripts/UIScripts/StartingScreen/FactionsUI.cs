using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FactionsUI : MonoBehaviour
{

    public GameObject ramseyPortrait, jeffyPortrait, ronaldPortrait, guyPortrait,
        annePortrait, paulaPortrait, ramseyButton, jeffyButton, ronaldButton, guyFierriButton,
        anneBurrelButton, paulaDeenButton, portraitSelection/*, characterImage*/;
    public GameObject factionPanel, createFactionPanel, playerPanel, StartScreenCanvas, RegularGameCanvas, worldGen;
    public GameObject twoPlayers, threePlayers, fourPlayers;
    public Transform twoPlayerButtonOn, twoPlayerButtonOff, threePlayerButtonOn, threePlayerButtonOff, fourPlayerButtonOn, fourPlayerButtonOff;
    public GameObject playerOnePanel, playerTwoPanel, playerThreePanel, playerFourPanel;
    // for when choosing a type of food to start with
    public GameObject /*selectFoodStyle,*/ mexicanFood, italianFood, americanFood/*, mexicanDisplay, italianDisplay,
        americanDisplay*/;
    public InputField playerName, companyName;
    //tooltips that appear when selecting a trait.
    public GameObject qualityChefs, managerAlwaysRight, flavorTown, cheapProduce, cheapLabor, customerService, socialExperiment;
    public GameObject voiceLinesMenu;
    //sound
    GameObject AudioManager;

    //playerName
    Text PlayerNumber;

    //for faction selection and info
    Button selectedFactionButton;
    Button foodToggleButton;
    Button traitsToggleButton;
    public Image selectedFactionImage;
    public Text selectedCharacterName, selectedCharacterVoice, selectedFactionName, selectedFactionFoodType, selectedFactionAbility, selectedFactionAbilityDescription;
    public Text placeholderText, storedText, qualityChefsText, managerText, flavorText, laborText, produceText, serviceText, socialText;

    UnityEvent m_MyEvent = new UnityEvent();
    FactionData currentFaction;
    //public Text traitSelect, foodSelect;
    GameController gameController;
    int whichPlayer = 0;
    public int numPlayers = 0;

    public void Awake()
    {
        gameController = GameController.Instance();
        storedText.text = placeholderText.text;
    }

    public void Start()
    {

    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    //////////////////////////////////////////ChangePlayerNumber/////////////////////////////////////////////////////////////
    void PlayerOneSelected()
    {
        PlayerNumber.text = "1";
    }

    void PlayerTwoSelected()
    {
        PlayerNumber.text = "2";
    }

    void PlayerThreeSelected()
    {
        PlayerNumber.text = "3";
    }

    void PlayerFourSelected()
    {
        PlayerNumber.text = "4";
    }

    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ TRAITS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    /*public void QualityChef()
    {
        //traitSelect.text = "Quality Chefs";
        qualityChefs.SetActive(true);
        managerAlwaysRight.SetActive(false);
        flavorTown.SetActive(false);
        cheapProduce.SetActive(false);
        cheapLabor.SetActive(false);
        customerService.SetActive(false);
        socialExperiment.SetActive(false);
        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

    }

    public void ManagerAlwaysRight()
    {
        //traitSelect.text = "The Manager's Always right!";
        qualityChefs.SetActive(false);
        managerAlwaysRight.SetActive(true);
        flavorTown.SetActive(false);
        cheapProduce.SetActive(false);
        cheapLabor.SetActive(false);
        customerService.SetActive(false);
        socialExperiment.SetActive(false);
        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void FlavorTown()
    {
        //traitSelect.text = "FlavorKingdom";
        qualityChefs.SetActive(false);
        managerAlwaysRight.SetActive(false);
        flavorTown.SetActive(true);
        cheapProduce.SetActive(false);
        cheapLabor.SetActive(false);
        customerService.SetActive(false);
        socialExperiment.SetActive(false);
        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void CheapProduce()
    {
        //traitSelect.text = "Cheap Produce";
        qualityChefs.SetActive(false);
        managerAlwaysRight.SetActive(false);
        flavorTown.SetActive(false);
        cheapProduce.SetActive(true);
        cheapLabor.SetActive(false);
        customerService.SetActive(false);
        socialExperiment.SetActive(false);
        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void CheapLabor()
    {
        //traitSelect.text = "Cheap Labor";
        qualityChefs.SetActive(false);
        managerAlwaysRight.SetActive(false);
        flavorTown.SetActive(false);
        cheapProduce.SetActive(false);
        cheapLabor.SetActive(true);
        customerService.SetActive(false);
        socialExperiment.SetActive(false);
        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void CustomerService()
    {
        //traitSelect.text = "Customer Service";
        qualityChefs.SetActive(false);
        managerAlwaysRight.SetActive(false);
        flavorTown.SetActive(false);
        cheapProduce.SetActive(false);
        cheapLabor.SetActive(false);
        customerService.SetActive(true);
        socialExperiment.SetActive(false);
        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void SocialExperiment()
    {
        //traitSelect.text = "Social Experiment";
        qualityChefs.SetActive(false);
        managerAlwaysRight.SetActive(false);
        flavorTown.SetActive(false);
        cheapProduce.SetActive(false);
        cheapLabor.SetActive(false);
        customerService.SetActive(false);
        socialExperiment.SetActive(true);
        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }*/

    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FACTION CREATION \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    public void FactionConfirmation()
    {
        try
        {
            if (selectedFactionButton != null)
            {
                string name = selectedFactionButton.GetComponentInChildren<Text>().text;
                //Debug.Log("In FactionUI we are setting the faction of " + name + " to the player");
                currentFaction = FactionData.LoadJSON(name + ".json");
                Debug.Log("We are working with " + currentFaction.factionName + " faction. Lets give it to player "+(whichPlayer+1));
                GameController.Instance().player[whichPlayer].playerFaction = currentFaction;
                whichPlayer += 1; // go up by one to set whichPlayer back to non index form
                Debug.Log("Player has a faction");
                TurnOnPlease();
                ResetFactionToggles();

                switch (whichPlayer)
                {
                    case 1: // pick 2 player panel
                        AttachPortrait(playerOnePanel.transform);
                        break;
                    case 2: // pick 3 player panel
                        AttachPortrait(playerTwoPanel.transform);
                        break;
                    case 3: // pick 4 player panel
                        AttachPortrait(playerThreePanel.transform);
                        break;
                    case 4:
                        AttachPortrait(playerFourPanel.transform); ;
                        break;
                }
            }
        }
        catch (System.Exception e)
        {
            throw e;
        }
        ResetFactionCreation();
    }

    // Gets called when clciking a certain faction to play as
    public void FactionSelection(Button button)
    {
        ToggleFactionButton();
        selectedFactionButton = button;
        ToggleFactionButton();
        FactionData tempSelectedData = FactionData.LoadJSON(button.GetComponentInChildren<Text>().text + ".json");
        selectedFactionImage.sprite = tempSelectedData.playerPortrait;
        selectedCharacterName.text = tempSelectedData.playerName;
        selectedCharacterVoice.text = tempSelectedData.voiceNames[tempSelectedData.voice];
        selectedFactionName.text = tempSelectedData.factionName;
        selectedFactionFoodType.text = tempSelectedData.foodName[tempSelectedData.style];
        selectedFactionAbility.text = tempSelectedData.attributeNames[tempSelectedData.attribute];
        selectedFactionAbilityDescription.text = tempSelectedData.attributeDefinitions[tempSelectedData.attribute];
    }

    public void ToggleFactionButton()
    {
        if (selectedFactionButton != null)
        {

            selectedFactionButton.GetComponentInChildren<Text>().color = (selectedFactionButton.GetComponentInChildren<Text>().color == Color.white) ? new Color(0.88f, 0.9f, 0.48f) : Color.white;

            Image tempImage = selectedFactionButton.GetComponentInChildren<Text>().transform.parent.GetComponent<Image>();
            tempImage.color = (tempImage.color == Color.white) ? new Color(0.64f, 0.64f, 0.64f) : Color.white;
        }
    }

    public void ResetFactionToggles()
    {
        ToggleFactionButton();
        selectedFactionButton = null;
        selectedFactionImage.sprite = null;
        selectedCharacterName.text = "Founder Name";
        selectedCharacterVoice.text = "Founder Voice";
        selectedFactionName.text = "Franchise Name";
        selectedFactionFoodType.text = "Food Type";
        selectedFactionAbility.text = "Founder Ability";
        selectedFactionAbilityDescription.text = "Ability Description";
    }

    public void TurnOnPlease()
    {
        factionPanel.SetActive(false);
        playerPanel.SetActive(true);
    }

    // calls when you want to create your very own faction
    public void CreateFaction()
    {
        factionPanel.SetActive(false);
        createFactionPanel.SetActive(true);
        currentFaction = new FactionData();

        CreateAFaction newFaction = new CreateAFaction();

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

    }

    public void ResetFactionCreation()
    {
        //selectFoodStyle.SetActive(true);

        ramseyPortrait.gameObject.SetActive(false);
        jeffyPortrait.gameObject.SetActive(false);
        ronaldPortrait.gameObject.SetActive(false);
        guyPortrait.gameObject.SetActive(false);
        annePortrait.gameObject.SetActive(false);
        paulaPortrait.gameObject.SetActive(false);
        portraitSelection.gameObject.SetActive(false);

        FoodToggleHighlight();
        TraitsToggleHighlight();
        traitsToggleButton = null;
        foodToggleButton = null;

        //change dropdown value back to 0
        voiceLinesMenu.GetComponent<Dropdown>().value = 0;

        playerName.text = "";
        companyName.text = "";
        placeholderText.text = "Trait Description";
        //traitSelect.text = "";

        //play sounds?
        //AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();

    }

    // find the right player button in the panel
    public void FindPlayerChildButton(GameObject panel)
    {
        for (int i = 0; i < panel.transform.childCount; i++)
        {
            Transform child = panel.transform.GetChild(i);
            string[] fullName = child.transform.name.Split(' ');
            if (whichPlayer == int.Parse(fullName[1]))
            {
                whichPlayer -= 1;
                AttachPortrait(child);
                // setting whichPlayer back to index form
                break;
            }
        }
    }

    // get the image to place the portrait there 
    public void AttachPortrait(Transform playerButton)
    {
        int count = 0;
        for (int i = 0; i < playerButton.childCount; i++)
        {
            Transform child = playerButton.GetChild(i);
            Text childText = null;
            Image childImage = null;
            Debug.Log(child.name);
            if ((childImage = child.gameObject.GetComponent<Image>()) != null)
            {
                if (count == 1)
                {
                    childImage.GetComponent<Image>().sprite = gameController.player[(whichPlayer - 1)].playerFaction.playerPortrait;
                }
            }

            if ((childText = child.gameObject.GetComponent<Text>()) != null)
            {

                childText.GetComponent<Text>().text = gameController.player[(whichPlayer - 1)].playerFaction.factionName;
            }

            count++;
        }
    }

    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ HOTSEAT/PLAYER STUFF \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    public void PlayerNumSelect(int num)
    {
        EventSystem.current.SetSelectedGameObject(null);
        numPlayers = num;
        gameController.SetNumPlayers(num);
        TurnOnPanel(num);
    }

    public void PlayerClick(int num)
    {

        Debug.Log("Beginning of PlayerClick");
        whichPlayer = num - 1;


        Debug.Log("Set whichPlayer");
        playerPanel.SetActive(false);
        factionPanel.SetActive(true);
        Debug.Log("Swithed panels");

    }

    public void PlayButton()
    {
        bool check = true;
        for (int i = 0; i < gameController.player.Length; i++)
        {
            if (gameController.player[i].playerFaction == null)
            {

                check = false;
            }
        }

        if (check)
        {
            for (int i = 0; i < gameController.player.Length; i++) {
                if (gameController.player[i].playerFaction.style == FactionStyle.AMERICAN) {
                    gameController.player[i].LearnTech(Tech.AMERICAN_STARTER);
                }
                if (gameController.player[i].playerFaction.style == FactionStyle.MEXICAN) {
                    gameController.player[i].LearnTech(Tech.MEXICAN_STARTER);
                }
                if (gameController.player[i].playerFaction.style == FactionStyle.ITALIAN) {
                    gameController.player[i].LearnTech(Tech.ITALIAN_STARTER);
                }
            }
            StartScreenCanvas.SetActive(false);
            RegularGameCanvas.SetActive(true);
            worldGen.SetActive(true);

        }
        else
        {
            Debug.Log("We can't play the game");
        }

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }

    public void TurnOnPanel(int panel)
    {
        switch (panel)
        {
            case 2:
                playerOnePanel.SetActive(true);
                playerTwoPanel.SetActive(true);
                playerThreePanel.SetActive(false);
                playerFourPanel.SetActive(false);
                twoPlayers.transform.position = twoPlayerButtonOn.position;
                threePlayers.transform.position = threePlayerButtonOff.position;
                fourPlayers.transform.position = fourPlayerButtonOff.position;
                break;
            case 3:
                playerOnePanel.SetActive(true);
                playerTwoPanel.SetActive(true);
                playerThreePanel.SetActive(true);
                playerFourPanel.SetActive(false);
                twoPlayers.transform.position = twoPlayerButtonOff.position;
                threePlayers.transform.position = threePlayerButtonOn.position;
                fourPlayers.transform.position = fourPlayerButtonOff.position;
                break;
            case 4:
                playerOnePanel.SetActive(true);
                playerTwoPanel.SetActive(true);
                playerThreePanel.SetActive(true);
                playerFourPanel.SetActive(true);
                twoPlayers.transform.position = twoPlayerButtonOff.position;
                threePlayers.transform.position = threePlayerButtonOff.position;
                fourPlayers.transform.position = fourPlayerButtonOn.position;
                break;
        }
    }

    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\  OTHER BUTTONS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    /*public void SelectFoodType()
    {
        selectFoodStyle.gameObject.SetActive(false);
        mexicanDisplay.gameObject.SetActive(false);
        italianDisplay.gameObject.SetActive(false);
        americanDisplay.gameObject.SetActive(false);

        mexicanFood.gameObject.SetActive(true);
        italianFood.gameObject.SetActive(true);
        americanFood.gameObject.SetActive(true);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

    }*/

    /*public void MexicanButton()
    {
        //selectFoodStyle.gameObject.SetActive(false);
        //mexicanDisplay.gameObject.SetActive(true);
        //italianDisplay.gameObject.SetActive(false);
        //americanDisplay.gameObject.SetActive(false);
        //foodSelect.text = "Mexican Food";
        mexicanFood.gameObject.SetActive(false);
        italianFood.gameObject.SetActive(false);
        americanFood.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();

    }

    public void ItalianButton()
    {
        selectFoodStyle.gameObject.SetActive(false);
        //mexicanDisplay.gameObject.SetActive(false);
        //italianDisplay.gameObject.SetActive(true);
        //americanDisplay.gameObject.SetActive(false);
        //foodSelect.text = "Italian Food";
        mexicanFood.gameObject.SetActive(false);
        italianFood.gameObject.SetActive(false);
        americanFood.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();

    }

    public void AmericanButton()
    {
        selectFoodStyle.gameObject.SetActive(false);
        //mexicanDisplay.gameObject.SetActive(false);
        //italianDisplay.gameObject.SetActive(false);
        //americanDisplay.gameObject.SetActive(true);
        //foodSelect.text = "American Food";
        mexicanFood.gameObject.SetActive(false);
        italianFood.gameObject.SetActive(false);
        americanFood.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();

    }*/
    // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ PORTRAIT BUTTONS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    public void OpenPortraitSelect()
    {

        portraitSelection.gameObject.SetActive(true);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
    }

    public void RamseyButton()
    {
        ramseyPortrait.gameObject.SetActive(true);
        jeffyPortrait.gameObject.SetActive(false);
        ronaldPortrait.gameObject.SetActive(false);
        guyPortrait.gameObject.SetActive(false);
        annePortrait.gameObject.SetActive(false);
        paulaPortrait.gameObject.SetActive(false);
        portraitSelection.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();

    }
    public void JeffyButton()
    {
        ramseyPortrait.gameObject.SetActive(false);
        jeffyPortrait.gameObject.SetActive(true);
        ronaldPortrait.gameObject.SetActive(false);
        guyPortrait.gameObject.SetActive(false);
        annePortrait.gameObject.SetActive(false);
        paulaPortrait.gameObject.SetActive(false);
        portraitSelection.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }
    public void RonaldButton()
    {
        ramseyPortrait.gameObject.SetActive(false);
        jeffyPortrait.gameObject.SetActive(false);
        ronaldPortrait.gameObject.SetActive(true);
        guyPortrait.gameObject.SetActive(false);
        annePortrait.gameObject.SetActive(false);
        paulaPortrait.gameObject.SetActive(false);
        portraitSelection.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }
    public void GuyFierriButton()
    {
        ramseyPortrait.gameObject.SetActive(false);
        jeffyPortrait.gameObject.SetActive(false);
        ronaldPortrait.gameObject.SetActive(false);
        guyPortrait.gameObject.SetActive(true);
        annePortrait.gameObject.SetActive(false);
        paulaPortrait.gameObject.SetActive(false);
        portraitSelection.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }
    public void AnneBurrelButton()
    {
        ramseyPortrait.gameObject.SetActive(false);
        jeffyPortrait.gameObject.SetActive(false);
        ronaldPortrait.gameObject.SetActive(false);
        guyPortrait.gameObject.SetActive(false);
        annePortrait.gameObject.SetActive(true);
        paulaPortrait.gameObject.SetActive(false);
        portraitSelection.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }
    public void PaulaDeenButton()
    {
        ramseyPortrait.gameObject.SetActive(false);
        jeffyPortrait.gameObject.SetActive(false);
        ronaldPortrait.gameObject.SetActive(false);
        guyPortrait.gameObject.SetActive(false);
        annePortrait.gameObject.SetActive(false);
        paulaPortrait.gameObject.SetActive(true);
        portraitSelection.gameObject.SetActive(false);

        //play sounds?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
    }

    ////////////////////////////////////////////////////Highlight Active Button////////////////////////////////////////////////////////
    public void TraitsHighlightButton(Button button)
    {
        TraitsToggleHighlight();
        traitsToggleButton = button;
        TraitsToggleHighlight();
    }

    public void TraitsToggleHighlight()
    {
        if (traitsToggleButton != null)
        {

            traitsToggleButton.GetComponentInChildren<Text>().color = (traitsToggleButton.GetComponentInChildren<Text>().color == Color.white) ? new Color(0.88f, 0.9f, 0.48f) : Color.white;

            Image tempImage = traitsToggleButton.GetComponentInChildren<Text>().transform.parent.GetComponent<Image>();
            tempImage.color = (tempImage.color == Color.white) ? new Color(0.64f, 0.64f, 0.64f) : Color.white;
        }
    }

    public void FoodHighlightButton(Button button)
    {
        FoodToggleHighlight();
        foodToggleButton = button;
        FoodToggleHighlight();
    }

    public void FoodToggleHighlight()
    {
        if (foodToggleButton != null)
        {

            foodToggleButton.GetComponentInChildren<Text>().color = (foodToggleButton.GetComponentInChildren<Text>().color == Color.white) ? new Color(0.88f, 0.9f, 0.48f) : Color.white;

            Image tempImage = foodToggleButton.GetComponentInChildren<Text>().transform.parent.GetComponent<Image>();
            tempImage.color = (tempImage.color == Color.white) ? new Color(0.64f, 0.64f, 0.64f) : Color.white;
        }
    }

    public void PlaceholderTextHover(Text referenceText)
    {
        placeholderText.text = referenceText.text;
    }

    public void PlaceholderTextChange(Text referenceText)
    {
        placeholderText.text = referenceText.text;
        storedText.text = referenceText.text;
    }
}