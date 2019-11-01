using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChanger : MonoBehaviour {
    int m_theOldStatus;
    const int mc_standardStatus = 5;
    public void SetTheOldStatus(int func_status) { m_theOldStatus = func_status; }
    Dropdown m_dropDown;

    private void Awake() {
        m_theOldStatus = PlayerPrefs.GetInt("Resolution", mc_standardStatus);

        m_dropDown = GetComponentInChildren<Dropdown>();
        m_dropDown.value = m_theOldStatus;
        CheckRes();
    }

    private void Update() {
        if (m_theOldStatus == m_dropDown.value)
            return;

        CheckRes();
        m_theOldStatus = m_dropDown.value;

        PlayerPrefs.DeleteKey("Resolution");
        PlayerPrefs.SetInt("Resolution", m_theOldStatus);
    }

    public void CheckRes() {
        switch (m_dropDown.value) {
            case 0: Screen.SetResolution(1280, 1024, Screen.fullScreen); break;
            case 1: Screen.SetResolution(1680, 1050, Screen.fullScreen); break;
            case 2: Screen.SetResolution(1366, 768, Screen.fullScreen); break;
            case 3: Screen.SetResolution(1600, 900, Screen.fullScreen); break;
            case 4: Screen.SetResolution(1920, 1080, Screen.fullScreen); break;
        }
    }
}
