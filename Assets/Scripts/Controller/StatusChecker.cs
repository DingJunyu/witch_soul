using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusChecker : MonoBehaviour {
    public enum statusData {
        None,
        Moving,
        Engaging,
        Dieing,
        Dead
    }

    public bool pu_removable = true;

    protected statusData m_status;

    public void SetStatus(statusData func_enemyStatus) { m_status = func_enemyStatus; }
    public void ResetStatus() { m_status = statusData.None; }

    protected bool m_dieing = false;

    protected AnimationControllerHelper m_animationController;
    protected MovingSystem m_movingSystem;
    protected CombatSystem m_combatSystem;
    protected LifeSystem m_lifeSystem;

    
    void Start() {
        StandardInif();
        SonInif();
    }

    private void StandardInif() {
        m_movingSystem = GetComponent<MovingSystem>();
        m_combatSystem = GetComponent<CombatSystem>();
        m_lifeSystem = GetComponent<LifeSystem>();

        m_animationController = GetComponentInChildren<AnimationControllerHelper>();
    }

    protected abstract void SonInif();

    
    void Update() {
        if (!m_dieing) {
            AlivingUpdate();
        }
        StandardSonUpdate();
        CheckEnd();

        AnimationUpdate();
    }

    protected abstract void AlivingUpdate();
    protected abstract void StandardSonUpdate();

    private void AnimationUpdate() {
        m_animationController.SetAnimation(m_status);
    }

    public void KillMe() {
        m_dieing = true;
    }

    private void CheckEnd() {
        if (!m_lifeSystem.ReferAlive())
            KillMe();

        if (!m_dieing)
            return;

        if (m_status == statusData.Dead) {
            if (pu_removable)
                Destroy(transform.gameObject);
            else
                m_animationController.StopPlay();
            return;
        }

        m_status = statusData.Dieing;
        GetComponent<MovingSystem>().SetEnd();
    }
}
