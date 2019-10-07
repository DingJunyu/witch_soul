using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//放物線を利用する移動システム
public class MovingSystem_ForEnemy_Beta : MovingSystem_Enemy_Base {
    public float pu_movingTime = 5f;
    private float mc_minMovingTime = 5f;
    
    public Vector3 pu_midPos;
    public Vector3 pu_endPos;

    private bool m_startStatusChanged = false;

    private Vector3 m_startPos;
    protected float m_startTime = 0f;
    protected float m_maxTime = 0f;
    private Percentage m_percentage;

    private GameObject o_player;

    protected override void GetNextPos() {
        if (m_moved)
            return;

        if (!m_startMoving)
            return;

        if (m_startMoving && !m_startStatusChanged) {
            m_startTime = Time.time;
            m_maxTime = m_startTime + pu_movingTime;
            m_startStatusChanged = true;
        }

        m_percentage.Set(Time.time - m_startTime, 
            m_maxTime - m_startTime);
        m_nextPos.SetPoint(Bezier());
        if (Time.time > m_maxTime) {
            m_startMoving = false;
            m_moved = true;
        }
    }

    protected override void SonInif() {
        m_percentage = new Percentage();
        o_player = GameObject.FindGameObjectWithTag("Player");
        m_startPos = transform.position;

        if (pu_movingTime < mc_minMovingTime)
            pu_movingTime = mc_minMovingTime;
    }

    //次のポイントを計算する関数
    private Vector3 Bezier() {
        Vector3 p0p1 = (1 - m_percentage.Get()) * m_startPos + 
            m_percentage.Get() * pu_midPos;
        Vector3 p1p2 = (1 - m_percentage.Get()) * pu_midPos +
            m_percentage.Get() * pu_endPos; ;
        Vector3 result = (1 - m_percentage.Get()) * p0p1 + 
            m_percentage.Get() * p1p2;

        return result;
    }
}
