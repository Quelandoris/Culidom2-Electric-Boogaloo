using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TechPurchase : MonoBehaviour {

    /// <summary>
    /// They're not disabling correctly
    /// The opponent appears to get the tech (in UI at least)
    /// Is updating slider visuals only when not in menu
    /// </summary>

    [SerializeField]
    public UIController mainUI;

    public Tech thisTech;
    public int techCost;
    private int techProgressIndex = -1;

    public Text costText;
    public Text queueNumber;

    public GameObject queuedBanner;

    public List<Tech> requirements;
    public List<Tech> previousLevel;

    //public Slider thisSlider;

    private void Start() {
        costText.text = techCost.ToString();
    }

    void OnEnable() {
        CheckRequirements();
    }


    //Below is a bit of a 'do-all' function that desperately needs to be broken up.

    //sets the button as click-able or not based on requirements and purchased or not
    //sets the queuedBanner state appropriately and display number of queued banner
    //sets slider display on/off and updates slider values
    //should manage colour of purchased or not as well
    public void CheckRequirements() {
        //checks if you've already bought the tech
        gameObject.GetComponent<Button>().interactable = !GameController.Instance().activePlayer.HaveTech(thisTech);
        //UpdateSlider();
        //checks if requirements for enqueing the tech are met
        if (!GameController.Instance().activePlayer.HaveTech(thisTech)) {
            bool hasPreviousLevel = (previousLevel.Count == 0); //sets to true if no previous level, and false if there is a previous level
            bool meetsAll = true;
            foreach (Tech req in requirements) {
                if (!GameController.Instance().activePlayer.HaveTech(req) && !GameController.Instance().activePlayer.IsQueued(req)) {
                    meetsAll = false;
                }
            }
            //must rephrase this so that having any of these passes you, if you don't have any, then it is failed
            foreach (Tech pLvl in previousLevel) {
                //if I queue a previous level, then this tech, then a new previous level, then unqueue the first, there's a problem. (Should be fixed now)
                if (GameController.Instance().activePlayer.HaveTech(pLvl) || (GameController.Instance().activePlayer.IsQueued(pLvl) && GameController.Instance().activePlayer.techQueue.IndexOf(this)>GameController.Instance().activePlayer.IndexOfTech(pLvl)) || (GameController.Instance().activePlayer.IsQueued(pLvl) && !GameController.Instance().activePlayer.techQueue.Contains(this))) {
                    hasPreviousLevel = true;
                }
            }
            if (!meetsAll || !hasPreviousLevel) {
                //This ends up calling this function again
                Dequeue();
            }
            gameObject.GetComponent<Button>().interactable = (meetsAll && hasPreviousLevel);
        }
        //set queuedBanner state appropriately
        queuedBanner.SetActive(GameController.Instance().activePlayer.IsQueued(thisTech));
        //sets queueNumber appropriately & updates slider values
        if (GameController.Instance().activePlayer.techQueue.Contains(this)) {
            queueNumber.text = (GameController.Instance().activePlayer.techQueue.IndexOf(this) + 1).ToString();
        }
    }

    public void Unlock() {
        GameController.Instance().activePlayer.LearnTech(thisTech);
        Dequeue();
    }

    public void ButtonPress() {
        if (GameController.Instance().activePlayer.IsQueued(thisTech)) {
            Dequeue();
        } else {
            Enqueue();
        }
    }

    public void Dequeue() {
        queuedBanner.SetActive(false);
        mainUI.DequeueTech(this);
    }

    public void Enqueue() {
        queuedBanner.SetActive(true);
        mainUI.EnqueueTech(this);
    }

    public void SetQueueNumber(int qNum) {
        queueNumber.text = qNum.ToString();
    }

    public void UpdateSlider() {
        //thisSlider.value = ((float)GetTechProgress() / techCost);
    }

    public int GetTechProgress() {
        if (techProgressIndex == -1) {
            techProgressIndex = mainUI.GetIndexOfTechPurchases(this);
        }
        return GameController.Instance().activePlayer.techProgress[techProgressIndex];
    }

    public void AddTechProgress(int added) {
        if (techProgressIndex == -1) {
            techProgressIndex = mainUI.GetIndexOfTechPurchases(this);
        }
        GameController.Instance().activePlayer.techProgress[techProgressIndex] += added;
    }

    public void SetTechProgress(int techProgress) {
        if (techProgressIndex == -1) {
            techProgressIndex = mainUI.GetIndexOfTechPurchases(this);
        }
        GameController.Instance().activePlayer.techProgress[techProgressIndex] = techProgress;
    }
}
