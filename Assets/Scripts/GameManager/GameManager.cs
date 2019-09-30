using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool m_playerSelected = false;
    MouseRecorder o_mouseRecorder;

    private MagicDeployer o_magicDeployer;
    private GameObject o_player;
    public float pu_endLine = 70f;

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
    }

    // Update is called once per frame
    void Update() {
        CheckGameStatus();
    }

    private void CheckGameStatus() {
        if (o_player.transform.position.x > pu_endLine) {
            Debug.Log("End");
        }
        if (!o_player.GetComponent<LifeSystem>().ReferAlive()) {
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
