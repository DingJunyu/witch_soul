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
        backToGame,
        setFullScreen,
        setBGM,
        resetTutorial
    }

    //使う時に一個しか選ばないで
    public Effect m_effect = Effect.none;

    [Header("遷移機能を有効にするときに名前を入れてください")]
    public string pu_sceneName;

    [Header("スキルを選んだ時に、魔法のprefabをここにドラッグしてください")]
    public GameObject pu_objectHere;
    private GameManager o_gameManager;

    private ButtonAudioController o_clickSource;
    private GameObject o_mainCamera;

    bool t_bool;

    // Start is called before the first frame update
    protected override void Start() {
        o_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        o_clickSource = GameObject.Find("Audio").GetComponent<ButtonAudioController>();
        o_mainCamera = GameObject.Find("MainCamera");
    }

    /*クリック事件*/
    public override void OnPointerClick(PointerEventData pointData) {
        o_clickSource.PlayClip(ButtonAudioController.AudioType.mouseClick);
        base.OnPointerClick(pointData);

        switch (m_effect) {
            case Effect.closeThis:
                CloseThis();break;

            case Effect.skill:
                SelectMagic();break;

            case Effect.openOrClose:
                OpenOrClose();break;

            case Effect.replay:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);break;

            case Effect.backToGame:
                Time.timeScale = 1;break;

            case Effect.returnToMainMenu:
                SceneManager.LoadScene("MainMenu"); break;

            case Effect.newGame:
                SceneManager.LoadScene("Stage_1"); break;

            case Effect.exitGame:
                Application.Quit(); break;

            case Effect.changeScene:
                o_gameManager.MyLoadScene(pu_sceneName);break;

            case Effect.setFullScreen:
                Screen.fullScreen = !Screen.fullScreen;
                GetComponentInChildren<ButtonStatusChecker>().CheckStatus(); break;

            case Effect.setBGM:
                if (o_mainCamera.GetComponent<AudioSource>().isPlaying)
                    o_mainCamera.GetComponent<AudioSource>().Stop();
                else
                    o_mainCamera.GetComponent<AudioSource>().Play();
                GetComponentInChildren<ButtonStatusChecker>().CheckStatus(); break;

            case Effect.resetTutorial:
                PlayerPrefs.DeleteKey("Tutorial");break;
        }
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

