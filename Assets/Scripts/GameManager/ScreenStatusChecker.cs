using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//このクラスはスクリーンのステータスを変更するものではありません。
public class ScreenStatusChecker : ButtonStatusChecker {
    public override void CheckStatus() {
        if (Screen.fullScreen)
            SetOn();
        else
            SetOff();
    }
}
