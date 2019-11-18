using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDataSpy : MonoBehaviour {
    public float m_coordOnScreen_x;
    public float m_coordOnScreen_y;
    public float m_coordOnScreen_z;

    public float m_coordInWorld_x;
    public float m_coordInWorld_y;
    public float m_coordInWorld_z;

    Vector3 m_coordOnScreen;
    Vector3 m_coordInWorld;

    private Camera o_mainCamera;

    
    void Start() {
        Inif();
    }

    void Inif() {
        o_mainCamera = Camera.main;
    }

    
    void Update() {
        GetData();
        Change();
    }

    private void GetData() {
        m_coordOnScreen = Input.mousePosition;
        m_coordInWorld = o_mainCamera.ScreenToWorldPoint(
            new Vector3(m_coordOnScreen.x, m_coordOnScreen.y,
            o_mainCamera.transform.position.y));
    }

    private void Change() {
        m_coordOnScreen_x = m_coordOnScreen.x;
        m_coordOnScreen_y = m_coordOnScreen.y;
        m_coordOnScreen_z = m_coordOnScreen.z;

        m_coordInWorld_x = m_coordInWorld.x;
        m_coordInWorld_y = m_coordInWorld.y;
        m_coordInWorld_z = m_coordInWorld.z;
    }
}
