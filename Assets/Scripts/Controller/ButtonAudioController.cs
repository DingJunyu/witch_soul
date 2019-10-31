using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioController : MyAudioController {
    public enum AudioType {
        mouseEnter,
        mouseClick
    }

    public AudioClip pu_mouseEnterClip;
    public AudioClip pu_MouseClickClip;

    public void PlayClip(AudioType func_num) {
        switch (func_num) {
            case AudioType.mouseEnter:PlayAudio(pu_mouseEnterClip);break;
            case AudioType.mouseClick:PlayAudio(pu_MouseClickClip);break;
        }
    }
}
