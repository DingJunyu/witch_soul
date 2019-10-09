using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : StatusChecker {
    protected override void SonInif() {
        
    }

    protected override void AlivingUpdate() {
        if (m_movingSystem.ReferRealMoving()) {
                m_status = statusData.Moving;
            return;
        }

        m_status = statusData.None;
    }

    protected override void StandardSonUpdate() {
        
    }
}
