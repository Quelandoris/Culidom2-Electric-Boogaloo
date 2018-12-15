using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAFaction : MonoBehaviour {

    FactionData faction;
    int playerNum;

    public InputField nameInput, companyInput;
    public Dropdown voiceDropDown;
    public GameObject buttonprefab, createFactionPanel, factionPanel;
    public RectTransform content;
    public Sprite burgerSprite, tacoSprite, pizzaSprite;

    //public Image baseCharacterImage;
  //  public GameObject italianDisplay, mexicanDisplay, americanDisplay, baseFoodDisplay;

    FactionsUI factionScript;
    VoicePacks voiceScript;

    public CreateAFaction()
    {
        faction = new FactionData();
        
    }

    public void Start()
    {
        nameInput.onEndEdit.AddListener(delegate { LockNameInput(nameInput); });
        companyInput.onEndEdit.AddListener(delegate { LockCompanyInput(companyInput); });
        voiceDropDown.onValueChanged.AddListener( delegate { DropdownValueChanged(voiceDropDown); } );
        factionScript = FindObjectOfType<FactionsUI>();
        voiceScript = FindObjectOfType<VoicePacks>();

    }

    // after pressing enter on player input field
    public void LockNameInput(InputField input) {
        Debug.Log(input.text);
        faction.playerName = input.text;
        Debug.Log("Name was changed");
    }

    // after pressing enter on player input field
    public void LockCompanyInput(InputField input)
    {
        Debug.Log(input.text);
        faction.factionName = input.text;
        Debug.Log("company name was changed");
    }

    public void DropdownValueChanged(Dropdown dropDown) {
        switch (dropDown.captionText.text) {
            case "Rough English":
                //faction.voice = 0;
                faction.voice = VoiceType.GORDON;
                try
                {
                    voiceScript.PlayWinVO((int)VoiceType.GORDON);
                }
                catch { }
                Debug.Log("Gordomn voice was cahanged");
                break;
            case "Greedy":
               // faction.voice = 1;
                faction.voice = VoiceType.DONALD;
                Debug.Log("Donals voice was cahanged");
                try
                {
                    // AudioManger.Play() "Donal McRonald win"
                    voiceScript.PlayHireChefVO((int)VoiceType.DONALD);
                }
                catch { }
                break;
            case "Flavor Kingdom":
               // faction.voice = 2;
                faction.voice = VoiceType.GUY;
                Debug.Log("Giys voice was cahanged");
                try
                {
                    // AudioManger.Play() "Guy Fieri win"
                    voiceScript.PlayHireChefVO((int)VoiceType.GUY);
                }
                catch { }
                break;
            case "Robot":
               // faction.voice = 3;
                faction.voice = VoiceType.ROBOT;
                Debug.Log("Ane voice was cahanged");
                try
                {
                    // AudioManger.Play() "Shy win"
                    voiceScript.PlayHireChefVO((int)VoiceType.ROBOT);
                }
                catch { }
                break;
            case "Country":
              //  faction.voice = 4;
                faction.voice = VoiceType.PAULA;
                Debug.Log("Paula voice was cahanged");
                try
                {
                    // AudioManger.Play() "Paula Deen win"
                    voiceScript.PlayHireChefVO((int)VoiceType.PAULA);
                }
                catch { }
                break;
            case "Snek Pupp":
               // faction.voice = 5;
                faction.voice = VoiceType.ANTONIO;
                Debug.Log("Sneks voice was cahanged");
                try
                {
                    // AudioManger.Play() "Snek Pup win"
                    voiceScript.PlayHireChefVO((int)VoiceType.ANTONIO);
                }
                catch { }
                break;
            case "Shy":
                // faction.voice = 6;
                faction.voice = VoiceType.SHY;
                Debug.Log("Sneks voice was cahanged");
                try
                {
                    // AudioManger.Play() "Snek Pup win"
                    voiceScript.PlayHireChefVO((int)VoiceType.SHY);
                }
                catch { }
                break;
            default:
                Debug.Log("Do we have a new voice type??");
                break;
        }
    }

    public void FoodStyle(string foodStyle) {
        switch (foodStyle) {
            case "AMER":
                //faction.style = 0;
                faction.style = FactionStyle.AMERICAN;
                Debug.Log("American syle was cahanged");
                break;
            case "MEX":
                //faction.style = 1;
                faction.style = FactionStyle.MEXICAN;
                Debug.Log("Gordomn syle was cahanged");
                break;
            case "ITAL":
                //faction.style = 2;
                faction.style = FactionStyle.ITALIAN;
                Debug.Log("Gordomn syle was cahanged");
                break;
        }
    }

    public void FactionPicture(Button button) {
        Sprite pic = button.GetComponent<Image>().sprite;
        faction.playerPortrait = pic;
        Debug.Log("We cahnged the pic og the faction");
    }

    public void FactionAttribute(string trait) {
        switch (trait) {
            case "QUALITY":
                faction.attribute = Attribute.QUALITY;
                break;
            case "MANAGERRIGHT":
                faction.attribute = Attribute.MANAGERRIGHT;
                break;
            case "FLAVOR":
                faction.attribute = Attribute.FLAVOR;
                break;
            case "CHEAPLABOR":
                faction.attribute = Attribute.CHEAPLABOR;
                break;
            case "CHEAPPRODUCE":
                faction.attribute = Attribute.CHEAPPRODUCE;
                break;
            case "SERVICE":
                faction.attribute = Attribute.SERVICE;
                break;
            case "SOCIAL":
                faction.attribute = Attribute.EXPERIMENT;
                break;
        }
    }

    public void SaveFaction() {
        if ((faction.factionName != null) && (faction.playerName != null) && (faction.voice != VoiceType.COUNT) && (faction.style != FactionStyle.COUNT) && (faction.attribute != Attribute.COUNT))
        {
            Debug.Log("You can move on to faction screen");
            createFactionPanel.SetActive(false);
            factionPanel.SetActive(true);
            FactionData.ExportJSON(faction, faction.factionName + ".json");
            GameObject newButton = Instantiate(buttonprefab);
            newButton.transform.SetParent(content.transform);
            newButton.GetComponent<Button>().onClick.AddListener(delegate { factionScript.FactionSelection(newButton.GetComponent<Button>()); });
            newButton.transform.localScale = new Vector3(1, 1, 1);
            content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 20);

            for (int i = 0; i < newButton.transform.childCount; i++)
            {
                Transform child = newButton.transform.GetChild(i);
                Image childImage = null;
                Debug.Log(child.name);
                if ((childImage = child.GetComponent<Image>()) != null)
                {
                    if (child.name == "Pic") { 
                        childImage.GetComponent<Image>().sprite = faction.playerPortrait;
                    }
                    if (child.name == "FoodPic")
                    {
                        switch (faction.style)
                        {
                            case FactionStyle.AMERICAN:
                                child.gameObject.GetComponent<Image>().sprite = burgerSprite;
                                break;
                            case FactionStyle.ITALIAN:
                                child.gameObject.GetComponent<Image>().sprite = pizzaSprite;
                                break;
                            case FactionStyle.MEXICAN:
                                child.gameObject.GetComponent<Image>().sprite = tacoSprite;
                                break;
                        }
                    }
                }
            }

            newButton.GetComponentInChildren<Text>().text = faction.factionName;

            factionScript.ResetFactionCreation();
        }
        else {
            Debug.Log("You can't move on");
        }
    }

    public void PurgeFactionData()
    {
        faction.factionName = null;
        faction.playerName = null;
        faction.voice = VoiceType.COUNT;
        faction.style = FactionStyle.COUNT;
        faction.attribute = Attribute.COUNT;
        faction.playerPortrait = null;

}

}
