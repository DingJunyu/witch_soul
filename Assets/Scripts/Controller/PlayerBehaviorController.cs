using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorController : MonoBehaviour {
    BarController m_hpController;
    BarController m_mpController;

    LifeSystem m_lifeSystem;
    MagicSystem m_magicSystem;

    
    void Start() {
        Inif();
    }

    void Inif() {
        m_hpController = GameObject.Find("HitPointBar").transform.Find("HpFill").
            GetComponent<BarController>();
        m_mpController = GameObject.Find("MagicPointBar").transform.Find("HpFill").
           GetComponent<BarController>();

        m_lifeSystem = GetComponent<LifeSystem>();
        m_magicSystem = GetComponent<MagicSystem>();
    }

    
    void Update() {
        CheckHpStatus();
        CheckMagicStatus();
    }

    void CheckHpStatus() {
        m_hpController.SetPercentage(m_lifeSystem.ReferHp(), m_lifeSystem.pu_maxHitPoint);
    }

    void CheckMagicStatus() {
        m_mpController.SetPercentage(m_magicSystem.ReferMagicPoint(),
            m_magicSystem.pu_maxMagicPoint);
    }
}
