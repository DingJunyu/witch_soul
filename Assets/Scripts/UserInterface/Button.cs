using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class Button : MonoBehaviour
{
    public enum Effect {
        none,
        closeThis,
        detail,
        skill,
        openOrClose,
        returnToMainMenu,
        replay,
        newGame,
        exitGame,
        backToGame
    }

    //使う時に一個しか選ばないで
    public Effect m_effect = Effect.none;

    public GameObject pu_objectHere;
    private GameManager o_gameManager;

    bool t_bool;

    // Start is called before the first frame update
    void Start() {
        Button btn = this.GetComponent<Button>();
        EventTrigger trigger = btn.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        if(m_effect == Effect.skill)
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
        if (m_effect == Effect.replay)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (m_effect == Effect.backToGame)
            Time.timeScale = 1;
        if (m_effect == Effect.returnToMainMenu)
            SceneManager.LoadScene("MainMenu");
        if (m_effect == Effect.newGame)
            SceneManager.LoadScene("Stage_1");
        if (m_effect == Effect.exitGame)
            Application.Quit();
    }

    private void CloseThis() {//メニューを閉じる
        GameObject myParent;
        myParent = transform.parent.gameObject;//メニューオブジェクトを探す
        Destroy(myParent);//メニューを削除
    }

    private void SelectMagic() {
        bool t_bool = o_gameManager.SelectAMagic(pu_objectHere);
    }

    private void OpenOrClose() {
        pu_objectHere.SetActive(!pu_objectHere.activeSelf);
    }
}
