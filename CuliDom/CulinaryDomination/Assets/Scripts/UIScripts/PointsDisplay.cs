using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour {

    public Text points;

	
	// Update is called once per frame
	void Update () {
        points.text = GameController.Instance().activePlayer.ingredientPoints.ToString();

    }
}
