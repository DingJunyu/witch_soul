using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class Button : MonoBehaviour
{
    public enum Effect {
        none,
        closeThis,
        detail,
        skill,
        openOrClose
    }

    //使う時に一個しか選ばないで
    public Effect m_effect = Effect.none;

    public GameObject pu_objectHere;
    private GameManager o_gameManager;

    private float m_lastClickTime = 0f;

    // Start is called before the first frame update
    void Start() {
        Button btn = this.GetComponent<Button>();
        EventTrigger trigger = btn.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        o_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        entry.eventID = EventTriggerType.PointerClick;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(OnClick);

        trigger.triggers.Add(entry);
    }

    /*クリック事件*/
    private void OnClick(BaseEventData pointData) {

        if (m_effect == Effect.closeThis)
            CloseThis();
        if (m_effect == Effect.skill)
            SelectMagic();
        if (m_effect == Effect.openOrClose)
            OpenOrClose();

    }

    private void CloseThis() {//メニューを閉じる
        GameObject myParent;
        myParent = transform.parent.gameObject;//メニューオブジェクトを探す
        Destroy(myParent);//メニューを削除
    }

    private void SelectMagic() {
        if (m_lastClickTime + pu_objectHere.GetComponent<Magic_Base>().ReferCD() > Time.time)
            return;

        bool t_bool = !o_gameManager.SelectAMagic(pu_objectHere);


        if (t_bool)
            m_lastClickTime = Time.time;
    }

    private void OpenOrClose() {
        pu_objectHere.SetActive(!pu_objectHere.active);
    }
}
