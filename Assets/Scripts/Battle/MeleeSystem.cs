using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour {
    public GameObject pu_attackModel;
    private GameObject m_realAttackModel = default;

    public float pu_damage;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (m_realAttackModel == null)
            Attack();
    }

    public void Attack() {
        m_realAttackModel = Instantiate(pu_attackModel, transform);
        m_realAttackModel.GetComponent<AttackModel>().SetDamage(pu_damage);
    }
}
