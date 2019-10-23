using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfriendlyWall : MonoBehaviour {
    public bool pu_removable = false;

    public float pu_damage;
    public float pu_damageInterval = 1f;
    private float m_lastDamageTime = 0f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Enemy") {
            collision.transform.GetComponent<LifeSystem>().SufferDamage(999);
        }
        if (collision.transform.tag == "Player" &&
            m_lastDamageTime + pu_damageInterval < Time.time) {
            collision.transform.GetComponent<LifeSystem>().SufferDamage(pu_damage);
            m_lastDamageTime = Time.time;
        }
        if (pu_removable)
            Destroy(gameObject);
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
