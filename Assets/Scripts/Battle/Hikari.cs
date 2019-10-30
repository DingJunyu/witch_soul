﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hikari : MonoBehaviour {
    GameObject o_player;

    [Range(0f,1.75f)]public float pu_speed = 0.5f;
    public float pu_damage = 1.0f;
    public float pu_damageInterval = 1.0f;
    private float m_lastDamageTime = 0f;

    private Vector3 m_thisPos;

    // Start is called before the first frame update
    void Start() {
        o_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        MoveAndUpdateDeadLine();
//        CheckPlayerPos();
    }

    //モデル・画像を移動する
    private void MoveAndUpdateDeadLine() {
        m_thisPos = transform.position;
        m_thisPos.x += pu_speed * Time.deltaTime;

        transform.position = m_thisPos;
    }

    private void OnTriggerStay(Collider other) {
        if (other.transform.tag != "Player")
            return;

        if (m_lastDamageTime + pu_damageInterval < Time.time) {
            other.transform.GetComponent<LifeSystem>().SufferDamage(pu_damage);
            m_lastDamageTime = Time.time;
        }
    }
}
