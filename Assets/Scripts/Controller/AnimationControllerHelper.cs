using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerHelper : MonoBehaviour {
    StatusChecker m_statusChecker;
    private Animator m_animationController;


    private void Start() {
        m_statusChecker = gameObject.GetComponentInParent<StatusChecker>();

        m_animationController = GetComponent<Animator>();
    }

    public void SetStatus(StatusChecker.statusData func_status) {
        m_statusChecker.SetStatus(func_status);
    }

    [HideInInspector]
    public void SetAnimation(StatusChecker.statusData func_status) {
        m_animationController.SetInteger("status", (int)func_status);
    }

    public void StopPlay() {
        m_animationController.enabled = false;
    }
}
