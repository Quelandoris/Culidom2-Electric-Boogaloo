using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FoodTypes { DAIRY, PROTEIN, STARCH, SAUCE, MISC };
public class DishData {

    

    public string dishName;
    public GameObject dishPicture;
    public static string dishFolder = "Dishes";
    // was called "foodSlots" before change
    public List<FoodTypes> requiredFoodSlots = new List<FoodTypes>();
    public List<FoodTypes> optionalFoodSlots = new List<FoodTypes>();
    public List<DishData> allTheDishes = new List<DishData>();
    public DishCategory category;

    


    public static DishData LoadJSON(string filename)
    {
        try
        {
            string json;
            System.IO.StreamReader fileReader = new System.IO.StreamReader(System.IO.Path.Combine(dishFolder, filename), System.Text.Encoding.Default);
            json = fileReader.ReadLine();
            DishData dish = JsonUtility.FromJson<DishData>(json);
            fileReader.Close();
            Debug.Log("Read success: " + System.IO.Path.Combine(dishFolder, filename));
            return dish;
        }
        catch
        {
            Debug.Log("Failed to load from JSON: " + System.IO.Path.Combine(dishFolder, filename));
            return null;
        }
    }

    public static void ExportJSON(DishData dish, string filename)
    {
        try
        {
            string json = JsonUtility.ToJson(dish);
            Debug.Log(json);
            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(System.IO.Path.Combine(dishFolder, filename), false, System.Text.Encoding.Default);
            fileWriter.WriteLine(json);
            fileWriter.Close();
        }
        catch
        {
            Debug.Log("Failed to save to JSON: " + System.IO.Path.Combine(dishFolder, filename));
        }
    }



}
