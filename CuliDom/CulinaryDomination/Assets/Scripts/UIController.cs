using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    /*
        No esc or tab key functionality
        General Problems switching players:
            Player's tech UI is spilling over into other players
    */
    GameController gameController;
    public Text playerMoneyValue;
    public Text playerTechPointRateMenuValue;
    public Text roundNumber;
    //public GameObject unspentTech;
    //public GameObject techTreeMenu;
    public TechPurchase[] techPurchases;
    //was an object array
    public Text playerNumber;
    public CreateSavedRecipeButtons recipeButton;
    public ChefScrollView chefEmpireContent;
    //public LittleChefScrollView chefRestaurantContent;

    void Start() {
        gameController = GameController.Instance();
        //This in the end makes techPurchases be only filled by instances of techPurchase, and excludes prefabs
        TechPurchase[] array = Resources.FindObjectsOfTypeAll(typeof(TechPurchase)) as TechPurchase[];
        List<TechPurchase> list = new List<TechPurchase>(array);
        for (int i = 0; i<list.Count; i++) {
            if(list[i].gameObject.scene.name == null || list[i].gameObject.scene.rootCount == 0) {
                list.Remove(list[i]);
                i--;
            }
        }
        //techPurchases = list.ToArray();
        Debug.Log("Initialized UI");
        gameController.UIConstructedAll(techPurchases.Length);
    }

    private void OnGUI() {
        UpdateUI();
    }

    private void OnEnable()
    {
        GameController.Instance().mainUI = this;
    }

    //Updates player-number, money, tech-queue-empty, and tech-point-rate 
    public void UpdateUI() {
        playerNumber.text = gameController.GetPlayerNumber().ToString();
        playerMoneyValue.text = Mathf.Floor((float)gameController.activePlayer.GetMoney()).ToString();
        roundNumber.text = GameController.Instance().GetRoundNumber().ToString();
        if (gameController.activePlayer.techQueue.Count == 0) {
            //unspentTech.SetActive(true);
        } else {
            //unspentTech.SetActive(false);
        }
        playerTechPointRateMenuValue.text = gameController.activePlayer.GetTechPointRate().ToString();
    }

    //Rechecks all tech-purchase availibility statuses & queued statuses
    public void CheckTechRequirements() {
        foreach (TechPurchase techpurchase in techPurchases) {
            techpurchase.CheckRequirements();
        }
    }

    public void EnqueueTech(TechPurchase techToEnqueue) {
        gameController.activePlayer.techQueue.Add(techToEnqueue);
        techToEnqueue.SetQueueNumber(gameController.activePlayer.techQueue.Count);
        CheckTechRequirements();
    }

    public void ClearTechQueue() {
        gameController.activePlayer.techQueue.Clear();
    }

    public void DequeueTech(TechPurchase techToRemove) {
        if (gameController.activePlayer.techQueue.Contains(techToRemove)) {
            //section decrements visible queue number
            int removed = int.Parse(techToRemove.queueNumber.text);
            foreach (TechPurchase tech in gameController.activePlayer.techQueue) {
                int q = int.Parse(tech.queueNumber.text);
                if (q > removed) {
                    tech.queueNumber.text = (q - 1).ToString();
                }
            }
            gameController.activePlayer.techQueue.Remove(techToRemove);
            CheckTechRequirements();
        }
    }

    //curently called at the start of a turn
    public void AddTechPoints(int techPoints) {
        if (gameController.activePlayer.techQueue.Count > 0) {
            TechPurchase inProgress = gameController.activePlayer.techQueue[0];
            inProgress.AddTechProgress(techPoints);
            if (inProgress.GetTechProgress() >= inProgress.techCost) {
                if (inProgress.GetTechProgress() > inProgress.techCost && gameController.activePlayer.techQueue.Count > 1) {
                    gameController.activePlayer.techQueue[1].AddTechProgress(inProgress.GetTechProgress() - inProgress.techCost);
                    gameController.activePlayer.techQueue[1].UpdateSlider();
                }
                inProgress.SetTechProgress(inProgress.techCost);
                inProgress.Unlock();
            }
        }
    }

    public void EndTurn() {
        gameController.EndTurn();
    }

    /*
    public void CloseUI() {
        techTreeMenu.SetActive(false);
        mexicanPanel.SetActive(false);
        italianPanel.SetActive(false);
        americanPanel.SetActive(false);
    }
    */

    public int GetIndexOfTechPurchases(TechPurchase techQuery) {
        return System.Array.IndexOf(techPurchases, techQuery);
    }
}
