using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PieChart : MonoBehaviour {

    public Color[] colors;
    public GameObject wedgeFab;
    private List<GameObject> wedges;

    public void SetChart(int[] values)
    {
        float total = 0;
        foreach(int i in values)
        {
            total += i;
        }

        if(wedges == null)
        {
            wedges = new List<GameObject>();
        }
        foreach(GameObject wedge in wedges)
        {
            Destroy(wedge);
        }

        float offset = 0;
        for (int i = 0; i < values.Length; i++)
        {
            float frac = values[i] / total;
            GameObject currentWedge = Instantiate(wedgeFab, this.GetComponent<RectTransform>());
            currentWedge.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0,0,offset * -360);
            Image wedgeSprite = currentWedge.GetComponent<Image>();
            wedgeSprite.fillAmount = values[i] / total;
            try
            {
                wedgeSprite.color = colors[i];
            }
            catch
            {

            }
            offset += values[i] / total;
            wedges.Add(currentWedge);
        }
    }
}
