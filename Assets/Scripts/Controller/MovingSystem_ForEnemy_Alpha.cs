using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//直線で移動する
public class MovingSystem_ForEnemy_Alpha : MovingSystem_Enemy_Base {
    private Vector3[] m_movingPoint;
    public List<GameObject> pu_pos;
    private int m_mark = 0;//統計用マーク
    private int m_count;

    protected override bool GetNextPos() {
        if (!m_startMoving)
            return false;

        if (m_mark < m_count) {
            m_nextPos.SetPoint(m_movingPoint[m_mark]);
            m_mark++;
        }
        return true;
    }

    protected override void SonInif() {
        m_count = pu_pos.Count;

        m_movingPoint = new Vector3[m_count];

        for (int i = 0; i < m_count; i++) {
            m_movingPoint[i] = pu_pos[i].transform.position;
        }
    }
}
