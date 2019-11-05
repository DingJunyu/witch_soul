using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = 0;
    }

    private void OnDestroy() {
        Time.timeScale = 1;

        PlayerPrefs.SetInt("Tutorial", 1);
    }
}
