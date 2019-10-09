using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour {
    private float m_hitPoint;
    public float ReferHp() { return m_hitPoint; }
    [Range(1,30)]public float pu_maxHitPoint;
    public bool pu_shouldBeRemove = true;

    // Start is called before the first frame update
    void Start() {
        Inif();//初期化
    }

    // Update is called once per frame
    void Update() {

    }

    private void Inif() {
        m_hitPoint = pu_maxHitPoint;
    }

    public bool ReferAlive() {
        return m_hitPoint > 0;
    }

    public void SufferDamage(float func_damage) {
        m_hitPoint -= func_damage;
        if (m_hitPoint < 0)
            m_hitPoint = 0;
    }

    public void SufferHeal(float func_heal) {
        m_hitPoint += func_heal;
        if (m_hitPoint > pu_maxHitPoint)
            m_hitPoint = pu_maxHitPoint;
    }
}
