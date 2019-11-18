using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSystem : MonoBehaviour {
    public float pu_maxMagicPoint = 10;
    public float ReferMagicPoint() { return m_magicPoint; }
    private float m_magicPoint;

    public float pu_recoveryPerGap = 2f;
    private const float mc_gap = 3f;
    private float m_lastRecoveryTime = 0f;

    public void UseMagic(float func_magicConsumption) {
        m_magicPoint -= func_magicConsumption;
    }

    public bool CanIUseThis(float func_magicConsumption) {
        return m_magicPoint > func_magicConsumption;
    }

    
    void Start() {
        Inif();
    }

    void Inif() {
        m_magicPoint = pu_maxMagicPoint;
        m_lastRecoveryTime = Time.time;
    }

    
    void Update() {
        RecoverPerGap();
    }

    void RecoverPerGap() {
        if (m_lastRecoveryTime + mc_gap > Time.time)
            return;

        m_magicPoint += pu_recoveryPerGap;
        if (m_magicPoint > pu_maxMagicPoint)
            m_magicPoint = pu_maxMagicPoint;

        m_lastRecoveryTime = Time.time;
    }
}
