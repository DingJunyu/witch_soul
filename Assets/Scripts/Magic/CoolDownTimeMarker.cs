using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownTimeMarker : MonoBehaviour {
    
    void Update() {
        int temp_CD = 0;

        if (temp_CD <= 0) {
            GetComponent<Text>().text = null;
            return;
        }

        GetComponent<Text>().text = temp_CD.ToString();
    }
}
