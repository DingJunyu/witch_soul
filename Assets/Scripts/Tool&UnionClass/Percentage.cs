using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Percentage {
    private float m_percentage;

    private const float m_maxPercentage = 1f;
    private const float m_minPercentage = 0f;

    public Percentage() {
        m_percentage = 0;
    }

    public float Get() { return m_percentage; }

    public void Set(float func_now,float func_max, bool func_smallerThanOne = true) {
        m_percentage = func_now / func_max;

        if (func_smallerThanOne && m_percentage > 1.0f) {
            m_percentage = 1.0f;
        }
        if (m_percentage < 0f) {
            m_percentage = 0f;
        }
    }

    public void Set(float func_per, bool func_smallerThanOne = true) {
        m_percentage = func_per;
        if (func_smallerThanOne && m_percentage > 1.0f) {
            m_percentage = 1.0f;
        }
        if (m_percentage < 0f) {
            m_percentage = 0f;
        }
    }
}
