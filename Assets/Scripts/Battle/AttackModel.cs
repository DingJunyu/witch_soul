using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModel : MonoBehaviour {
    private float m_damage;

    public void SetDamage(float func_damage) {
        m_damage = func_damage;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") {
            return;
        }

        other.transform.GetComponent<LifeSystem>().SufferDamage(m_damage);
        Destroy(transform.gameObject);
    }
}
