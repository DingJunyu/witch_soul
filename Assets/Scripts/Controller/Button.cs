using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Button : UnityEngine.UI.Button {
    public enum Effect {
        none,
        closeThis,
        detail,
        skill,
        openOrClose,
        returnToMainMenu,
        replay,
        changeScene,
        newGame,
        exitGame,
        backToGame
    }

    //使う時に一個しか選ばないで
    public Effect m_effect = Effect.none;

    [Header("遷移機能を有効にするときに名前を入れてください")]
    public string pu_sceneName;

    [Header("スキルを選んだ時に、魔法のprefabをここにドラッグしてください")]
    public GameObject pu_objectHere;
    private GameManager o_gameManager;

    private ButtonAudioController o_clickSource;

    bool t_bool;

    // Start is called before the first frame update
    protected override void Start() {
        o_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        o_clickSource = GameObject.Find("Audio").GetComponent<ButtonAudioController>();
    }

    /*クリック事件*/
    public override void OnPointerClick(PointerEventData pointData) {
        o_clickSource.PlayClip(ButtonAudioController.AudioType.mouseClick);
        base.OnPointerClick(pointData);

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
        if (m_effect == Effect.changeScene)
            o_gameManager.LoadScene(pu_sceneName);
    }

    public override void OnPointerEnter(PointerEventData data) {
        o_clickSource.PlayClip(ButtonAudioController.AudioType.mouseEnter);
        base.OnPointerEnter(data);
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

