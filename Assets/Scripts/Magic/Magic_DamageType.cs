using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic_DamageType : Magic_Base {
    public float pu_damage = 1f;

    private float m_lastDamageTime = 0f;
    private const float mc_damageTimeInterval = 1f;

    protected override void TakeEffectStay(ref Collider func_other) {
        if (func_other.tag != "Enemy")
            return;
        if (m_lastDamageTime + mc_damageTimeInterval > Time.time)
            return;

        func_other.GetComponent<LifeSystem>().SufferDamage(pu_damage);
        OtherEffect(ref func_other);

        m_lastDamageTime = Time.time;

        if (pu_oneTime)
            Destroy(gameObject);
    }
    protected abstract void OtherEffect(ref Collider func_other);

    protected override void TakeEffectEnter(ref Collider func_other) {

    }

    protected override void UpdateBeforeUse() {

    }

    protected override abstract void SonInif();
    protected override abstract void MagicEffectUpdate();
    protected override abstract void UseMagic_Son();
}
