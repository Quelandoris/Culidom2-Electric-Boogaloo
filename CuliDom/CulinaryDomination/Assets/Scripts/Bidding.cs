using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bidding : MonoBehaviour {

    GameController gameController;
    VacantUI vacantui;
    [Tooltip("Restaurant prefab to be spawned")]
    public GameObject mexRestaurantFab, italianRestaurantFab, americanRestaurantFab;
    public GameObject biddingPanel, winnerPanel, tiedPanel;
    double[] bids = new double[4];
    [Tooltip("Starting cost text display")]
    public Text startingCostText = null;
    int startingCost;
    [Tooltip("Player bids text display (should be 4)")]
    //public Text[] playerBidDisplays;
    //[Tooltip("Winner text in winner panel")]
    public Text winnerText;
    [Tooltip("Duration of bidding")]
    float bidTimer = 3f;
    public float startCountdown = 3f;
    private float biddingTimer;
    BuildingVacant vacantTile;
    public GameObject[] playerPanels;

    public string firstPlayer;

    public GameObject player1BidImage, player2BidImage, player3BidImage, player4BidImage;

    bool player1bid, player2bid, player3bid, player4bid;
    bool first = false;
    bool roundOver = false, countingDown = false;
    bool doneBidding = true;
    CameraMovement camera;
    public Image winnerPortrait;
    string winnerName;

    bool player1first, player2first, player3first, player4first;


    string readyUpText = "Press your key to ready up";
    string startBidding = "Start bidding";

    Color startingColor;
    GameObject playerFirst;
    public Text uiText;
    int playerInCount = 4;
    bool player1ready, player2ready, player3ready, player4ready;
    bool readyUp = false;
    int playerCount = 0;

    GameObject AudioManager;

    public void Awake()
    {
        gameController = GameController.Instance();
        camera = FindObjectOfType<CameraMovement>();
    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager_Menu>().gameObject;
        startingColor = player1BidImage.GetComponent<Image>().color;
    }

    public void Update()
    {
        if (countingDown)
        {
            startCountdown -= Time.deltaTime;
            if(startCountdown > 2)
            {
                uiText.text = 3.ToString();
            }
            else if(startCountdown > 1)
            {
                uiText.text = 2.ToString();
            }
            else if(startCountdown > 0)
            {
                uiText.text = 1.ToString();
            }else
            {
                Debug.Log("start round?");
                player1BidImage.GetComponent<Image>().color = startingColor;
                player2BidImage.GetComponent<Image>().color = startingColor;
                player3BidImage.GetComponent<Image>().color = startingColor;
                player4BidImage.GetComponent<Image>().color = startingColor;
                StartRound();
            }
        }

        if (readyUp)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player1BidImage.GetComponent<Image>().color = Color.red;
                player1ready = true;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (playerPanels[1].activeSelf == true)
                {
                    player2BidImage.GetComponent<Image>().color = Color.red;
                    player2ready = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (playerPanels[2].activeSelf == true)
                {
                    player3BidImage.GetComponent<Image>().color = Color.red;
                    player3ready = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (playerPanels[3].activeSelf == true)
                {
                    player4BidImage.GetComponent<Image>().color = Color.red;
                    player4ready = true;
                }
            }

            if (playerCount == 2)
            {
                if (player1ready && player2ready)
                {
                    Debug.Log("players are ready");
                    StartCountdown();
                }
            }
            else if (playerCount == 3)
            {
                if (player1ready && player2ready && player3ready)
                {
                    StartCountdown();
                }
            }
            else if (playerCount == 4)
            {
                if (player1ready && player2ready && player3ready && player4ready)
                {
                    StartCountdown();
                }
            }
        }

        if (!doneBidding)
        {
            if (!roundOver)
            {
                {
                    biddingTimer -= Time.deltaTime;

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        uiText.text = "";
                        if (gameController.player[0].GetMoney() > startingCost)
                        {
                            if (playerPanels[0].activeSelf == true)
                            {
                                if (!first)
                                {
                                    player1first = true;
                                    first = true;
                                    playerFirst = playerPanels[0];
                                    player1BidImage.GetComponent<Image>().color = Color.green;
                                }
                                else if(!player1first)
                                {
                                    player1BidImage.GetComponent<Image>().color = Color.yellow;
                                }

                                player1bid = true;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        uiText.text = "";
                        if (gameController.player[1].GetMoney() > startingCost)
                        {
                            if (playerPanels[1].activeSelf == true)
                            {
                                if (!first)
                                {
                                    player2first = true;
                                    first = true;
                                    playerFirst = playerPanels[1];
                                    player2BidImage.GetComponent<Image>().color = Color.green;
                                }
                                else if(!player2first)
                                {
                                    player2BidImage.GetComponent<Image>().color = Color.yellow;
                                }

                                player2bid = true;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        uiText.text = "";
                        if (gameController.player[2].GetMoney() > startingCost)
                        {
                            if (playerPanels[2].activeSelf == true)
                            {
                                if (!first)
                                {
                                    player3first = true;
                                    first = true;
                                    playerFirst = playerPanels[2];
                                    player3BidImage.GetComponent<Image>().color = Color.green;
                                }
                                else if (!player3first)
                                {
                                    player3BidImage.GetComponent<Image>().color = Color.yellow;
                                }

                                player3bid = true;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.N))
                    {
                        uiText.text = "";
                        if (gameController.player[3].GetMoney() > startingCost)
                        {
                            if (playerPanels[3].activeSelf == true)
                            {
                                if (!first)
                                {
                                    player4first = true;
                                    first = true;
                                    playerFirst = playerPanels[3];
                                    player4BidImage.GetComponent<Image>().color = Color.green;
                                }
                                else if (!player4first)
                                {
                                    player4BidImage.GetComponent<Image>().color = Color.yellow;
                                }

                                player4bid = true;
                            }
                        }
                    }

                    if (biddingTimer <= 0f)
                    {
                        roundOver = true;
                        FinishRound();
                    }
                }
            }
        }
    }

    public void StartBidding(VacantUI vacant)
    {

        startingCostText.text = "";
        playerCount = 0;
        playerInCount = 4;
        startingCost = 0;
        biddingTimer = bidTimer;

        uiText.text = "";
        doneBidding = true;
        player1bid = false; player2bid = false; player3bid = false; player4bid = false;

        first = false;
        roundOver = false; countingDown = false;

        player1first = false; player2first = false; player3first = false; player4first = false;

        player1ready = false; player2ready = false; player3ready = false; player4ready = false;
        readyUp = false;
        Debug.Log("i count that there are " + playerCount.ToString() + "players");

        readyUp = true;
        vacantui = vacant;
        camera.TurnCanMoveFalse();

        Debug.Log("Gamecontroller says there are " + gameController.playerCount.ToString() + "players");
        for (int i = 0; i < playerPanels.Length; i++)
        {
            playerPanels[i].SetActive(i < gameController.playerCount);
        }
        /*
        for (int i = gameController.playerCount; i < playerPanels.Length; i++) {
            playerPanels[i].SetActive(false);
        }
        */
        /*for (int i = 0; i < playerBidDisplays.Length; i++) {
            playerBidDisplays[i].text = "";
        }*/
        vacantTile = vacant.building;
        bids = new double[] {vacantTile.price, vacantTile.price, vacantTile.price, vacantTile.price};
        startingCost = vacantTile.price;
        startingCostText.text = "Starting Cost: $"+startingCost.ToString();
        //biddingPanel.SetActive(true);
        //winnerPanel.SetActive(false);
        //tiedPanel.SetActive(false);
        //doneBidding = false;
        biddingTimer = bidTimer;
        uiText.text = readyUpText;
        for (int i = 0; i < playerPanels.Length; i++)
        {
            if(playerPanels[i].activeSelf == true)
            {
                playerCount += 1;
                Debug.Log("i count that there are " + playerCount.ToString() + "players");

            }
        }
    }

    public void StartCountdown()
    {
        readyUp = false;
        startCountdown = 3f;
        countingDown = true;
    }

    public void StartRound()
    {
        countingDown = false;
        roundOver = false;
        doneBidding = false;
        biddingTimer = bidTimer;
        uiText.text = startBidding;
    }

    public void FinishRound ()
    {
        roundOver = true;
        if (player1first)
        {
            firstPlayer = "player1";
        }else if (player2first)
        {
            firstPlayer = "player2";
        }
        else if (player3first)
        {
            firstPlayer = "player3";
        }
        else if (player4first)
        {
            firstPlayer = "player4";
        }

        if (!player1bid)
        {
            playerPanels[0].SetActive(false);
        }

        if (!player2bid)
        {
            playerPanels[1].SetActive(false);
        }

        if (!player3bid)
        {
            playerPanels[2].SetActive(false);
        }

        if (!player4bid)
        {
            playerPanels[3].SetActive(false);
        }

        for(int i = 0; i < playerPanels.Length; ++i)
        {
            if(playerPanels[i].activeSelf == false)
            {
                playerInCount -= 1;
            }
        }

        if(playerInCount < 2)
        {
            FinishBidding();
        }
        else
        {
            player1first = false;
            player2first = false;
            player3first = false;
            player4first = false;
            player1bid = false;
            player2bid = false;
            player3bid = false;
            player4bid = false;
            startingCost += 50;
            startingCostText.text = "New Price: $ " + startingCost.ToString();
            first = false;
            biddingTimer = bidTimer;
            StartCountdown();
            playerInCount = 4;
        }
    }

    public void FinishBidding() {

        doneBidding = true;

        player1BidImage.GetComponent<Image>().color = startingColor;
        player2BidImage.GetComponent<Image>().color = startingColor;
        player3BidImage.GetComponent<Image>().color = startingColor;
        player4BidImage.GetComponent<Image>().color = startingColor;



        int highBid = startingCost;

        if(playerInCount == 1)
        {
            for (int i = 0; i < playerPanels.Length; i++)
            {
                if (playerPanels[i].activeSelf == true)
                {
                    winnerPortrait.sprite = gameController.player[i].playerFaction.playerPortrait;
                    winnerName = gameController.player[i].playerFaction.playerName;
                    DisplayResults(i, highBid);
                    BuyRestaurant(i, highBid);
                }
            }
        }
        else
        {
            switch (firstPlayer)
            {
                case "player1":
                    winnerPortrait.sprite = gameController.player[0].playerFaction.playerPortrait;
                    winnerName = gameController.player[0].playerFaction.playerName;
                    DisplayResults(0, highBid);
                    BuyRestaurant(0, highBid);
                    break;
                case "player2":
                    winnerPortrait.sprite = gameController.player[1].playerFaction.playerPortrait;
                    winnerName = gameController.player[1].playerFaction.playerName;
                    DisplayResults(1, highBid);
                    BuyRestaurant(1, highBid);
                    break;
                case "player3":
                    winnerPortrait.sprite = gameController.player[2].playerFaction.playerPortrait;
                    winnerName = gameController.player[2].playerFaction.playerName;
                    DisplayResults(2, highBid);
                    BuyRestaurant(2, highBid);
                    break;
                case "player4":
                    winnerPortrait.sprite = gameController.player[3].playerFaction.playerPortrait;
                    winnerName = gameController.player[3].playerFaction.playerName;
                    DisplayResults(3, highBid);
                    BuyRestaurant(3, highBid);
                    break;
            }
        }

        //double highBid = vacantTile.price;
        /*int highBidder = gameController.GetPlayerNumber() - 1;
        for(int i  = 0; i<gameController.playerCount; i++)
        {
            if(bids[i]==vacantTile.price && i!=(gameController.GetPlayerNumber()-1) ) {
                bids[i] = 0;
            }

            if(bids[i] == highBid && highBid!=vacantTile.price)  {
                tied = true;
            }
            else if (bids[i] > highBid) {
                highBidder = i;
                highBid = bids[i];
                tied = false;
            }
        }
        if (tied)
        {
            tiedPanel.SetActive(true);
        }
        else
        {
            winnerPortrait = gameController.player[highBidder].playerFaction.playerPortrait;
            winnerName = gameController.player[highBidder].playerFaction.playerName;
            DisplayResults(highBidder, highBid);
            BuyRestaurant(highBidder, highBid);
        }*/
        camera.TurnCanMoveTrue();
    }

    public void DisplayResults(int winner, int payment) {
        /*for(int i = 0; i<gameController.playerCount; i++) {
            if (bids[i] == 0)
            {
                // show original cost of the lot
                playerBidDisplays[i].text = "$" + vacantui.GetCost().ToString();
            }
            else
            {
                playerBidDisplays[i].text = "$" + bids[i].ToString();
            }
        }*/

        winnerPanel.SetActive(true);
        winnerText.text = "Player " + (winner + 1).ToString() + " won, paying a total of $" + payment.ToString();
        AudioManager.GetComponent<AudioManager_Menu>().PlayBiddingEnd();
    }

    private void BuyRestaurant(int purchaser, double payment) {
        gameController.player[purchaser].AddMoney(-payment);
        // get reference to the tile we are bidding on so that i can reference the restaurant we created
        //WorldTile newRest = vacantTile.tile;
        if (gameController.player[purchaser].playerFaction.style == FactionStyle.MEXICAN)
        {
            WorldTile newRest = vacantTile.Buy(mexRestaurantFab, purchaser);
            //change the color of the playericon to reflect the purchaser's color
            newRest.gameObject.GetComponentInChildren<PlayerIconScript>().updateColor(purchaser);
        }
        else if (gameController.player[purchaser].playerFaction.style == FactionStyle.ITALIAN)
        {
            WorldTile newRest = vacantTile.Buy(italianRestaurantFab, purchaser);
            newRest.gameObject.GetComponentInChildren<PlayerIconScript>().updateColor(purchaser);
        }
        else if (gameController.player[purchaser].playerFaction.style == FactionStyle.AMERICAN) {

            WorldTile newRest = vacantTile.Buy(americanRestaurantFab, purchaser);
            newRest.gameObject.GetComponentInChildren<PlayerIconScript>().updateColor(purchaser);
        }

        Debug.Log("Payed: $"+payment.ToString());
    }

    public void CloseUI() {
        winnerPanel.SetActive(false);

        camera.TurnCanMoveTrue();

        AudioManager.GetComponent<AudioManager_Menu>().PlayPayment();
    }

    //same as start, but doesn't take an argument
    /*public void Redo() {
        for (int i = 0; i < playerBidDisplays.Length; i++) {
            playerBidDisplays[i].text = "";
        }
        bids = new double[] { vacantTile.price, vacantTile.price, vacantTile.price, vacantTile.price };
        startingCostText.text = "Base Price: $" + vacantTile.price.ToString();
        biddingPanel.SetActive(true);
        winnerPanel.SetActive(false);
        tiedPanel.SetActive(false);
        doneBidding = false;
        biddingTimer = bidTimer;
    }

    /*public Sprite GetWinnerPic() {
        return winnerPortrait;
    }

    public string GetWinnerName() {
        return winnerName;
    }*/
}
