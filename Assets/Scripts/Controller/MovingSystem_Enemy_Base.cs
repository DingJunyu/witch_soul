using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingSystem_Enemy_Base : MovingSystem {
    protected bool m_startMoving = false;
    protected bool m_moved = false;

    protected override abstract void GetNextPos();
    protected override abstract void SonInif();

    protected override void SonUpdate() {
        
    }

    public void StartMove() {
        m_startMoving = true;
    }
}
