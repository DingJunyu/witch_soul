using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : CombatSystem {
    public GameObject pu_attackModel;
    private GameObject m_realAttackModel = default;

    protected override void SonInif() {
        
    }

    protected override void SonCheckAndAttack() {
        if (m_realAttackModel == null)
            Attack();
    }

    public void Attack() {
        m_realAttackModel = Instantiate(pu_attackModel, transform);
        m_realAttackModel.GetComponent<AttackModel>().SetDamage(pu_damage);
    }
}
