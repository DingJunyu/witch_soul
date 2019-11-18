using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour {
    private float m_hitPoint;
    public float ReferHp() { return m_hitPoint; }
    [Range(1,30)]public float pu_maxHitPoint;
    public bool pu_shouldBeRemove = true;

    //エフェクトprefab
    public GameObject pu_recoveryEffect;
    public GameObject pu_damageEffect;

    
    void Start() {
        Inif();//初期化
    }

    
    void Update() {

    }

    private void Inif() {
        m_hitPoint = pu_maxHitPoint;
    }

    public bool ReferAlive() {
        return m_hitPoint > 0;
    }

    public void SufferDamage(float func_damage) {
        if (m_hitPoint < 0)
            return;

        Instantiate(pu_damageEffect, transform);
        m_hitPoint -= func_damage;

    }

    public void SufferHeal(float func_heal) {
        Instantiate(pu_recoveryEffect, transform);
        m_hitPoint += func_heal;
        if (m_hitPoint > pu_maxHitPoint)
            m_hitPoint = pu_maxHitPoint;
    }
}
