using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Heal : Magic_HealAndBuff {
    public float pu_healData = 2;

    protected override void EffectHere() {
        o_player.GetComponent<LifeSystem>().SufferHeal(pu_healData);
    }

    protected override void SonInif() {

    }
}
