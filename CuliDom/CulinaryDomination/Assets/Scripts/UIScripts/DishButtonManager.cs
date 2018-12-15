using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishButtonManager : MonoBehaviour {

    public GameObject dairyPanel, proteinPanel, saucePanel, starchPanel, miscPanel;         // canvases with selective buttons
    public GameObject buttonFab;
    public Button saveRecipieButton;
    public GameObject dishCreationPanel, recipeManagerPanel, initialDishButtonPanel;
    public GameObject dishImage, textInput;
    public Button dairyButton, proteinButton, sauceButton, starchButton, miscButton;

    public GameObject dairyTab, proteinTab, sauceTab, starchTab, miscTab;

    public InputField mainInputField;



    //work to make ingredients show correctly
    public RectTransform[] imagePositions;
    public GameObject chickenImage, beefImage, porkImage, wheatImage, riceImage, potatoeImage, milkImage, cheeseImage, butterImage,
        bachamelImage, redSauceImage, gravyImage, tomatoeImage, garlicImage, lettuceImage;
    //public IngredientButtons ingredientButtonManager;
    //[HideInInspector]
    GameObject[] ingredientImages = new GameObject[0];
    GameObject selectedImage;
    //public RectTransform referenceObject;



    //public ScrollRect MexicanScroll, AmericanScroll, ItalianScroll;

    CameraMovement cameraScript;

    public Image[] foodImages = new Image[9];

    public RectTransform[] buttonPositions;
    List<GameObject> ingredientButtons = new List<GameObject>();

    public RectTransform ingredientButtonParent;

    DishData currentDish;

    Recipe currentRecipe;

    VoicePacks voiceScript;

    int selectedSlot;

    Recipe editing = null;

    GameController gameController;
    CreateSavedRecipeButtons createSavedButtonScript;

    //sounds
    GameObject AudioManager;


    public void Awake()
    {
        gameController = GameController.Instance();
        createSavedButtonScript = FindObjectOfType<CreateSavedRecipeButtons>();
        cameraScript = FindObjectOfType<CameraMovement>();
        voiceScript = FindObjectOfType<VoicePacks>();
    }

    public void Start()
    {
        mainInputField.onEndEdit.AddListener(delegate { LockInput(mainInputField); });
        mainInputField.characterLimit = 15; // set max size of recipe name
    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    public void IngredientButtonPress(FoodTypes type, int slot)
    {
        dairyPanel.gameObject.SetActive(false);
        proteinPanel.gameObject.SetActive(false);
        saucePanel.gameObject.SetActive(false);
        starchPanel.gameObject.SetActive(false);
        miscPanel.gameObject.SetActive(false);
        TurnOnDishCategoryButtons();

        switch (type)
        {
            case FoodTypes.DAIRY:
                dairyPanel.gameObject.SetActive(true);
                //Play dairy sound
                try
                {
                    AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
                }
                catch { }

                if (slot < 2)
                {
                    TurnOffDishCategoryButtons();
                }
                else {
                    TurnOnDishCategoryButtons();
                }
                break;
            case FoodTypes.MISC:
                miscPanel.gameObject.SetActive(true);
                //play misc sound
                try
                {
                    AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
                }
                catch { }

                if (slot < 2)
                {
                    TurnOffDishCategoryButtons();
                }
                else
                {
                    TurnOnDishCategoryButtons();
                }
                break;
            case FoodTypes.PROTEIN:
                proteinPanel.gameObject.SetActive(true);
                //play protien sound
                try
                {
                    AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
                }
                catch { }
                if (slot < 2)
                {
                    TurnOffDishCategoryButtons();
                }
                else
                {
                    TurnOnDishCategoryButtons();
                }
                break;
            case FoodTypes.SAUCE:
                saucePanel.gameObject.SetActive(true);
                //play sauce sound
                try
                {
                    AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
                }
                catch { }
                if (slot < 2)
                {
                    TurnOffDishCategoryButtons();
                }
                else
                {
                    TurnOnDishCategoryButtons();
                }
                break;
            case FoodTypes.STARCH:
                starchPanel.gameObject.SetActive(true);
                //play starch sound
                try {
                    AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();
                }
                catch{ }
                if (slot < 2)
                {
                    TurnOffDishCategoryButtons();
                }
                else
                {
                    TurnOnDishCategoryButtons();
                }
                break;
        }

        selectedSlot = slot;
    }

    /*public void MexicanButton() {
        // Play type of recipie sound
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

        MexicanScroll.gameObject.SetActive(true);
        AmericanScroll.gameObject.SetActive(false);
        ItalianScroll.gameObject.SetActive(false);
    }

    public void AmericanButton()
    {
        // Play type of recipe sound
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

        MexicanScroll.gameObject.SetActive(false);
        AmericanScroll.gameObject.SetActive(true);
        ItalianScroll.gameObject.SetActive(false);
    }

    public void ItalianButton()
    {
        // Play type of italian recipe sound
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

        MexicanScroll.gameObject.SetActive(false);
        AmericanScroll.gameObject.SetActive(false);
        ItalianScroll.gameObject.SetActive(true);
    }*/

    public void DishCreation(string dishTemplate) {
        Debug.Log("Create some " + dishTemplate);
        foreach (Image image in foodImages) {
            image.gameObject.SetActive(false);
        }
        LoadDish(dishTemplate);             // Once you click an option in the dropdown. It will take the exact name in the dropdown and load that json

        foreach (GameObject button in ingredientButtons) {
            Destroy(button);
        }
        ingredientButtons = new List<GameObject>();
        //delete images
        foreach (GameObject image in ingredientImages) {
            Destroy(image);
        }

        int slotNum = 0;
        foreach (FoodTypes foodReq in currentDish.requiredFoodSlots) {
            GameObject cur = Instantiate(buttonFab, ingredientButtonParent);
            Image curImage = cur.GetComponent<Image>();
            cur.transform.SetParent(ingredientButtonParent);
            RectTransform curTransform = cur.GetComponent<RectTransform>();
            curImage.color = Color.red;

            curTransform.anchorMin = buttonPositions[slotNum].anchorMin;
            curTransform.anchorMax = buttonPositions[slotNum].anchorMax;
            curTransform.anchoredPosition = buttonPositions[slotNum].anchoredPosition;
            curTransform.sizeDelta = buttonPositions[slotNum].sizeDelta;

            Text nameText = cur.GetComponentInChildren<Text>();
            switch (foodReq) {
                case FoodTypes.DAIRY:
                    nameText.text = "Dairy";
                    break;
                case FoodTypes.PROTEIN:
                    nameText.text = "Protein";
                    break;
                case FoodTypes.SAUCE:
                    nameText.text = "Sauce";
                    break;
                case FoodTypes.MISC:
                    nameText.text = "Misc";
                    break;
                case FoodTypes.STARCH:
                    nameText.text = "Starch";
                    break;

            }

            IngredientSlotButton slotScript = cur.GetComponent<IngredientSlotButton>();
            slotScript.type = foodReq;
            slotScript.position = slotNum;
            slotScript.manager = this;

            ingredientButtons.Add(cur);
            slotNum++;
        }


        foreach (FoodTypes foodOpt in currentDish.optionalFoodSlots)
        {
            if (slotNum < 3) { 
                GameObject cur = Instantiate(buttonFab, ingredientButtonParent);
                cur.transform.SetParent(ingredientButtonParent);
                RectTransform curTransform = cur.GetComponent<RectTransform>();

                curTransform.anchorMin = buttonPositions[slotNum].anchorMin;
                curTransform.anchorMax = buttonPositions[slotNum].anchorMax;
                curTransform.anchoredPosition = buttonPositions[slotNum].anchoredPosition;
                curTransform.sizeDelta = buttonPositions[slotNum].sizeDelta;

                Text nameText = cur.GetComponentInChildren<Text>();
                switch (foodOpt)
                {
                    //should probably also keep track of what image here?
                    case FoodTypes.DAIRY:
                        nameText.text = "?";
                        break;
                    case FoodTypes.PROTEIN:
                        nameText.text = "?";
                        break;
                    case FoodTypes.SAUCE:
                        nameText.text = "?";
                        break;
                    case FoodTypes.MISC:
                        nameText.text = "?";
                        break;
                    case FoodTypes.STARCH:
                        nameText.text = "?";
                        break;

                }

                IngredientSlotButton slotScript = cur.GetComponent<IngredientSlotButton>();
                slotScript.type = foodOpt;
                slotScript.position = slotNum;
                slotScript.manager = this;

                ingredientButtons.Add(cur);
                slotNum++;
            }
        }

        ingredientImages = new GameObject[ingredientButtons.Count];
        //later, perhaps fill this with an "empty image"

        switch (currentDish.category) {
            case DishCategory.AMERICAN:
                //Play american sound
                AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
                break;
            case DishCategory.ITALIAN:
                //Play Italian sound
                AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
                break;
            case DishCategory.MEXICAN:
                //Play Mexican sound
                AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
                break;
        }
        //AmericanScroll.gameObject.SetActive(false);
        //MexicanScroll.gameObject.SetActive(false);
        //ItalianScroll.gameObject.SetActive(false);

        //Debug.Log("Created some " + dishTemplate);

        //todo: Instantiate the buttons slots
    }


    public void SlotChoice(Button button)
    {
        IngredientTierButton buttonData = button.GetComponent<IngredientTierButton>();
        // The below 'if' is "this button tier <= the ingredient level of ingredientTier index of ingredient/5 (5 ingredients per type)"  for tier 0, 0 is the tier, but a negative value represents having it in the player's array
        if ((buttonData.tier>=1 && buttonData.tier <= Mathf.Abs(gameController.activePlayer.ingredientTiers[(int)buttonData.ingredient/5])) || (buttonData.tier<1 && gameController.activePlayer.ingredientTiers[(int)buttonData.ingredient / 5]<0))
        {
            //this next line is faulty and will not get anything but the first coomponent it finds
            
            TieredIngredient chosenIngredient = new TieredIngredient(buttonData.ingredient, buttonData.tier);

            currentRecipe.ingredients[selectedSlot] = chosenIngredient;

            /*dairyPanel.gameObject.SetActive(false);
            proteinPanel.gameObject.SetActive(false);
            saucePanel.gameObject.SetActive(false);
            starchPanel.gameObject.SetActive(false);
            miscPanel.gameObject.SetActive(false);*/
            //TurnOffDishCategoryButtons();

            //need to set the position of the display game object correctly.
            //also need to set it correctly when we change loaded recipes.
            //but upon further review, here is not a good spot.
            ingredientButtons[selectedSlot].GetComponentInChildren<Text>().text = Ingredient.IngredientToString(buttonData.ingredient);

            //should make the images appear as desired
            if (ingredientImages[selectedSlot] != null)
            {
                Destroy(ingredientImages[selectedSlot]);
            }
            //ingredientImages[selectedSlot] = Instantiate(buttonFab, ingredientButtons[selectedSlot]);

            //Set Image Correctly
            Debug.Log(buttonData.ingredient);
            switch (buttonData.ingredient)
            {
                case RecipeIngredient.CHICKEN:
                    selectedImage = chickenImage;
                    break;
                case RecipeIngredient.BEEF:
                    selectedImage = beefImage;
                    break;
                case RecipeIngredient.PORK:
                    selectedImage = porkImage;
                    break;
                case RecipeIngredient.WHEAT:
                    selectedImage = wheatImage;
                    break;
                case RecipeIngredient.RICE:
                    selectedImage = riceImage;
                    break;
                case RecipeIngredient.POTATOES:
                    selectedImage = potatoeImage;
                    break;
                case RecipeIngredient.MILK:
                    selectedImage = milkImage;
                    break;
                case RecipeIngredient.CHEESE:
                    selectedImage = cheeseImage;
                    break;
                case RecipeIngredient.BUTTER:
                    selectedImage = butterImage;
                    break;
                case RecipeIngredient.BECHAMEL:
                    selectedImage = bachamelImage;
                    break;
                case RecipeIngredient.REDSAUCE:
                    selectedImage = redSauceImage;
                    break;
                case RecipeIngredient.GRAVY:
                    selectedImage = gravyImage;
                    break;
                case RecipeIngredient.TOMATOES:
                    selectedImage = tomatoeImage;
                    break;
                case RecipeIngredient.GARLIC:
                    selectedImage = garlicImage;
                    break;
                case RecipeIngredient.LETTUCE:
                    selectedImage = lettuceImage;
                    break;
                default:
                    Debug.Log("No image was set");
                    break;
            }
            ingredientImages[selectedSlot] = Instantiate(selectedImage, ingredientButtons[selectedSlot].transform);
            //ingredientImages[selectedSlot].transform.SetParent(ingredientButtons[selectedSlot].transform);
            RectTransform curTransform = ingredientImages[selectedSlot].GetComponent<RectTransform>();
            curTransform.anchorMin = imagePositions[selectedSlot].anchorMin;
            curTransform.anchorMax = imagePositions[selectedSlot].anchorMax;
            curTransform.anchoredPosition = imagePositions[selectedSlot].anchoredPosition;
            curTransform.sizeDelta = imagePositions[selectedSlot].sizeDelta;
        }

    }


    public void ExitButton() {
        foreach(GameObject button in ingredientButtons) {
            Destroy(button);
        }
        ingredientButtons = new List<GameObject>();
        //delete images
        foreach (GameObject image in ingredientImages) {
            Destroy(image);
        }

        foreach (Image image in foodImages) {
            image.gameObject.SetActive(false);
        }
        ingredientImages = new GameObject[0];

        dishImage.gameObject.SetActive(false);
        textInput.gameObject.SetActive(false);
        TurnOffDishCategoryButtons();

        //newRecipieButton.gameObject.SetActive(true);

        dishCreationPanel.gameObject.SetActive(false);
        recipeManagerPanel.SetActive(false);

        //pictureFrames.SetActive(true);
        cameraScript.TurnCanMoveTrue();

        //play exit menu sound?
        AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            // Turn off a food slot panel sound
            dairyPanel.gameObject.SetActive(false);
            proteinPanel.gameObject.SetActive(false);
            starchPanel.gameObject.SetActive(false);
            miscPanel.gameObject.SetActive(false);
            saucePanel.gameObject.SetActive(false);
            TurnOnDishCategoryButtons();
        }
    }

    public Sprite ReturnImage(string dishName) {
        for (int i = 0; i < foodImages.Length; i++) {
            if (foodImages[i].name == dishName) {
                Debug.Log("We found the picture");
                foodImages[i].gameObject.SetActive(true);
                return foodImages[i].GetComponent<Image>().sprite;
                
            }
        }
        Debug.Log("We couldnt fidn the picture");
        return null;
    }

    public void LoadDish(string dishName) {
        dishImage.GetComponent<Image>().sprite = ReturnImage(dishName);
        currentDish = DishData.LoadJSON(dishName + ".json");
        Debug.Log("The name of the dish we are loading is " + currentDish.dishName);

        currentRecipe = new Recipe(currentDish.requiredFoodSlots.Count + currentDish.optionalFoodSlots.Count);
    }

    double CostMultiplier(int tier)
    {
        switch (tier)
        {
            case 0:
                return 0.75;
            case 1:
                return 1.0;
            case 2:
                return 2.0;
            case 3:
                return 4.0;
            case 4:
                return 8.0;
            default:
                return 1.0;
        }
    }

    // After you press "Enter" after typing into the input.
    public void LockInput(InputField input)
    {
        Debug.Log(input.text);
    }

    void TurnOnPanels()
    {
        recipeManagerPanel.SetActive(false);
        dishCreationPanel.SetActive(true);
        //dishTemplatePanel.SetActive(false);
        initialDishButtonPanel.SetActive(true);
        //Instantiate
        saveRecipieButton.gameObject.SetActive(false);
        //updateButton.gameObject.SetActive(true);

    }

    public void CreateSlots()
    {

    }

    public void RetriveDishInfo(string savedRecipieName)
    {
        Recipe recipeToEdit = null;
        for (int i = 0; i < gameController.activePlayer.savedRecipies.Count; i++)
        {
            if (gameController.activePlayer.savedRecipies[i].name == savedRecipieName)
            {
                recipeToEdit = gameController.activePlayer.savedRecipies[i];
            }
        }

        if(recipeToEdit != null)
        {
            currentDish = DishData.LoadJSON(recipeToEdit.dishTemplate);
            TurnOnPanels();
            CreateSlots();

            //TODO: Fill the slots with what the recipe already has
        }
    }

    public void SaveRecipeButton()
    {
        int ingredientImageCount = 0;
        for(int i = 0; i < ingredientImages.Length; i++)
        {
            if(ingredientImages[i] != null)
            {
                ingredientImageCount += 1;
            }
        }

        if (mainInputField.text != "" && ingredientImages.Length == ingredientImageCount)
        {
            currentRecipe.name = mainInputField.text;
            gameController.activePlayer.AddRecipe(currentRecipe);
            //createSavedButtonScript.CreateAButton(currentRecipe);

            //play save menu sound?
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectHigh();
            voiceScript.PlayAddRecipeVO((int)gameController.activePlayer.playerFaction.voice); // should play the right voice of the faction

            /////////////////////////// delete info and move back to Recipe Manager ///////
            foreach (GameObject button in ingredientButtons)
            {
                Destroy(button);
            }
            ingredientButtons = new List<GameObject>();
            //delete images
            foreach (GameObject image in ingredientImages)
            {
                Destroy(image);
            }

            foreach (Image image in foodImages)
            {
                image.gameObject.SetActive(false);
            }
            ingredientImages = new GameObject[0];

            //dishImage.gameObject.SetActive(false);
            //textInput.gameObject.SetActive(false);

            //newRecipieButton.gameObject.SetActive(true);

            dishCreationPanel.gameObject.SetActive(false);
            recipeManagerPanel.SetActive(true);
        }
    }

    public void UpdateRecipe()
    {
        gameController.activePlayer.UpdateRecipe(editing, currentRecipe);
    }

    public void TurnOnDishPanel(string dishCategory) {
        switch (dishCategory) {
            case "Dairy":
                TurnOffAllDishPanels();
                dairyPanel.SetActive(true);
                break;
            case "Protein":
                TurnOffAllDishPanels();
                proteinPanel.SetActive(true);
                break;
            case "Starch":
                TurnOffAllDishPanels();
                starchPanel.SetActive(true);
                break;
            case "Sauce":
                TurnOffAllDishPanels();
                saucePanel.SetActive(true);
                break;
            case "Misc":
                TurnOffAllDishPanels();
                miscPanel.SetActive(true);
                break;
        }
    }

    void TurnOffAllDishPanels() {
        dairyPanel.SetActive(false);
        proteinPanel.SetActive(false);
        starchPanel.SetActive(false);
        saucePanel.SetActive(false);
        miscPanel.SetActive(false);
    }

    void TurnOnDishCategoryButtons() {
        dairyButton.gameObject.SetActive(true);
        proteinButton.gameObject.SetActive(true);
        starchButton.gameObject.SetActive(true);
        sauceButton.gameObject.SetActive(true);
        miscButton.gameObject.SetActive(true);
    }

    void TurnOffDishCategoryButtons() {
        dairyButton.gameObject.SetActive(false);
        proteinButton.gameObject.SetActive(false);
        starchButton.gameObject.SetActive(false);
        sauceButton.gameObject.SetActive(false);
        miscButton.gameObject.SetActive(false);
    }

    public void ClosePanels()
    {
        //closes the ingredient panels
        dairyPanel.SetActive(false);
        proteinPanel.SetActive(false);
        starchPanel.SetActive(false);
        saucePanel.SetActive(false);
        miscPanel.SetActive(false);
        //closes the ingredients tabs
        dairyTab.SetActive(false);
        proteinTab.SetActive(false);
        starchTab.SetActive(false);
        sauceTab.SetActive(false);
        miscTab.SetActive(false);
    }

}
