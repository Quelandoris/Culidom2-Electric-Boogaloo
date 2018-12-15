using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MikeysUI : MonoBehaviour {


    //public GameObject RestaurantManager, ChefManager, empireManagmentUI, recipeManagmentUI, techTreeUI,
         //assignChefPanelEmpire;

    //public GameObject staffPanel, chefPanel, chefMarketPlacePopUp;

    //public GameObject savedRecipesScreen,createRecipeScreen;

    public RestaurantLocalScrollView restaurantScrollView;


    //CameraMovement cameraScript;

    //sound
    //GameObject AudioManager;

    /*public void Start()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
    }

    /*private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    /*public void BuildButton()
    {
        if (upgradesLayout.activeSelf == false)
        {
            upgradesLayout.SetActive(true);
        } else
        {
            upgradesLayout.SetActive(false);
        }
    }*/

    /*public void CloseMarketingManagerButton()
    {
        cameraScript.TurnCanMoveTrue();
    }

    /*public void CloseRecipeManagerButton()
    {
        recipeManagmentUI.gameObject.SetActive(false);
        cameraScript.TurnCanMoveTrue();
    }

    /*public void CloseTechTreeButton()
    {
        techTreeUI.gameObject.SetActive(false);
        cameraScript.TurnCanMoveTrue();
    }


    /*public void AssignChefLocationEmpire()
    {
        assignChefPanelEmpire.SetActive(true);
    }

    /*public void AssignChefLocationPopUp()
    {
        assignChefPanelPopUp.SetActive(true);
    }*/

   /* public void AssignChefButton()
    {
        if (assignChefPanelEmpire.gameObject.activeSelf == false)
        {
            // Play turn on assign chef sound
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

            assignChefPanelEmpire.gameObject.SetActive(true);
            //chefInfoPanel.gameObject.SetActive(false);
        }
        else if (assignChefPanelEmpire.gameObject.activeSelf == true)
        {
            // Play turn off assign chef sound
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();

            assignChefPanelEmpire.gameObject.SetActive(false);
        }
    }

    /*public void ChefInfoPanel()
    {
        if (chefInfoPanel.gameObject.activeSelf == false)
        {
            // Play turn on chef info panel sound
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

            assignChefPanelEmpire.gameObject.SetActive(false);
            chefInfoPanel.gameObject.SetActive(true);
        }
        else if (chefInfoPanel.gameObject.activeSelf == true)
        {
            // Play turn off chef info panel
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectLow();

            chefInfoPanel.gameObject.SetActive(false);
        }
    }*/

    /*public void closeEmpireManagementUI()
    {
        // delete the restaurant content
        restaurantScrollView.DeleteContent();
        //empireManagmentUI.gameObject.SetActive(false);
        //cameraScript.TurnCanMoveTrue();
        
    }

    /*public void RestaurantManagementButton()
    {
        if (RestaurantManager.gameObject.activeSelf == false)
        {
            // Play turn on Resturant screen sound
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

            RestaurantManager.gameObject.SetActive(true);
            ChefManager.gameObject.SetActive(false);
        }
    }

    //turning on the chef marketplace
    /*public void ChefMarketPlaceButtonEmpireScreen()
    {
        chefMarketPlaceEmpireScreen.SetActive(true);
    }*/

    /*public void ChefMarketPlaceButtonPopUp()
    {
        chefMarketPlacePopUp.SetActive(true);
    }

    public void ChefManagementButton()
    {
        if (ChefManager.gameObject.activeSelf == false)
        {
            // Play turn on Chef Manger panel sound
            AudioManager.GetComponent<AudioManager>().PlayMenuSelectMid();

            RestaurantManager.gameObject.SetActive(false);
            ChefManager.gameObject.SetActive(true);
        }
    }

    //Using the tabs in the recipes screen
    /*public void IngredientTab()
    {
        ingredientScreen.SetActive(true);
        savedRecipesScreen.SetActive(false);
        createRecipeScreen.SetActive(false);
    }

    public void SavedRecipesTab()
    {
        ingredientScreen.SetActive(false);
        savedRecipesScreen.SetActive(true);
        createRecipeScreen.SetActive(false);
    }*/

}
