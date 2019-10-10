﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDeployer : MonoBehaviour {
    private GameObject m_magic_readToBeDeploy;
    private GameObject o_player;

    private bool m_deployerEnable = false;
    public bool ReferDeployerEnable() { return m_deployerEnable; }

    public bool SetMagic(GameObject func_magic_readToBeDeploy) {
        if (m_magic_readToBeDeploy != default)//すでにスキルを持っています
            return false;

        m_magic_readToBeDeploy = Instantiate(func_magic_readToBeDeploy, transform);

        if (!o_player.GetComponent<MagicSystem>().
            CanIUseThis(m_magic_readToBeDeploy.GetComponent<Magic_Base>().ReferMC())) {
            Destroy(m_magic_readToBeDeploy);
            return false;
        }

        m_deployerEnable = true;
        return true;
    }

    // Start is called before the first frame update
    void Start() {
        Inif();
    }

    void Inif() {
        o_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        CheckDeployStatus();
    }

    private void CheckDeployStatus() {
        if (!m_deployerEnable)
            return;

        if (Input.GetMouseButtonDown(0)) {
            m_magic_readToBeDeploy.GetComponent<Magic_Base>().UseThis();
            o_player.GetComponent<MagicSystem>().
                UseMagic(m_magic_readToBeDeploy.GetComponent<Magic_Base>().ReferMC());
            m_deployerEnable = false;

            m_magic_readToBeDeploy = default;
        }

        if (Input.GetMouseButtonDown(1)) {
            Destroy(m_magic_readToBeDeploy);

            m_deployerEnable = false;
        }
    }
}
