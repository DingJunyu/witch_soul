using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfriendlyWall : MonoBehaviour {
    public bool pu_removable = false;

    public float pu_damage;
    public float pu_damageInterval = 1f;
    private float m_lastDamageTime = 0f;
    private float m_deadTime = 0f;
    private float m_continueTime = 1f;

    
    void Start() {

    }

    
    void Update() {
        CheckDestroy();
    }

    void CheckDestroy() {
        if (!pu_removable || m_deadTime == 0f)
            return;

        if (m_deadTime + m_continueTime < Time.time) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        //敵と接触すると
        if (collision.transform.tag == "Enemy") {
            collision.transform.GetComponent<LifeSystem>().SufferDamage(999);
        }

        if (collision.transform.tag == "Player" &&
            m_lastDamageTime + pu_damageInterval < Time.time) {
            collision.transform.GetComponent<LifeSystem>().SufferDamage(pu_damage);
            m_lastDamageTime = Time.time;
        }

        if (pu_removable) {
            GetComponent<LifeSystem>().SufferDamage(999);
            m_deadTime = Time.time;
            GetComponent<Rigidbody>().detectCollisions = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (transform.tag == "Enemy") {
            other.GetComponent<StatusChecker>().SetStatus(StatusChecker.statusData.Dieing);
        }

        if (other.transform.tag == "Bullet") {
            Destroy(other.gameObject);
        }
    }
}
