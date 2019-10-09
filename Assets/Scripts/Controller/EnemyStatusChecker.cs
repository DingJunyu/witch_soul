﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusChecker : StatusChecker {
    public float pu_startMovingAtX = 11f;
    public float pu_removeAtX = 30f;

    public float pu_detectiveDis = 10f;

    private float m_disToPlayer;
    private GameObject o_player;

    protected override void SonInif() {
        o_player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void StandardSonUpdate() {
        CheckDestroy();//距離が離れていくと消す
    }

    protected override void AlivingUpdate() {
        CheckStatus();
        CalDis();
    }

    private void CheckStatus() {
        if (m_disToPlayer < pu_detectiveDis) {
            if (m_combatSystem.CanIAttack()) {
                m_combatSystem.Engage();
                m_status = statusData.Engaging;
                return;
            }
        }

        CheckStartMoving();
        if (m_movingSystem.ReferRealMoving()) {
            m_status = statusData.Moving;
            return;
        }

        m_status = statusData.None;
    }

    private void CalDis() {
        m_disToPlayer = Vector3.Distance(transform.position, o_player.transform.position);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            m_status = statusData.Dieing;
            GetComponent<Collider>().enabled = false;
            GetComponent<MovingSystem_Enemy_Base>().StopMove();
            m_dieing = true;
        }
    }

    private void CheckStartMoving() {
        if (pu_startMovingAtX < o_player.transform.position.x) {
            GetComponent<MovingSystem_Enemy_Base>().StartMove();
        }
    }

    private void CheckDestroy() {
        if (pu_removeAtX < o_player.transform.position.x) {
            Destroy(gameObject);
        }
    }
}
