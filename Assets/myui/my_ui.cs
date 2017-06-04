using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class my_ui : EventTrigger {
    //public void OnDrag() { transform.position = Input.mousePosition; }

    public override void OnDrag(PointerEventData data)
    {
        //Debug.Log("OnDrag called.");
        transform.position = Input.mousePosition;
    }
}
