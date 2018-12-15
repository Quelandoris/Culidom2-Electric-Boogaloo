using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChefType
{
    PRODUCTION,
    TECHNOLOGY,
    POPULARITY
}

//rename to IChef and make children scripts that are the different types of Chefs.
//Better yet, make delegates of the function that matters, and make that function change out what it does
public class Chef : MonoBehaviour
{
    string chefName;
    int level = 1;
    ChefType chefType;
    double chefCost = 5.00;
    double chefXP = 0.0;
    double requiredXP;

    string[] randomFirst = {"Mike", "Bill", "Beto", "Jim", "Arron", "Haley", "Lauren", "Grant", "Matthew", "Antonio", "Serena", "Chris", "Dylan", "Brent", "Mikey",
                            "Jon", "Joe", "Narato"};
    string[] randomLast = { "J.", "O.", "S.", "P.", "W.", "H.", "M.", "D.", "L." };

    string type;
    bool selected = false;

    public Text nameText, costText, typeText, levelText;



    void Awake()
    {
        SetName();
        SetChefType();
        SetRequiredXP(level);
        UpdateChefText();
    }

    public void ResetChef()
    {
        level = 1;
        chefXP = 0.0;
        chefCost = 5.00;
        SetName();
        SetChefType();
        SetRequiredXP(level);
        UpdateChefText();
    }

    void Click()
    {
        selected = true;
    }

    void Update()
    {
        if (chefXP >= requiredXP)
        {
            // chef lvl up
            chefXP = 0.0;
            level++;
            SetRequiredXP(level);
        }
    }

    public void GainXP(double xpGain)
    {
        // use formula to gain xp every turn for each chef
        chefXP += xpGain;
    }

    public void UpdateChefText()
    {
        if (nameText != null)
        {
            nameText.text = chefName;
        }

        if (costText != null)
        {
            costText.text = "Cost: $" + chefCost.ToString("F2");
        }

        if (typeText != null)
        {
            typeText.text = type;
        }

        if (levelText != null)
        {
            levelText.text = "Level: " + level;
        }
    }

    void SetRequiredXP(int levelSet)
    {
        // when chef levels up has a new required xp that is higher to lvl up again
        switch (levelSet)
        {
            case 1:
                requiredXP = 3.0;
                break;
            case 2:
                requiredXP = 8.0;
                break;
            case 3:
                requiredXP = 14.0;
                break;
            case 4:
                requiredXP = 23.0;
                break;
            case 5:
                requiredXP = 35.0;
                break;
            case 6:
                requiredXP = 49.0;
                break;
            case 7:
                requiredXP = 67.0;
                break;
            case 8:
                requiredXP = 88.0;
                break;
            case 9:
                requiredXP = 112.0;
                break;
            default:
                Debug.Log("Required XP was not allocated this time");
                break;

        }
    }

    public void SetName()
    {
        // randomly set name of chef
        chefName = randomFirst[Random.Range(0, randomFirst.Length)] + " " + randomLast[Random.Range(0, randomLast.Length)];
    }

    void SetChefType()
    {
        int choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                chefType = ChefType.PRODUCTION;
                type = "Production";
                break;
            case 1:
                chefType = ChefType.POPULARITY;
                type = "Popularity";
                break;
            case 2:
                chefType = ChefType.TECHNOLOGY;
                type = "Technology";
                break;
            default:
                Debug.Log("No chef type allocated");
                break;

        }
    }

    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ Get Functions \\\\\\\\\\\\\\\\\\
    public ChefType GetChefType()
    {
        return chefType;
    }

    public int GetChefLevel()
    {
        return level;
    }

    public double GetUpkeep()
    {
        return level * 50.00;

    }

    public bool GetSelected()
    {
        return selected;
    }

    public double GetChefCost()
    {
        return chefCost;
    }

    public string GetName()
    {
        return chefName;
    }

    public double GetChefXP()
    {
        return chefXP;
    }

    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ Set Functions \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    public void SetSelected(bool change)
    {
        selected = change;
    }

    public void SetName(string newName)
    {
        chefName = newName;
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
        SetRequiredXP(level);
    }

    public void SetType(ChefType newType)
    {
        chefType = newType;
    }

    public void SetXP(double newXP)
    {
        chefXP = newXP;
    }

    public void SetCost(double newCost)
    {
        chefCost = newCost;
    }

}
