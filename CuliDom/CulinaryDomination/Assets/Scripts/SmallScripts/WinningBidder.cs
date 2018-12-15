using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningBidder : MonoBehaviour {
    public Image sprite;
    public Text text;

   /* Bidding bidScript;

    public void Awake()
    {
        bidScript = FindObjectOfType<Bidding>();
        text.text = "";
    }

    public void OnEnable()
    {
        if (bidScript.GetWinnerPic() != null)
        {
            Debug.Log("Lets egt the winner pic");
            sprite.sprite = bidScript.GetWinnerPic();
        }
        else {
            Debug.Log("We dont have the winner pic");
        }

        if (bidScript.GetWinnerName() != null) {
            text.text = bidScript.GetWinnerName();
        }
    }

    public void OnDisable()
    {
        sprite.sprite = null;
        text.text = "";
    }*/
}
