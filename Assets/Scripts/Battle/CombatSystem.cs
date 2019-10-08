using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSystem : MonoBehaviour {
    public float pu_AttackInterval = 2f;
    private float m_lastAttackedTime = 0f;

    public float pu_damage = 1f;

    public void Engage() {
        m_canIAttack = true;
    }

    public void CeaseFire() {
        m_canIAttack = false;
    }

    public bool CanIAttack() { return Time.time < m_lastAttackedTime + pu_AttackInterval; }

    private bool m_canIAttack = false;

    // Start is called before the first frame update
    void Start() {
        SonInif();
    }

    protected abstract void SonInif();

    // Update is called once per frame
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
