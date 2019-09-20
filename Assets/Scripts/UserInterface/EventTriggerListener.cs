using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerListener : EventTrigger 
{
    private void OnClick(BaseEventData pointData) {
        Debug.Log("Button Clicked. EventTrigger..");
    }
}
