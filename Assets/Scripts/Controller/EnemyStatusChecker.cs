using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusChecker : MonoBehaviour {
    public float pu_startMovingAtX = 11f;
    public float pu_removeAtX = 30f;

    public float pu_detectiveDis = 10f;

    public enum enemyStatus {
        None,
        Moving,
        Engaging,
        Dieing,
        Dead
    }

    public enemyStatus m_status;

    private bool m_dieing = false;

    private float m_disToPlayer;
    private GameObject o_player;

    private AnimationControllerHelper m_animationController;
    private MovingSystem_Enemy_Base m_movingSystem;
    private CombatSystem m_combatSystem;
    private LifeSystem m_lifeSystem;

    // Start is called before the first frame update
    void Start() {
        Inif();
    }

    private void Inif() {
        o_player = GameObject.FindGameObjectWithTag("Player");
        m_movingSystem = GetComponent<MovingSystem_Enemy_Base>();
        m_combatSystem = GetComponent<CombatSystem>();
        m_lifeSystem = GetComponent<LifeSystem>();
            
        m_animationController = GetComponentInChildren<AnimationControllerHelper>();
    }

    // Update is called once per frame
    void Update() {
        if (!m_dieing) {
            AlivingUpdate();
        }
        CheckDestroy();//距離が離れていくと消す

        CheckEnd();
        AnimationUpdate();
    }



    private void AlivingUpdate() {
        CheckStatus();
        CalDis();
    }

    private void CheckStatus() {
        if (m_disToPlayer < pu_detectiveDis) {
            if (m_combatSystem.CanIAttack()) {
                m_combatSystem.Engage();
                m_status = enemyStatus.Engaging;
                return;
            }
        }

        CheckStartMoving();
        if (m_movingSystem.ReferRealMoving()) {
            m_status = enemyStatus.Moving;
            return;
        }

        m_status = enemyStatus.None;
    }

    public void KillMe() {
        m_dieing = true;
    }

    private void CheckEnd() {
        if (!m_lifeSystem.ReferAlive())
            KillMe();

        if (!m_dieing)
            return;

        if (m_status == enemyStatus.Dead)
            Destroy(transform.gameObject);

        m_status = enemyStatus.Dieing;
    }

    private void AnimationUpdate() {
        m_animationController.SetAnimation(m_status);
    }

    public void SetStatus(enemyStatus func_enemyStatus) { m_status = func_enemyStatus; }
    public void ResetStatus() { m_status = enemyStatus.None; }

    private void CalDis() {
        m_disToPlayer = Vector3.Distance(transform.position, o_player.transform.position);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            m_status = enemyStatus.Dieing;
            GetComponent<Collider>().enabled = false;
            m_movingSystem.StopMove();
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
