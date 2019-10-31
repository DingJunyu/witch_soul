using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem_ForEnemy_NoNeedForMove : MovingSystem_Enemy_Base {
    protected override bool GetNextPos() {
        return false;
    }

    protected override void SonInif() {

    }
}
