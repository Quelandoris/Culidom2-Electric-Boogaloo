using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainNavigation : MonoBehaviour {

    public static MainNavigation instance { get { return _instance; } }
    private static MainNavigation _instance;
    public List<GameObject> _mainScreens = new List<GameObject>(); //everything that pulls up from the main map screen that hides the portrait, turn number, and player number
    //public List<GameObject> _subScreens = new List<GameObject>();  //everything that stems off of a main screen
    public List<GameObject> _popupMenus = new List<GameObject>();  //everything that is a popup menu

    public List<GameObject> _ingredientPanels = new List<GameObject>();
    public List<GameObject> _empirePanels = new List<GameObject>();
    public List<GameObject> _recipeCreatePanels = new List<GameObject>();
    public List<GameObject> _restaurantStaticUpgrades = new List<GameObject>();
    public List<GameObject> _restaurantInProgressUpgrades = new List<GameObject>();

    public GameObject homeElements;
    CameraMovement cameraScript;

    bool popupMenuOn, subMenuOn, mainScreenOn;
    int popupMenusIndex, subMenuIndex, mainScreenIndex;

    private void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
        _instance = this;
    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            popupMenuOn = false; subMenuOn = false; mainScreenOn = false;
            popupMenusIndex = -1; subMenuIndex = -1; mainScreenIndex = -1;

            for (int i = 0; i < _popupMenus.Count; i++)
            {
                if(_popupMenus[i].activeSelf == true)
                {
                    popupMenuOn = true;
                    popupMenusIndex = i;
                    break;
                }
            }

            for(int i = 0; i < _mainScreens.Count; i++)
            {
                if(_mainScreens[i].activeSelf == true)
                {
                    mainScreenOn = true;
                    mainScreenIndex = i;
                    break;
                }
            }

            if (popupMenuOn)
            {
                _popupMenus[popupMenusIndex].SetActive(false);
                CheckHomeElements();
            }
           /* else if (subMenuOn)
            {
                _subScreens[subMenuIndex].SetActive(false);
            }*/
            else if (mainScreenOn)
            {
                _mainScreens[mainScreenIndex].SetActive(false);
                CheckHomeElements();
            }
            else
            {
                _popupMenus[6].SetActive(true);
                CheckHomeElements();
            }

        }
    }

    public void CheckHomeElements ()
    {
        for (int i = 0; i < _mainScreens.Count; i++)
        {
            if (_mainScreens[i].activeSelf == true)
            {
                homeElements.SetActive(false);
                cameraScript.TurnCanMoveFalse();

                break;
            }
            else
            {
                homeElements.SetActive(true);
                cameraScript.TurnCanMoveTrue();
            }
        }
    }

    public void ToggleMainScreens(GameObject _desiredScreen)
    {
        _mainScreens.ForEach(s => { if (s != _desiredScreen) { s.SetActive(false); } });
        _desiredScreen.SetActive(!_desiredScreen.activeSelf);
        CheckHomeElements();
    }

    /*public void ToggleSubScreens(GameObject _desiredScreen)
    {
        _subScreens.ForEach(s => { if (s != _desiredScreen) { s.SetActive(false); } });
        _desiredScreen.SetActive(!_desiredScreen.activeSelf);
    }*/

    public void TogglePopupWindows(GameObject _desiredWindow)
    {
        _popupMenus.ForEach(s => { if (s != _desiredWindow) { s.SetActive(false); } });
        _desiredWindow.SetActive(!_desiredWindow.activeSelf);
        CheckHomeElements();
    }

    public void ClosePopupMenus()
    {
        _popupMenus.ForEach(s => s.SetActive(false));
    }

    public void ChangeEmpirePanels(GameObject _desiredPanel)
    {
        _empirePanels.ForEach(s => s.SetActive(false));
        _desiredPanel.SetActive(true);
    }

    public void ChangeRecipeCreationPanels(GameObject _desiredPanel)
    {
        _recipeCreatePanels.ForEach(s => s.SetActive(false));
        _desiredPanel.SetActive(true);
    }

    public void ChangeIngredientPanels(GameObject _desiredPanel)
    {
        _ingredientPanels.ForEach(s => s.SetActive(false));
        _desiredPanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
