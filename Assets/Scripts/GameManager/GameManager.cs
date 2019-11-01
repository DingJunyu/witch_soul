using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool pu_inGame;

    private bool m_playerSelected = false;
    MouseRecorder o_mouseRecorder;

    private MagicDeployer o_magicDeployer;
    private GameObject o_player;
    public float pu_endLine = 70f;

    private GameObject o_textPlateForEndGame;
    private Text o_textPlateForEndGame_text;
    private GameObject o_button_back;
    private GameObject o_button_replay;
    private GameObject o_button_option;
    private GameObject o_button_returnToMenu;

    private GameObject o_enemyList;
    private GameObject o_bulletList;

    public GameObject pu_loadingScene;
    private GameObject m_loadingScene;
    [SerializeField]
    private bool m_amILoading = false;

    private bool m_endMark = false;

    // Start is called before the first frame update
    void Start() {
        StandardLoading();

        if (pu_inGame)
            Inif_InGame();
        else
            Inif_Menu();
    }

    private void StandardLoading() {
        GameObject.Find("SettingMenu").SetActive(false);
    }

    private void Inif_InGame() {
        o_mouseRecorder = GameObject.Find("MouseRecorder").
            GetComponent<MouseRecorder>();
        o_magicDeployer = GameObject.Find("MagicDeployer").
            GetComponent<MagicDeployer>();
        o_player = GameObject.Find("Player");

        o_textPlateForEndGame = GameObject.Find("TextPlateForEndGame");
        o_textPlateForEndGame_text = o_textPlateForEndGame.GetComponent<Text>();

        o_button_back = GameObject.Find("BackToGame");
        o_button_replay = GameObject.Find("Replay");
        o_button_option = GameObject.Find("Setting");
        o_button_returnToMenu = GameObject.Find("ReturnToMenu");

        o_enemyList = GameObject.Find("EnemyList");
        o_bulletList = GameObject.Find("Bullets");

        EndGameMenu(false);

        Time.timeScale = 1;
    }

    private void Inif_Menu() {
        Time.timeScale = 1;

        m_loadingScene = Instantiate(pu_loadingScene, 
            GameObject.Find("Canvas").gameObject.transform);
        m_loadingScene.SetActive(false);
    }

    public void EndGameMenu(bool func_status) {
        o_textPlateForEndGame.transform.parent.gameObject.SetActive(func_status);
        o_button_replay.SetActive(func_status);
        o_button_option.SetActive(func_status);
        o_button_returnToMenu.SetActive(func_status);

        Time.timeScale = 0;
    }

    public void PauseGameMenu(bool func_status) {
        o_textPlateForEndGame.transform.parent.gameObject.SetActive(func_status);
        o_button_replay.SetActive(func_status);
        o_button_option.SetActive(func_status);
        o_button_returnToMenu.SetActive(func_status);
        o_button_back.SetActive(func_status);

        Time.timeScale = func_status ? 0 : 1;
    }

    // Update is called once per frame
    void Update() {
        if (pu_inGame)
            CheckGameStatus();
    }

    private void CheckGameStatus() {
        if (o_player.transform.position.x > pu_endLine) {
            if (m_endMark)
                return;
            m_endMark = true;
            o_textPlateForEndGame_text.text = "Clear";
            EndGameMenu(true);
        }
        if (!o_player.GetComponent<LifeSystem>().ReferAlive()) {
            if (m_endMark)
                return;
            m_endMark = true;
            o_textPlateForEndGame_text.text = "Game Over";
            EndGameMenu(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            o_textPlateForEndGame_text.text = "Pause";
            PauseGameMenu(true);
        }
        if (Time.timeScale != 0) {
            PauseGameMenu(false);
        }
    }

    public bool SelectAMagic(GameObject func_magicSelected) {
        bool t_answer = o_magicDeployer.SetMagic(func_magicSelected);
        return t_answer;
    }

    public void ChangeSelectStatus(bool func_true) {
        if (Time.timeScale != 1)
            return;

        m_playerSelected = func_true;
        if (func_true)
            o_mouseRecorder.RecordStart();
    }

    IEnumerator LoadAsyncScene(string func_sceneName) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(func_sceneName);
        m_amILoading = true;

        while (!asyncLoad.isDone) {
            CheckMenuStatus(asyncLoad);
            yield return null;
        }
    }

    public void LoadScene(string func_sceneName) {
        StartCoroutine(LoadAsyncScene(func_sceneName));
    }

    public void CheckMenuStatus(AsyncOperation func_asyncLoad) {
        m_loadingScene.SetActive(m_amILoading);
        m_loadingScene.GetComponentInChildren<BarController>().SetPercentage(
            1f-func_asyncLoad.progress, 1f);
    }
}
