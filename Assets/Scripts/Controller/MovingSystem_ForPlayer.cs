using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem_ForPlayer : MovingSystem {
    GameObject gameManager;
    MouseRecorder m_mouseRecorder;

    protected override void GetNextPos() {
        if (m_mouseRecorder.HasRecordData()) {
            m_nextPos = m_mouseRecorder.ReferNextPoint(false);
        }
    }

    protected override void SonInif() {
        gameManager = GameObject.Find("GameManager");
        m_mouseRecorder = GameObject.Find("MouseRecorder").
           GetComponent<MouseRecorder>();
    }

    private void OnMouseDown() {
        gameManager.GetComponent<GameManager>().changeSelectStatus(true);
    }
}
