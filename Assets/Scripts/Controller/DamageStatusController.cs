using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageStatusController : MonoBehaviour {
    LifeSystem m_lifeSystem;
    Color m_thisColor;
    float m_percentage;
    const float mc_line = 2f / 3f;

    // Start is called before the first frame update
    void Start() {
        m_lifeSystem = GameObject.Find("Player").GetComponent<LifeSystem>();
        m_thisColor = GetComponent<Image>().material.color;
    }

    // Update is called once per frame
    void Update() {
        CalPercentage();
        m_thisColor.a = m_percentage;

        this.GetComponent<Image>().color = m_thisColor;
    }

    void CalPercentage() {
        if (m_lifeSystem.ReferHp() > m_lifeSystem.pu_maxHitPoint * mc_line)
            m_percentage = 0;
        else
            m_percentage = 1 - m_lifeSystem.ReferHp() / m_lifeSystem.pu_maxHitPoint;
    }
}
