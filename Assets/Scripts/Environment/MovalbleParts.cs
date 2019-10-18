﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public enum list_Direct {
    none,
    upWard,
    downWard,
    rightWard,
    leftWard
}

public class MovalbleParts : MonoBehaviour {
    public float pu_movingSpeed;
    public float pu_movingDistance;

    public float pu_startMoveAtX;
    private const float mc_endMoveAtX = 25f;

    private float m_disToPlayer;

    private void CalDis() {
        m_disToPlayer = Vector3.Distance(transform.position, o_player.transform.position);
    }

    public bool pu_redo = true;

    public list_Direct pu_direct = list_Direct.none;
    private int m_direct;//上0,下1,右2,左3

    private Vector3 m_startPos;
    private Vector3 m_targetPos;
    private bool m_back = false;
    private GameObject o_player;

    // Start is called before the first frame update
    void Start() {
        CalTargetPos();

        o_player = GameObject.Find("Player");
    }

    private void CalTargetPos() {
        m_startPos = new Vector3(transform.position.x,transform.position.y,
            transform.position.z);
        m_targetPos = new Vector3(transform.position.x, transform.position.y,
            transform.position.z);
        m_direct = (int)pu_direct;

        switch (m_direct) {
            case (int)list_Direct.upWard:m_targetPos.z -= pu_movingDistance;break;
            case (int)list_Direct.downWard:m_targetPos.z += pu_movingDistance;break;
            case (int)list_Direct.rightWard:m_targetPos.x += pu_movingDistance;break;
            case (int)list_Direct.leftWard:m_targetPos.x -= pu_movingDistance;break;
        }
    }

    // Update is called once per frame
    void Update() {
        if (o_player.transform.position.x < pu_startMoveAtX)
            return;

        Moving();
        Check(); 
    }

    private void Moving() {
        if (m_back && !pu_redo)
            return;

        if (!m_back)
            transform.position = Vector3.MoveTowards(transform.position,
              m_targetPos, pu_movingSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position,
              m_startPos, pu_movingSpeed * Time.deltaTime);
    }

    private void Check() {
        CalDis();

        if (transform.position == m_targetPos)
            m_back = true;
        if (transform.position == m_startPos)
            m_back = false;

        if (m_disToPlayer > mc_endMoveAtX
            && o_player.transform.position.x > transform.position.x) {
            Destroy(gameObject);
        }
    }


}
