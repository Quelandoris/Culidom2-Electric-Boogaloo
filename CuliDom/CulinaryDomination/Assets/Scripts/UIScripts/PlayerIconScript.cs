using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconScript : MonoBehaviour {

    public Sprite[] availablePortraits;
    public Texture[] availableIcons;

    Renderer rend;
    Color playerColor;
    

    private void OnEnable()
    {
        Sprite playerPortrait = GameController.Instance().mainUI.GetComponentInChildren<Bidding>().winnerPortrait.sprite;

        if (availablePortraits == null | availableIcons == null | playerPortrait == null)
        {
            return;
        }
        else
        {
            foreach (Sprite sprite in availablePortraits)
            {
                if(sprite == playerPortrait)
                {
                    rend = gameObject.GetComponent<Renderer>();
                    updateIcon(sprite);
                    return;
                }
            }
        }

    }

    public void updateColor(int playerID)
    {
        if (playerID == 0)
        {
            playerColor = new Color32(215, 0, 0, 255);
        } else if(playerID == 1)
        {
            playerColor = new Color32(0, 0, 215, 255);
        }
        else if (playerID == 2)
        {
            playerColor = new Color32(215, 215, 0, 255);
        }
        else if (playerID == 3)
        {
            playerColor = new Color32(215, 0, 215, 255);
        }
        rend.materials[1].SetColor("_Color", playerColor);
    }

    void updateIcon(Sprite sprite)
    {
        for (int i = 0; i < availablePortraits.Length; i++)
        {
            if (sprite == availablePortraits[i])
            {
                
                rend.materials[0].mainTexture = availableIcons[i];
            }
        }
    }
}
