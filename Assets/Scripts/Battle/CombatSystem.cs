using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSystem : MonoBehaviour {
    public float pu_AttackInterval = 2f;
    private float m_lastAttackedTime = 0f;

    public float pu_damage = 1f;
    public float pu_detectiveDis = 10f;

    public bool CanIAttack(float func_dis) {
        return pu_detectiveDis > func_dis;
    }

    private bool m_canIAttack = false;

    // Start is called before the first frame update
    void Start() {
        SonInif();
    }

    protected abstract void SonInif();

    // Update is called once per frame
    void Update() {
        CheckAndAttack();
    }

    protected void CheckAndAttack() {
        if (!m_canIAttack)
            return;

        if (Time.time < m_lastAttackedTime + pu_AttackInterval)
            return;

        SonCheckAndAttack();
        m_lastAttackedTime = Time.time;
    }

    protected abstract void SonCheckAndAttack();
}
