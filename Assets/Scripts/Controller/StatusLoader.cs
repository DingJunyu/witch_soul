using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusLoader : MonoBehaviour {
    bool m_musicPlaying;
    bool m_fullScreen = false;

    private void Start() {
        m_fullScreen = (PlayerPrefs.GetInt("FullScreen", 0) == 1);

        Screen.fullScreen = m_fullScreen;
    }

    // Update is called once per frame
    void Update() {
        if (m_fullScreen != Screen.fullScreen) {
            m_fullScreen = Screen.fullScreen;
            PlayerPrefs.SetInt("FullScreen", m_fullScreen ? 1 : 0);
        }
    }
}
