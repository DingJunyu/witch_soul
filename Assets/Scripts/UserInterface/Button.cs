using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class Button : MonoBehaviour
{
    //使う時に一個しか選ばないで
    public bool pu_closeThis = false;
    public bool pu_detail = false;
    public bool pu_skill = false;

    public GameObject pu_magic;

    // Start is called before the first frame update
    void Start() {
        Button btn = this.GetComponent<Button>();
        EventTrigger trigger = btn.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(OnClick);

        trigger.triggers.Add(entry);
    }

    /*クリック事件*/
    private void OnClick(BaseEventData pointData) {

        if (pu_closeThis)
            CloseThis();
    }

    private void CloseThis() {//メニューを閉じる
        GameObject myParent;
        myParent = transform.parent.gameObject;//メニューオブジェクトを探す
        Destroy(myParent);//メニューを削除
    }

    private void SelectMagic() {
        
    }
}
