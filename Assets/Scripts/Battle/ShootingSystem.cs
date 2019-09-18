using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {
    public GameObject pu_bullet;
    private GameObject m_bullet;

    public float pu_range = 10f;
    public float pu_shootInterval = 2f;
    public float pu_damage = 1f;

    private float m_lastShootedTime = 0f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        CheckAndShoot();
    }

    private void CheckAndShoot() {
        if (Time.fixedTime < m_lastShootedTime + pu_shootInterval)
            return;

        m_bullet = Instantiate(pu_bullet, transform.position,
            transform.rotation);
        m_bullet.GetComponent<Bullet>().SetDamage(pu_damage);
        m_bullet.GetComponent<Bullet>().SetRange(pu_range);
        m_lastShootedTime = Time.fixedTime;
    }
}
