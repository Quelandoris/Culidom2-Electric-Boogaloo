using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoicePackTest : MonoBehaviour {

    int currentPack = 0;

    public Text currentPack_Text;

    public GameObject VoicePack;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void voPackGordon()
    {
        currentPack = 0;
        currentPack_Text.text = "Current VoicePack: Gordon";
    }

    public void voPackDonald()
    {
        currentPack = 1;
        currentPack_Text.text = "Current VoicePack: Donald";
    }

    public void voPackGuy()
    {
        currentPack = 2;
        currentPack_Text.text = "Current VoicePack: Guy";
    }

    public void voPackShy()
    {
        currentPack = 3;
        currentPack_Text.text = "Current VoicePack: Shy";
    }

    public void voPackPaula()
    {
        currentPack = 4;
        currentPack_Text.text = "Current VoicePack: Paula";
    }

    public void voPackAntonio()
    {
        currentPack = 5;
        currentPack_Text.text = "Current VoicePack: Antonio";
    }

    public void BuildQueButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayBuildQueOpenVO(currentPack);
    }

    public void HireChefButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayHireChefVO(currentPack);
    }

    public void FireChefButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayFireChefVO(currentPack);
    }

    public void SelectRestaurantButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlaySelectRestaurantVO(currentPack);
    }

    public void CreateRecipeButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayAddRecipeVO(currentPack);
    }

    public void GoodTurnButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayGoodTurnVO(currentPack);
    }

    public void BadTurnButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayBadTurnVO(currentPack);
    }

    public void NeutralTurnButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayNeutralTurnVO(currentPack);
    }

    public void TurnRecapButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayTurnRecapVO(currentPack);
    }

    public void WinButton()
    {
        VoicePack.GetComponent<VoicePacks>().PlayWinVO(currentPack);
    }
}
