﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLifeController : MonoBehaviour {
    public float pu_continueTime = 1f;
    private float m_startTime;

    
    void Start() {
        m_startTime = Time.time;
    }

    
    void Update() {
        CheckLifeTime();
    }

    void CheckLifeTime() {
        if (m_startTime + pu_continueTime > Time.time)
            return;

        Destroy(gameObject);
    }
}
