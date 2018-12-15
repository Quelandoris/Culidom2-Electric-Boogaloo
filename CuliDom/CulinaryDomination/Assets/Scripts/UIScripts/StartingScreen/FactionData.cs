using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum VoiceType { GORDON, DONALD, GUY, SHY, PAULA, ANTONIO, ROBOT, COUNT }
public enum FactionStyle { AMERICAN, MEXICAN, ITALIAN, COUNT }
public enum Attribute { QUALITY, MANAGERRIGHT, FLAVOR, CHEAPLABOR, CHEAPPRODUCE, SERVICE, EXPERIMENT, COUNT };

public class FactionData {
    public string factionName;
    public string playerName;
    public Sprite playerPortrait;
    public FactionStyle style;
    public VoiceType voice;
    public Attribute attribute;

    //public enum FactionStyle { AMERICAN, MEXICAN, ITALIAN, COUNT }

    public Dictionary<Attribute, string> attributeNames = new Dictionary<Attribute, string>()
    {
        {Attribute.QUALITY,  "Quality Chefs"},
        {Attribute.MANAGERRIGHT, "The Manager's Always Right"},
        {Attribute.FLAVOR, "FlavorKingdom" },
        {Attribute.CHEAPLABOR, "Cheap Labor" },
        {Attribute.CHEAPPRODUCE, "Cheap Produce" },
        {Attribute.SERVICE, "Customer Service" },
        {Attribute.EXPERIMENT, "Social Experiment" }
    };

    public Dictionary<VoiceType, string> voiceNames = new Dictionary<VoiceType, string>()
    {
        {VoiceType.GORDON,  "Rough English"},
        {VoiceType.DONALD, "Greedy"},
        {VoiceType.GUY, "Flavor Kingdom" },
        {VoiceType.SHY, "Shy" },
        {VoiceType.PAULA, "Country" },
        {VoiceType.ANTONIO, "Snek Pupp" },
        {VoiceType.ROBOT, "Robot" }
    };

    public Dictionary<FactionStyle, string> foodName = new Dictionary<FactionStyle, string>()
    {
        {FactionStyle.AMERICAN,  "American"},
        {FactionStyle.ITALIAN, "Italian"},
        {FactionStyle.MEXICAN, "Mexican" }
    };

    public Dictionary<Attribute, string> attributeDefinitions = new Dictionary<Attribute, string>()
    {
        {Attribute.QUALITY,  "Employee/chef efficiency increase."},
        {Attribute.MANAGERRIGHT, "Customer influence is not as affected by food quality."},
        {Attribute.FLAVOR, "Recipes can automatically hold one extra \"misc\" ingredient." },
        {Attribute.CHEAPLABOR, "Can hire staff at a discount (increase in restaurant production)" },
        {Attribute.CHEAPPRODUCE, "Can get all ingredients for 5% cheaper." },
        {Attribute.SERVICE, "Customers are more likely to return a second time." },
        {Attribute.EXPERIMENT, "+ 3 Boost to science gained per turn." }
    };


    public static string folderName = "Factions";

    public static FactionData LoadJSON(string filename)
    {
        try
        {
            string json;
            System.IO.StreamReader fileReader = new System.IO.StreamReader(System.IO.Path.Combine(folderName, filename), System.Text.Encoding.Default);
            json = fileReader.ReadLine();
            FactionData faction = JsonUtility.FromJson<FactionData>(json);
            fileReader.Close();
            Debug.Log("Read success: " + System.IO.Path.Combine(folderName, filename));
            return faction;
        }
        catch
        {
            Debug.Log("Failed to load from JSON: " + System.IO.Path.Combine(folderName, filename));
            return null;
        }
    }

    public static void ExportJSON(FactionData faction, string filename)
    {
        try
        {
            string json = JsonUtility.ToJson(faction);
            Debug.Log(json);
            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(System.IO.Path.Combine(folderName, filename), false, System.Text.Encoding.Default);
            fileWriter.WriteLine(json);
            fileWriter.Close();
        }
        catch
        {
            Debug.Log("Failed to save to JSON: " + System.IO.Path.Combine(folderName, filename));
        }
    }
}
