using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForTech : MonoBehaviour {

    public GameObject mexican, italian, american;

    bool amer = false;
    bool ital = false;
    bool mex = false;

    public void Update()
    {
        mexican.SetActive(false);
        american.SetActive(false);
        italian.SetActive(false);

        if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.AMERICAN) {
            american.SetActive(true);
            amer = true;
        }

        if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.MEXICAN)
        {
            mexican.SetActive(true);
            mex = true;
        }

        if (GameController.Instance().activePlayer.playerFaction.style == FactionStyle.ITALIAN)
        {
            italian.SetActive(true);
            ital = true;
        }
    }
}
