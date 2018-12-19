using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTreeUIUpdate : MonoBehaviour {

    public List<TechPurchase> techs = new List<TechPurchase>();

    

    public void OnEnable()
    {
        for (int i = 0; i < techs.Count; i++) {
            if (GameController.Instance().activePlayer.HaveTech(techs[i].thisTech)) { // will return true if player has it
                techs[i].techPicture.SetActive(true);
            }
        }
    }

    public void OnDisable()
    {
        for (int i = 0; i < techs.Count; i++)
        {
            techs[i].techPicture.SetActive(false);
        }
    }
}
