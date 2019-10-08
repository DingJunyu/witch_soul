using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem_ForPlayer : MovingSystem {
    GameObject o_gameManager;
    MouseRecorder m_mouseRecorder;

    protected override void GetNextPos() {
        if (m_mouseRecorder.HasRecordData()) {
            m_nextPos.Copy(m_mouseRecorder.ReferNextPoint(false));
            Test_ShowPos();
        }
        else {
            m_nextPos.SetPoint(transform.position);
        }
    }

    protected override void SonInif() {
        o_gameManager = GameObject.Find("GameManager");
        m_mouseRecorder = GameObject.Find("MouseRecorder").
           GetComponent<MouseRecorder>();
    }

    protected override void SonUpdate() {
        
    }

    private void OnMouseDown() {
        o_gameManager.GetComponent<GameManager>().ChangeSelectStatus(true);
    }

    protected override void OtherCollisionReact() {
        m_mouseRecorder.EndReading();
    }
}
