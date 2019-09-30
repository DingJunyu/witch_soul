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
        o_textPlateForEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        CheckGameStatus();
    }

    private void CheckGameStatus() {
        if (o_player.transform.position.x > pu_endLine) {
            Debug.Log("End");
            o_textPlateForEndGame_text.text = "Clear";
            o_textPlateForEndGame.SetActive(true);
        }
        if (!o_player.GetComponent<LifeSystem>().ReferAlive()) {
            o_textPlateForEndGame_text.text = "Game Over";
            o_textPlateForEndGame.SetActive(true);
            Debug.Log("Game Over");

        }
            
    }

    public bool SelectAMagic(GameObject func_magicSelected) {
        return o_magicDeployer.SetMagic(func_magicSelected);
    }

    public void ChangeSelectStatus(bool func_true) {
        m_playerSelected = func_true;
        if (func_true)
            o_mouseRecorder.RecordStart();
    }

    
}
