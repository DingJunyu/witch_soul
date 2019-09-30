using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownTimeMarker : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        int temp_CD;
        temp_CD = transform.parent.GetComponent<Button>().
            ReferCD();

        if (temp_CD < 0) {
            GetComponent<Text>().text = null;
            return;
        }

        GetComponent<Text>().text = temp_CD.ToString();
    }
}
