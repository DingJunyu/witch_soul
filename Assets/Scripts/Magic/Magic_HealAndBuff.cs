using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic_HealAndBuff : Magic_Base {
    protected override void MagicEffectUpdate() {
        EffectHere();
    }

    protected override void UpdateBeforeUse() {
        GameObject.Find("MagicDeployer").GetComponent<MagicDeployer>().UseMagicHere();
    }

    protected abstract void EffectHere();

    protected abstract override void SonInif();

    protected override void TakeEffectEnter(ref Collider func_other) { }

    protected override void TakeEffectStay(ref Collider func_other) { }

    protected override void UseMagic_Son() {
        
    }
}
