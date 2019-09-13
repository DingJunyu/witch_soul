﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトの移動を実現するクラス
public abstract class MovingSystem : MonoBehaviour {
    public float pu_speed = 5f;

    private const float m_rotateSpeed = 0.5f;

    protected Coord m_nextPos;
    public bool m_moving;
    private Quaternion m_targetRotation;

    private Camera test_mainCamera;

    protected abstract void GetNextPos();

    // Start is called before the first frame update
    void Start() {
        Inif();
        SonInif();
    }

    private void Inif() {
        m_nextPos = new Coord();
        m_targetRotation = new Quaternion();

        test_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_nextPos.SetPoint(transform.position);
    }

    protected abstract void SonInif();

    // Update is called once per frame
    void Update() {
        if (!m_moving)
            GetNextPos();
        PosCheck();
        Move();
    }

    private void PosCheck() {
        if (m_nextPos.CalDis(transform.position)
            == 0) {
            //ウェイポイントに着かなければ移動を継続する
            m_moving = false;
        }
        else
            m_moving = true;
    }

    private void Move() {
        if (!m_moving)
            return;

        ////ターゲットに移動する
        transform.position = Vector3.MoveTowards(transform.position,
              m_nextPos.ReferVector3(transform.position.y), pu_speed * Time.deltaTime);

        //角度を設定して回る
        Vector3 t_vector3 = m_nextPos.ReferVector3(transform.position.y) -
            transform.position;
        m_targetRotation = Quaternion.LookRotation(t_vector3);

        transform.rotation = Quaternion.Slerp(transform.rotation,
            m_targetRotation, m_rotateSpeed);

        if (m_nextPos.CalDis(transform.position) < .1f) {
            transform.position = m_nextPos.ReferVector3(transform.position.y);
        }
    }

    protected void Test_ShowPos() {
        Debug.Log(m_nextPos.x + "," + m_nextPos.z);
    }
}
