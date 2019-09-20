using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool m_playerSelected = false;
    MouseRecorder o_mouseRecorder;

    // Start is called before the first frame update
    void Start() {
        Inif();
    }

    private void Inif() {
        o_mouseRecorder = GameObject.Find("MouseRecorder").
            GetComponent<MouseRecorder>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void changeSelectStatus(bool func_true) {
        m_playerSelected = func_true;
        if (func_true)
            o_mouseRecorder.RecordStart();
    }
}
