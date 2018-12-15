using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImage : MonoBehaviour {




    private void OnEnable()
    {
        gameObject.GetComponent<Image>().sprite = GameController.Instance().activePlayer.playerFaction.playerPortrait;
    }

}
