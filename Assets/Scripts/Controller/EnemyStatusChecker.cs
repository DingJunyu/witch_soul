using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusChecker : MonoBehaviour {
    public float pu_startMovingAtX = 11f;
    public float pu_removeAtX = 30f;

    enum enemyStatus {
        Moving,
        Engaging,
        Dieing,
        Dead
    }

    enemyStatus m_status;

    private float m_disToPlayer;
    private GameObject o_player;

    private Animation m_animationController;
    private MovingSystem m_movingSystem;
    private CombatSystem m_combatSystem;

    // Start is called before the first frame update
    void Start() {
        Inif();
    }

    private void Inif() {
        o_player = GameObject.FindGameObjectWithTag("Player");
        m_movingSystem = GetComponent<MovingSystem>();
    }

    // Update is called once per frame
    void Update() {
        if (m_status != enemyStatus.Dead) {
            AlivingUpdate();
        }
        CheckDestroy();
    }



    private void AlivingUpdate() {
        CheckStatus();
        CalDis();
    }

    private void CheckStatus() {
        CheckStartMoving();
        if (m_movingSystem.ReferMoving())
            m_status = enemyStatus.Moving;
        
    }

    private void CalDis() {
        m_disToPlayer = Vector3.Distance(transform.position, o_player.transform.position);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player")
            Destroy(transform.gameObject);  
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
