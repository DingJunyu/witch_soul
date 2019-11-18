using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    
    void Start() {
        
    }

    
    void Update() {
        Time.timeScale = 0;
    }

    private void OnDestroy() {
        Time.timeScale = 1;

        PlayerPrefs.SetInt("Tutorial", 1);
    }
}
