using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerHelper : MonoBehaviour {
    EnemyStatusChecker m_enemyStatusChecker;
    private Animator m_animationController;


    private void Start() {
        m_enemyStatusChecker = gameObject.GetComponentInParent<EnemyStatusChecker>();

        m_animationController = GetComponentInChildren<Animator>();
    }

    public void SetStatus(EnemyStatusChecker.enemyStatus func_enemyStatus) {
        m_enemyStatusChecker.SetStatus(func_enemyStatus);
    }

    public void SetAnimation(EnemyStatusChecker.enemyStatus func_enemyStatus) {
        m_animationController.SetInteger("status", (int)func_enemyStatus);
    }
}
