using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : CombatSystem {
    public GameObject pu_bullet;
    private GameObject m_bullet;

    private GameObject o_bullets;

    public float pu_range = 10f;

    protected override void SonInif() {
        o_bullets = GameObject.Find("Bullets");
    }

    protected override void SonCheckAndAttack() {
        m_bullet = Instantiate(pu_bullet, transform.position,
           transform.rotation);
        m_bullet.GetComponent<Bullet>().SetDamage(pu_damage);
        m_bullet.GetComponent<Bullet>().SetRange(pu_range);
        m_bullet.transform.parent = o_bullets.transform;
    }
}
