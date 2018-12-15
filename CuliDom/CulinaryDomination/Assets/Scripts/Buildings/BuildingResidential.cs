using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IncomeLevel
{
    LOW,
    MIDDLE,
    HIGH
}

public enum FoodPreference
{
    NONE,
    AMERICAN,
    ITALIAN,
    MEXICAN
}

public enum ResidentType
{
    URBAN,
    SUBURB,
    ROAD,
    RURAL
}

public class BuildingResidential : Building {
    static readonly string[] urbanStart = { "Riverview", "Main Street", "Highlands", "Metropolitan", "Skyscape", "Downtown", "Cloudbank", "Riverwalk", "Sunrise", "Moonrise",
                                            "Sunset", "Opportunity", "Synergy", "Progress", "Tomorrow", "Clearsky", "Cityscape", "Outlook", "Incline", "Success"};
    static readonly string[] urbanEnd = { "Center", "District", "Vista", "Building", "Park", "Tower", "Headquarters", "Branch", "Living", "Venture" };
    static readonly string[] suburbStart = { "Sleepy Oak", "Calm Meadows", "Homely", "Lazy Breeze", "Gentle Brook", "Green Tree", "Autumn Leaf", "Palm Breeze", "Pond", "Quiet",
                                             "Uptown", "Lost Woods", "Old Maple", "Tall Pine", "Sage", "Rosemary", "Basil", "Bay Leaf", "Cinnamon", "Chestnut",
                                             "Parsnip", "Thyme", "Nutmeg", "Cumin", "Chili", "Peppercorn", "Lemon", "Lime", "Spice", "Vanilla"};
    static readonly string[] suburbEnd = { "Place", "Street", "Boulevard", "Lane", "Homes", "Community", "Reaches", "Residence", "Run", "Housing" };
    static readonly string[] ruralStart = { "Green", "Forested", "Rolling", "Fertile", "Stardew", "Timber", "Grassy", "Earthy", "Windswept", "Sunshine",
                                            "Lush", "Verdant", "Leafy", "Flourishing", "Fresh", "Crisp", "Natural", "Essential", "Central", "Vital",
                                            "Basic", "Carpeted", "Tangled", "Burgeoning", "Crescent"};
    static readonly string[] ruralEnd = { "Acres", "Farms", "Meadows", "Fields", "Ranch", "Valley", "Plantery", "Acreage", "Garden", "Orchard",
                                          "Pasture", "Farmstead", "Patch", "Vineyard", "Grange", "Homestead", "Lawn", "Range", "Prarie", "Plains"};

    static Object lockObj = new Object();
    static List<string> takenNames = new List<string>();


    GameObject window;
    public List<Pop> residents = new List<Pop>();

    public ResidentType type;

    public override void Click()
    {
        Debug.Log(canvas);
        window = canvas.GetComponentInChildren<TilePopupUIManager>().OpenDistrict();
        DistrictUI ui = window.GetComponent<DistrictUI>();
        ui.building = this;
        ui.FillFields(this);
    }


    public override void UnClick()
    {
        canvas.GetComponentInChildren<TilePopupUIManager>().CloseUI();
    }

