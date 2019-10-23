using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Explosion : Magic_DamageType {
    public float pu_exploRate = 0.1f;
    private float m_baseExploRate = 1f;
    private float m_maxScale = 5.0f;
    private Vector3 m_scale;

    protected override void OtherEffect(ref Collider func_other) {

    }

    protected override void SonInif() {
        m_scale = new Vector3(1f, 1f, 1f);
    }

    protected override void MagicEffectUpdate() {
        if (m_scale.x > m_maxScale)
            return;

        m_scale *= m_baseExploRate + 
            (pu_exploRate * Time.fixedDeltaTime);
        

        transform.localScale = m_scale;
    }

    protected override void UseMagic_Son() {
        
    }
}
