using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorController : MonoBehaviour {

    public Button endTurnButton;

    public Animator ramseyAnim, jeffyAnim;

    private float playerNumber = 0;


    public void SwitchPlayer()
    {
        if(playerNumber == 0)
        {
            playerNumber = 1;
        } else if (playerNumber == 2)
        {
            playerNumber = 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(playerNumber == 1)
        {
            ramseyAnim.Play("RamseyOut");
            jeffyAnim.Play("JeffyIn");
            playerNumber = 2;
        }
        if(playerNumber == 3)
        {
            ramseyAnim.Play("RamseyIn");
            jeffyAnim.Play("JeffyOut");
            playerNumber = 0;
        }
	}
}
