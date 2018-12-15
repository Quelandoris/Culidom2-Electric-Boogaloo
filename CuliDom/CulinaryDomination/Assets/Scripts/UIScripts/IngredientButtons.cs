using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButtons : MonoBehaviour {


    public GameObject chickenImage, beefImage, porkImage, wheatImage, riceImage, potatoeImage, milkImage, cheeseImage, butterImage,
        bachamelImage, redSauceImage, gravyImage, tomatoeImage, garlicImage, lettuceImage;


    public void Update()
    {
        
    }


    public void UpdateIngredientButtons() {

    }

    /*
     * Disabling these functions
     */

    //defunct function attempt
    public void Button(RecipeIngredient r, Transform t) {
        switch (r) {
            case RecipeIngredient.CHICKEN:
                ChickenButton(t);
                break;
            default:
                Debug.Log("It's not chicken");
                break;
        }
    }

    public void ChickenButton(Transform t)
    {
        //chickenImage.gameObject.SetActive(true);
        //chickenImage.gameObject.transform.position = t.position;
        beefImage.gameObject.SetActive(false);
        porkImage.gameObject.SetActive(false);
        Debug.Log("chicken is displayed");
    }

    public void BeefButton()
    {
        chickenImage.gameObject.SetActive(false);
        //beefImage.gameObject.SetActive(true);
        porkImage.gameObject.SetActive(false);
    }

    public void PorkButton()
    {
        chickenImage.gameObject.SetActive(false);
        beefImage.gameObject.SetActive(false);
        //porkImage.gameObject.SetActive(true);
    }

    public void WheatButton()
    {
        //wheatImage.gameObject.SetActive(true);
        riceImage.gameObject.SetActive(false);
        potatoeImage.gameObject.SetActive(false);
    }

    public void RiceButton()
    {
        wheatImage.gameObject.SetActive(false);
        //riceImage.gameObject.SetActive(true);
        potatoeImage.gameObject.SetActive(false);
    }

    public void PotatoeButton()
    {
        wheatImage.gameObject.SetActive(false);
        riceImage.gameObject.SetActive(false);
        //potatoeImage.gameObject.SetActive(true);
    }

    public void MilkButton()
    {
        //milkImage.gameObject.SetActive(true);
        butterImage.gameObject.SetActive(false);
        cheeseImage.gameObject.SetActive(false);
    }

    public void CheeseButton()
    {
        milkImage.gameObject.SetActive(false);
        butterImage.gameObject.SetActive(false);
        //cheeseImage.gameObject.SetActive(true);
    }

    public void ButterButton()
    {
        milkImage.gameObject.SetActive(false);
        //butterImage.gameObject.SetActive(true);
        cheeseImage.gameObject.SetActive(false);
    }

    public void BachamelButton()
    {
        gravyImage.gameObject.SetActive(false);
        //bachamelImage.gameObject.SetActive(true);
        redSauceImage.gameObject.SetActive(false);
    }

    public void RedSauceButton()
    {
        gravyImage.gameObject.SetActive(false);
        bachamelImage.gameObject.SetActive(false);
        //redSauceImage.gameObject.SetActive(true);
    }

    public void GravyButton()
    {
        //gravyImage.gameObject.SetActive(true);
        bachamelImage.gameObject.SetActive(false);
        redSauceImage.gameObject.SetActive(false);
    }

    public void TomatoeButton()
    {
        //tomatoeImage.gameObject.SetActive(true);
        lettuceImage.gameObject.SetActive(false);
        garlicImage.gameObject.SetActive(false);
    }

    public void GarlicButton()
    {
        tomatoeImage.gameObject.SetActive(false);
        lettuceImage.gameObject.SetActive(false);
        //garlicImage.gameObject.SetActive(true);
    }

    public void LettuceButton()
    {
        tomatoeImage.gameObject.SetActive(false);
        //lettuceImage.gameObject.SetActive(true);
        garlicImage.gameObject.SetActive(false);
    }
}
