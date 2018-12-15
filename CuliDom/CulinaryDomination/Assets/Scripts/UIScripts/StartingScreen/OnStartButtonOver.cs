using UnityEngine;
using UnityEngine.EventSystems;

public class OnStartButtonOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rect;
    Vector2 orig;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        rect = this.GetComponent<RectTransform>();
        orig = rect.sizeDelta;
        rect.sizeDelta = new Vector2(170, 150);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        rect.sizeDelta = orig;
    }
    //detect when player presses the button
    public void PressButton()
    {
        rect.sizeDelta = orig;
    }
}