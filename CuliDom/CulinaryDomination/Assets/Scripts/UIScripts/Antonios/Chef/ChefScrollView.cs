using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefScrollView : MonoBehaviour {

    public int amountOfChefs = 0;
    public GameObject chefEmpireScreenPrefab;
    public RectTransform content;

    public void AddAChefButton(Chef newChef) {

        GameObject newChefButton = Instantiate(chefEmpireScreenPrefab);
        newChefButton.transform.SetParent(content);
        newChefButton.transform.localScale = new Vector3(1f, 1f, 1f);
        Chef chefReference = newChefButton.GetComponent<Chef>();

        chefReference.SetName(newChef.GetName());
        chefReference.SetLevel(newChef.GetChefLevel());
        chefReference.SetType(newChef.GetChefType());
        chefReference.SetCost(newChef.GetChefCost());
        chefReference.SetXP(newChef.GetChefXP());
        chefReference.UpdateChefText();
    }

    public void CreateContent() {
        for (int i = 0; i < GameController.Instance().activePlayer.ownedChefs.Count; i++) {
            GameObject newChefButton = Instantiate(chefEmpireScreenPrefab);
            newChefButton.transform.SetParent(content);
            content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 60);
            newChefButton.transform.localScale = new Vector3(1f, 1f, 1f);
            Chef chefReference = newChefButton.GetComponent<Chef>();

            chefReference.SetName(GameController.Instance().activePlayer.ownedChefs[i].GetName());
            chefReference.SetLevel(GameController.Instance().activePlayer.ownedChefs[i].GetChefLevel());
            chefReference.SetType(GameController.Instance().activePlayer.ownedChefs[i].GetChefType());
            chefReference.SetCost(GameController.Instance().activePlayer.ownedChefs[i].GetChefCost());
            chefReference.SetXP(GameController.Instance().activePlayer.ownedChefs[i].GetChefXP());
            chefReference.UpdateChefText();
        }
    }

    public void DeleteContent() {
        int count = 0;
        GameObject[] destroyThese;

        foreach (Transform childTransform in content.transform) {
            count++;
        }
        destroyThese = new GameObject[count];
        count = 0;
        foreach (Transform childTransform in content.transform)
        {
            destroyThese[count] = childTransform.gameObject;
            count++;
        }

        for (int i = 0; i < destroyThese.Length; i++) {
            Destroy(destroyThese[i]);
        }
    }
    // Create function that repopulates and one that, destroys all them all
}
