using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private bool m_playerSelected = false;
    MouseRecorder o_mouseRecorder;

    private MagicDeployer o_magicDeployer;
    private GameObject o_player;
    public float pu_endLine = 70f;

    private GameObject o_textPlateForEndGame;
    private Text o_textPlateForEndGame_text;
    private GameObject o_button_replay;
    private GameObject o_button_returnToMenu;

    private bool m_endMark = false;

    // Start is called before the first frame update
    void Start() {
        Inif();
    }

    private void Inif() {
        o_mouseRecorder = GameObject.Find("MouseRecorder").
            GetComponent<MouseRecorder>();
        o_magicDeployer = GameObject.Find("MagicDeployer").
            GetComponent<MagicDeployer>();
        o_player = GameObject.Find("Player");

        o_textPlateForEndGame = GameObject.Find("TextPlateForEndGame");
        o_textPlateForEndGame_text = o_textPlateForEndGame.GetComponent<Text>();

        o_button_replay = GameObject.Find("Replay");

        o_button_returnToMenu = GameObject.Find("ReturnToMenu");

        EndGameMenu(false);

    }

    public void EndGameMenu(bool func_status) {
        o_textPlateForEndGame.SetActive(func_status);
        o_button_replay.SetActive(func_status);
        o_button_returnToMenu.SetActive(func_status);
    }

    // Update is called once per frame
    void Update() {
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
    }

    public bool SelectAMagic(GameObject func_magicSelected) {
        bool t_answer = o_magicDeployer.SetMagic(func_magicSelected);
        return t_answer;
    }

    public void ChangeSelectStatus(bool func_true) {
        m_playerSelected = func_true;
        if (func_true)
            o_mouseRecorder.RecordStart();
    }
}
