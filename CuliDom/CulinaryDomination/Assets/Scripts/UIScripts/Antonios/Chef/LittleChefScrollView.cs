using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleChefScrollView : MonoBehaviour {

    /*RectTransform chefContent;

    public GameObject chefPrefab;

    public void Awake()
    {
        chefContent = gameObject.GetComponent<RectTransform>();
    }


    public void CreateContent(BuildingRestaurant restaurant) {
        for (int i = 0; i < restaurant.chefs.Count; i++) {
            GameObject newChefButton = Instantiate(chefPrefab);
            newChefButton.transform.SetParent(chefContent);
            chefContent.sizeDelta = new Vector2(chefContent.rect.width, chefContent.rect.height + 60);
            newChefButton.transform.localScale = new Vector3(1f, 1f, 1f);
            Chef chefReference = newChefButton.GetComponent<Chef>();

            chefReference.SetName(restaurant.chefs[i].GetName());
            chefReference.SetLevel(restaurant.chefs[i].GetChefLevel());
            chefReference.SetType(restaurant.chefs[i].GetChefType());
            chefReference.SetCost(restaurant.chefs[i].GetChefCost());
            chefReference.SetXP(restaurant.chefs[i].GetChefXP());
            chefReference.UpdateChefText();
        }
    }

    public void DeleteContent()
    {
        int count = 0;
        GameObject[] destroyThese;

        foreach (Transform childTransform in chefContent.transform)
        {
            count++;
        }
        destroyThese = new GameObject[count];
        count = 0;
        foreach (Transform childTransform in chefContent.transform)
        {
            destroyThese[count] = childTransform.gameObject;
            count++;
        }

        for (int i = 0; i < destroyThese.Length; i++)
        {
            Destroy(destroyThese[i]);
        }
    }*/
}
