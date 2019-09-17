using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingSystem_ForEnemy_Beta : MovingSystem {
    public float pu_movingTime = 5f;
    private float mc_minMovingTime = 5f;
    
    public Vector3 pu_midPos;
    public Vector3 pu_endPos;
    public float pu_startMovingAtX;

    private Vector3 m_startPos;
    public bool m_startMoving = false;
    public bool m_moved = false;
    private float m_startTime = 0f  ;
    private float m_maxTime = 0f;
    private Percentage m_percentage;

    private GameObject o_player;

    public void StartMove() {
        m_startMoving = true;
        m_startTime = Time.deltaTime;
        m_maxTime = m_startTime + pu_movingTime;
    }

    protected override void GetNextPos() {
        if (m_moved)
            return;

        CheckPlayerPos();

        if (!m_startMoving)
            return;

        m_percentage.Set(Time.deltaTime - m_startTime, 
            m_maxTime - m_startTime);
        m_nextPos.SetPoint(Bezier());
        if (Time.fixedTime > m_maxTime) {
            m_startMoving = false;
            m_moved = true;
        }
    }

    private void CheckPlayerPos() {
        if (m_startMoving)
            return;
        if (pu_startMovingAtX == 0)
            return;

        if (o_player.transform.position.x > pu_startMovingAtX) {
            m_startMoving = true;
            m_startTime = Time.deltaTime;
            m_maxTime = m_startTime + pu_movingTime;
        }
    }

    protected override void SonInif() {
        m_percentage = new Percentage();
        o_player = GameObject.FindGameObjectWithTag("Player");
        m_startPos = transform.position;

        if (pu_movingTime < mc_minMovingTime)
            pu_movingTime = mc_minMovingTime;
    }

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
