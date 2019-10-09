using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MovingSystem {
    private float pu_range = 90f;
    private float m_distanceMoved = 0f;
    private const float max_range = 120f;
    private float m_damage = 1f;

    private float m_startTime;
    private const float m_continueTime = 10f;

    private GameObject o_player;

    public void SetRange(float func_range) {
        pu_range = func_range;
    }

    public void SetDamage(float func_damage) {
        m_damage = func_damage;
    }

    protected override bool GetNextPos() {
        return true;
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

        m_startTime = Time.time;
    }

    protected override void SonUpdate() {
        if (Time.time > m_startTime + m_continueTime)
            Destroy(gameObject);

        m_distanceMoved += pu_speed * Time.deltaTime;
        if (pu_range <= m_distanceMoved) {
            Destroy(this.gameObject);
        }
    }

    private void timeChecker() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            other.transform.GetComponent<LifeSystem>().SufferDamage(m_damage);
            Destroy(gameObject);
        }
    }

    protected override void OtherCollisionReact() {

    }
}
