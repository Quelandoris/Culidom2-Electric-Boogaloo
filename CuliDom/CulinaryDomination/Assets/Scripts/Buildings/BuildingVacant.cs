using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BuildingVacant : Building
{

    GameObject window;
    public int price;

    //sound stuff
    public AudioClip sfx_currency_spend_money;
    public AudioSource spendMoney;
    GameObject AudioManager;

    public RestaurantLocalScrollView restaurantScrollScript;

    private void Awake()
    {

        AudioManager = GameObject.Find("@AudioManager");
        //spendMoney = AudioManager.GetComponent<AudioSource>();
        //sfx_currency_spend_money = spendMoney.GetComponent<AudioClip>();
    }


    public override void Click()
    {
        window = canvas.GetComponentInChildren<TilePopupUIManager>().OpenVacant();
        VacantUI ui = window.GetComponent<VacantUI>();
        ui.building = this;
        ui.FillFields(name, price);

    }


    public override void UnClick()
    {
        canvas.GetComponentInChildren<TilePopupUIManager>().CloseUI();
    }

    public void Buy(GameObject restFab)
    {
        //Add to activePlayer's buildings
        WorldTile newTile = Instantiate(restFab, tile.transform.position, Quaternion.identity).GetComponent<WorldTile>();
        newTile.building = ScriptableObject.CreateInstance<BuildingRestaurant>();
        BuildingRestaurant restaurantScript = (BuildingRestaurant)newTile.building;
        GameController.Instance().activePlayer.AddResteraunt(restaurantScript);
        newTile.building.tile = newTile;
        newTile.building.canvas = canvas;
        newTile.district = tile.district;
        Debug.Log("Transfer district to bought tile" + newTile.district);
        newTile.building.name = "Player "+ GameController.Instance().GetPlayerNumber().ToString() + "'s Restaurant";
        newTile.building.world = world;
        DistrictDisplay display = tile.gameObject.GetComponentInChildren<DistrictDisplay>();
        newTile.gameObject.GetComponentInChildren<DistrictDisplay>().SetBorders(display.GetLayout(), display.GetColor());
        world.allTiles.Add(newTile.gameObject);
        world.allTiles.Remove(tile.gameObject);
        tile.UnClick();
        Destroy(tile.gameObject);
        //sound
        spendMoney.PlayOneShot(sfx_currency_spend_money);
    }

    public WorldTile Buy(GameObject restFab, int playerNumber) {
        //Add to purchaser's buildings
        WorldTile newTile = Instantiate(restFab, tile.transform.position, Quaternion.identity).GetComponent<WorldTile>();
        newTile.building = ScriptableObject.CreateInstance<BuildingRestaurant>();
        BuildingRestaurant restaurantScript = (BuildingRestaurant)newTile.building;

        GameController.Instance().player[playerNumber].AddResteraunt(restaurantScript);
        newTile.building.tile = newTile;
        newTile.building.canvas = canvas;
        newTile.district = tile.district;
        newTile.building.name = "Player " + (playerNumber+1).ToString() + "'s Restaurant";
        newTile.building.world = world;
        DistrictDisplay display = tile.gameObject.GetComponentInChildren<DistrictDisplay>();
        newTile.gameObject.GetComponentInChildren<DistrictDisplay>().SetBorders(display.GetLayout(), display.GetColor());
        world.allTiles.Add(newTile.gameObject);
        world.allTiles.Remove(tile.gameObject);
        tile.UnClick();
        //sound
        try
        {
            spendMoney.PlayOneShot(sfx_currency_spend_money);
        }
        catch { }

        //After this function, nothing here will run I think.
        Destroy(tile.gameObject);
        return newTile;
    }
}



