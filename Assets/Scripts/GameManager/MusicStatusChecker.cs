using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStatusChecker : ButtonStatusChecker {
    public override void CheckStatus() {
        if (GameObject.Find("MainCamera").GetComponent<AudioSource>().isPlaying)
            SetOn();
        else
            SetOff();
    }
}
