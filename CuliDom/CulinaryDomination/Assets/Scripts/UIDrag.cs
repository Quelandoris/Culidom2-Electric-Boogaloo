using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler, IEndDragHandler {

    Vector3 offset = Vector3.zero;
    bool held = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (!held)
        {
            offset = transform.position - Input.mousePosition;
            held = true;
        }
        transform.position = Input.mousePosition + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        held = false;
        //Make sure it's still in the window
    }
}
