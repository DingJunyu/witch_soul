using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingSystem_Enemy_Base : MovingSystem {
    protected bool m_startMoving = false;
    protected bool m_moved = false;

    [Space]
    [Header("プレーヤーはここに着いたら移動を開始する")]
    public float pu_startMovingAtX;

    protected override abstract bool GetNextPos();
    protected override abstract void SonInif();
    protected override void OtherCollisionReact() {
        
    }

    protected override void SonUpdate() {
        
    }

    public void StartMove() {
        m_startMoving = true;
    }

    public void StopMove() {
        m_startMoving = false;
    }
}
