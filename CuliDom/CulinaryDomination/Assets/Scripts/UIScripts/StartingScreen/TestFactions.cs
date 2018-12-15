using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class TestFactions : MonoBehaviour {

    public Transform presetFaction1, presetFaction2;
   

    // Use this for initialization
    void Start () {

        FactionData Jeffe = new FactionData();
        Jeffe.playerName = "Jeffe Silverbum";
        Jeffe.factionName = "Silverbum Kitchens";
        Jeffe.style = FactionStyle.MEXICAN; // Mexican
        Jeffe.voice = VoiceType.GUY; // Guy Ferriari
        Jeffe.playerPortrait = presetFaction1.Find("JeffePic").GetComponent<Image>().sprite;
        Jeffe.attribute = Attribute.MANAGERRIGHT;
        FactionData.ExportJSON(Jeffe, "Jeffe.json");

        FactionData Ramsey = new FactionData();
        Ramsey.playerName = "Gordon Ramsey";
        Ramsey.factionName = "Ramsey Enterprises";
        Ramsey.style = FactionStyle.AMERICAN; // American
        Ramsey.voice = VoiceType.GORDON; // Gordon Ramsay
        Ramsey.playerPortrait = presetFaction2.Find("GordonPic").GetComponent<Image>().sprite;
        Ramsey.attribute = Attribute.QUALITY;
        FactionData.ExportJSON(Ramsey, "Ramsey.json");


    }
	
}
