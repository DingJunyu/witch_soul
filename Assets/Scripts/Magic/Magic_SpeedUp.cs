using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_SpeedUp : Magic_HealAndBuff {
    public float pu_speed = 2f;
    public float pu_speedUpContinueTime = 5f;

    protected override void EffectHere() {
        o_player.GetComponent<MovingSystem>().SetSpeedUp(pu_speed, pu_speedUpContinueTime);
    }

    protected override void SonInif() {

    }
}
