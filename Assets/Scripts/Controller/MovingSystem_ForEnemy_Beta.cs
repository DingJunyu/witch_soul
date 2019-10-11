﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//放物線を利用する移動システム
public class MovingSystem_ForEnemy_Beta : MovingSystem_Enemy_Base {
    protected float m_movingTime;

    protected const int mc_pointAmount = 30;
    protected float m_distance = 0f;

    
    private Vector3 m_midPos;
    private Vector3 m_endPos;

    [Space]
    public GameObject pu_midPosGO;
    public GameObject pu_endPosGO;

    protected bool m_startStatusChanged = false;

    protected Vector3 m_startPos;
    protected float m_startTime = 0f;
    protected float m_maxTime = 0f;
    protected Percentage m_percentage;

    protected override bool GetNextPos() {
        if (m_moved)
            return false;

        if (!m_startMoving)
            return false;

        if (m_startMoving && !m_startStatusChanged) {
            m_startTime = Time.time;
            m_maxTime = m_startTime + m_movingTime;
            m_startStatusChanged = true;
        }

        m_percentage.Set(Time.time - m_startTime, 
            m_maxTime - m_startTime);
        m_nextPos.SetPoint(Bezier(m_percentage.Get()));
        if (Time.time > m_maxTime) {
            m_startMoving = false;
            m_moved = true;
        }

        return true;
    }

    protected override void SonInif() {
        m_percentage = new Percentage();
        m_startPos = transform.position;

        m_midPos = pu_midPosGO.transform.position;
        m_endPos = pu_endPosGO.transform.position;

        CalLength();
        Caltime();
    }

    //次のポイントを計算する関数
    private Vector3 Bezier(float func_percentage) {
        Vector3 p0p1 = (1 - func_percentage) * m_startPos +
            func_percentage * m_midPos;
        Vector3 p1p2 = (1 - func_percentage) * m_midPos +
            func_percentage * m_endPos; ;
        Vector3 result = (1 - func_percentage) * p0p1 +
            func_percentage * p1p2;

        return result;
    }

    private void CalLength() {
        Vector3 t_oldPos;
        Vector3 t_nextPos;

        t_oldPos = transform.position;

        for (int i = 1; i <= mc_pointAmount; i++) {
            t_nextPos = Bezier(i / mc_pointAmount);
            m_distance += Vector3.Distance(t_oldPos, t_nextPos);
            t_oldPos = t_nextPos;
        }
    }

    private void Caltime() {
        m_movingTime = m_distance / pu_speed;
    }
}
