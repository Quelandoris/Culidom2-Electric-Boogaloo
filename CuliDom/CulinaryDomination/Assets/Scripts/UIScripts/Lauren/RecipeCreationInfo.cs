using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCreationInfo : MonoBehaviour {

    public GameObject recipePrefab;
    public RectTransform content;
    public MenuButtons replacementButton;

    private void OnEnable()
    {
        for (int i = 0; i < GameController.Instance().activePlayer.savedRecipies.Count; i++)
        {
            GameObject savedRecipe = Instantiate(recipePrefab);
            savedRecipe.GetComponent<RecipeReplacement>().replacementRecipe = GameController.Instance().activePlayer.savedRecipies[i];
            savedRecipe.GetComponent<RecipeReplacement>().replacementButton = replacementButton;
            savedRecipe.transform.parent = content;
            //content.sizeDelta = new Vector2(content.rect.width, content.rect.height + 20);
            savedRecipe.GetComponentInChildren<Text>().text = GameController.Instance().activePlayer.savedRecipies[i].name;
            savedRecipe.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnDisable()
    {
        int count = 0;
        GameObject[] destroyThese;
        if (content.transform.childCount > 0)
        {
            foreach (Transform childTransform in content.transform)
            {
                count++;
            }
            destroyThese = new GameObject[count];

            count = 0;

            foreach (Transform childTransform in content.transform)
            {
                destroyThese[count] = childTransform.gameObject;
                count++;
            }

            for (int i = 0; i < destroyThese.Length; i++)
            {
                Destroy(destroyThese[i]);
            }
        }
    }
}
