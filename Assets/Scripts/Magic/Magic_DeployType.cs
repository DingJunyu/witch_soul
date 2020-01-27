using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic_DeployType : Magic_Base {



    protected override abstract void TakeEffectStay(ref Collider func_other);

    protected abstract void OtherEffect(ref Collider func_other);

    protected override abstract void TakeEffectEnter(ref Collider func_other);

    protected override abstract void UpdateBeforeUse();

    protected override abstract void SonInif();
    protected override abstract void MagicEffectUpdate();
    protected override abstract void UseMagic_Son();
}
