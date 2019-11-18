using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSystem : MonoBehaviour {
    public float pu_AttackInterval = 3f;
    private const float mc_attackDelay = 1f;
    private float m_attackTime = 0f;
    private float m_lastAttackedTime = 0f;

    public float pu_damage = 1f;

    public void Engage() {
        m_canIAttack = true;
        m_attackTime = Time.time;
    }

    public void CeaseFire() {
        m_canIAttack = false;
    }

    public bool CanIAttack() { return Time.time > m_lastAttackedTime + pu_AttackInterval; }

    private bool m_canIAttack = false;

    
    void Start() {
        SonInif();
    }

    protected abstract void SonInif();

    
    void Update() {
        Attack();
    }

    protected void Attack() {
        if (!m_canIAttack)
            return;

        SonCheckAndAttack();
        m_lastAttackedTime = Time.time;

        m_canIAttack = false;
    }

    protected abstract void SonCheckAndAttack();
}
