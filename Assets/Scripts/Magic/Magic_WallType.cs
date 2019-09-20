using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic_WallType : Magic_Base {
    protected override void TakeEffectStay(ref Collider func_other) {

    }

    protected override void TakeEffectEnter(ref Collider func_other) {
        if (func_other.tag != "Enemy" &&
            func_other.tag != "Bullet")
            return;

        OtherEffect(ref func_other);
    }
    protected abstract void OtherEffect(ref Collider func_other);

    protected override abstract void SonInif();
    protected override abstract void MagicEffectUpdate();
    protected override abstract void UseMagic_Son();
}
