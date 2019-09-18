using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MovingSystem {
    private float m_range = 30f;
    private float m_distanceMoved = 0f;
    private const float max_range = 30f;
    private float m_damage = 1f;

    private GameObject o_player;

    public void SetRange(float func_range) {
        m_range = func_range;
    }

    public void SetDamage(float func_damage) {
        m_damage = func_damage;
    }

    protected override void GetNextPos() {
        m_distanceMoved += pu_speed * Time.deltaTime;
        if (m_range < m_distanceMoved) {
            Destroy(this.gameObject);
        }
    }

    protected override void SonInif() {
        o_player = GameObject.FindGameObjectWithTag("Player");
        //        m_nextPos.SetPoint(o_player.transform.position);

        float t_angle;

        t_angle = CalRadian(new Vector2(transform.position.x, transform.position.z),
              new Vector2(o_player.transform.position.x, o_player.transform.position.z));

        Vector2 t_tagetPos = new Vector2(transform.position.x -
            Mathf.Sin(t_angle) * max_range,
            transform.position.z -
            Mathf.Cos(t_angle) * max_range);

        m_nextPos.SetPoint(t_tagetPos);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            other.transform.GetComponent<LifeSystem>().SufferDamage(m_damage);
            Destroy(gameObject);
        }
    }
}
