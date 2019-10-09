using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//直線で移動する
public class MovingSystem_ForEnemy_Alpha : MovingSystem_Enemy_Base {
    public List<Vector2> pu_movingPoint;
    private int m_mark = 0;//統計用マーク

    protected override bool GetNextPos() {
        if (!m_startMoving)
            return false;

        if (m_mark < pu_movingPoint.Count) {
            m_nextPos.SetPoint(pu_movingPoint[m_mark]);
            m_mark++;
        }
        return true;
    }

    protected override void SonInif() {
        
    }
}
