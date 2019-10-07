using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusChecker : MonoBehaviour {
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

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (m_status != enemyStatus.Dead) {
            AlivingUpdate();
        }
    }



    private void AlivingUpdate() {
        CheckStatus();
        CalDis();
    }

    private void CheckStatus() {
        if (m_movingSystem.ReferMoving())
            m_status = enemyStatus.Moving;
    }

    private void CalDis() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player")
            Destroy(collision.gameObject);  
    }
}