    public ResSummary GenerateSummary()
    {
        ResSummary summary = new ResSummary();

        summary.population = residents.Count;
        summary.name = name;

        int lowIn = 0;
        int midIn = 0;
        int highIn = 0;

        int amerPref = 0;
        int italPref = 0;
        int mexPref = 0;

        List<RecipeIngredient> likes = new List<RecipeIngredient>();

        List<RecipeIngredient> hates = new List<RecipeIngredient>();

        foreach(Pop res in residents)
        {
            switch (res.income)
            {
                case IncomeLevel.LOW:
                    lowIn++;
                    break;
                case IncomeLevel.MIDDLE:
                    midIn++;
                    break;
                case IncomeLevel.HIGH:
                    highIn++;
                    break;
            }
            switch (res.preference)
            {
                case FoodPreference.AMERICAN:
                    amerPref++;
                    break;
                case FoodPreference.ITALIAN:
                    italPref++;
                    break;
                case FoodPreference.MEXICAN:
                    mexPref++;
                    break;
            }

            if (res.favoriteIngredient != RecipeIngredient.EMPTY && !likes.Contains(res.favoriteIngredient))
            {
                likes.Add(res.favoriteIngredient);
            }

            if (res.hatedIngredient != RecipeIngredient.EMPTY && !hates.Contains(res.hatedIngredient))
            {
                hates.Add(res.hatedIngredient);
            }
        }

        float perLowIn = (float)lowIn / residents.Count;
        float perMidIn = (float)midIn / residents.Count;
        float perHighIn = (float)highIn / residents.Count;

        float perAmerPref = (float)amerPref / residents.Count;
        float perItalPref = (float)italPref / residents.Count;
        float perMexPref = (float)mexPref / residents.Count;

        if(lowIn == residents.Count)
        {
            summary.income = "Low";
        }
        else if (midIn == residents.Count)
        {
            summary.income = "Middle";
        }
        else if(highIn == residents.Count)
        {
            summary.income = "High";
        }
        else if(perLowIn >= 0.4f && perMidIn >= 0.4f)
        {
            summary.income = "Mixed Low/Middle";
        }
        else if (perLowIn >= 0.4f && perHighIn >= 0.4f)
        {
            summary.income = "Mixed Low/High";
        }
        else if (perMidIn >= 0.4f && perHighIn >= 0.4f)
        {
            summary.income = "Mixed Middle/High";
        }
        else if (perLowIn >= 2.0f / 3)
        {
            summary.income = "Mostly Low";
        }
        else if (perMidIn >= 2.0f / 3)
        {
            summary.income = "Mostly Middle";
        }
        else if (perHighIn >= 2.0f / 3)
        {
            summary.income = "Mostly High";
        }
        else
        {
            summary.income = "Mixed";
        }

        List<string> preferences = new List<string>();

        if(perAmerPref >= 1.0f / 3)
        {
            preferences.Add("American");
        }
        if (perItalPref >= 1.0f / 3)
        {
            preferences.Add("Italian");
        }
        if (perMexPref >= 1.0f / 3)
        {
            preferences.Add("Mexican");
        }

        if(preferences.Count == 0)
        {
            summary.preference = "None";
        }
        else
        {
            string pref = "";
            foreach(string s in preferences)
            {
                pref = pref + s + ", ";
            }
            pref = pref.Substring(0, pref.Length - 2);
            summary.preference = pref;
        }

        if (likes.Count == 0)
        {
            summary.favorites = "None";
        }
        else
        {
            string like = "";
            foreach (RecipeIngredient ing in likes)
            {
                if (ing != RecipeIngredient.EMPTY)
                {
                    like = like + Ingredient.IngredientToString(ing) + ", ";
                }

            }
            if (like[like.Length - 1] == ' ')
            {
                like = like.Substring(0, like.Length - 2);
            }
            summary.favorites = like;
        }

        if (hates.Count == 0)
        {
            summary.hates = "None";
        }
        else
        {
            string hate = "";
            foreach (RecipeIngredient ing in hates)
            {
                if (ing != RecipeIngredient.EMPTY)
                {
                    hate = hate + Ingredient.IngredientToString(ing) + ", ";
                }
            }
            if (hate[hate.Length - 1] == ' ')
            {
                hate = hate.Substring(0, hate.Length - 2);
            }
            summary.hates = hate;
        }

        summary.debugIncome = "Low: " + lowIn + " / Mid: " + midIn + " / High: " + highIn;
        summary.debugPref = "Amer: " + amerPref + " / Ital: " + italPref + " / Mex: " + mexPref;

        return summary;
    }

    public static string GenerateName(ResidentType type)
    {
        int tries = 0;
        string n = "";
        bool needName = true;
        while (needName)
        {
            switch (type)
            {
                case ResidentType.ROAD:
                    n = "Highway " + Random.Range(1, 999);
                    break;
                case ResidentType.URBAN:
                    
                    n = urbanStart[Random.Range(0, urbanStart.Length)] + " " + urbanEnd[Random.Range(0, urbanEnd.Length)];
                    break;
                case ResidentType.SUBURB:
                    
                    n = suburbStart[Random.Range(0, suburbStart.Length)] + " " + suburbEnd[Random.Range(0, suburbEnd.Length)];
                    break;

                case ResidentType.RURAL:

                    n = ruralStart[Random.Range(0, ruralStart.Length)] + " " + ruralEnd[Random.Range(0, ruralEnd.Length)];
                    break;
            }
            lock (lockObj)
            {
                if (!takenNames.Contains(n))
                {
                    takenNames.Add(n);
                    needName = false;
                }
                else if(tries > 100)
                {
                    needName = false;
                }
                else
                {
                    tries++;
                }
            }
        }
        return n;
    }
}

public struct Pop
{
    public IncomeLevel income;
    public FoodPreference preference;
    public RecipeIngredient favoriteIngredient;
    public RecipeIngredient hatedIngredient;

    public static DishCategory ToCategory(FoodPreference pref)
    {
        switch (pref)
        {
            case FoodPreference.AMERICAN:
                return DishCategory.AMERICAN;
            case FoodPreference.ITALIAN:
                return DishCategory.ITALIAN;
            case FoodPreference.MEXICAN:
                return DishCategory.MEXICAN;
        }
        return 0;
    }
}

public struct ResSummary
{
    public string name;
    public int population;
    public string income;
    public string preference;
    public string favorites;
    public string hates;

    public string debugIncome;
    public string debugPref;
}



