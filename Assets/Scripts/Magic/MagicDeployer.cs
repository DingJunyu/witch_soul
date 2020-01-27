using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDeployer : MonoBehaviour {
    private GameObject m_magic_readToBeDeploy;
    private GameObject o_player;

    private const float mc_magicDelay = 0.01f;
    private float m_inifTime = 0f;

    private bool m_deployerEnable = false;
    public bool ReferDeployerEnable() { return m_deployerEnable; }

    public bool SetMagic(GameObject func_magic_readToBeDeploy) {
        if (m_magic_readToBeDeploy != default) {//すでにスキルを持っています
            CancelDeploy();
            return false;
        }
        m_magic_readToBeDeploy = Instantiate(func_magic_readToBeDeploy, transform);

        if (!o_player.GetComponent<MagicSystem>().
            CanIUseThis(m_magic_readToBeDeploy.GetComponent<Magic_Base>().ReferMC())) {
            Destroy(m_magic_readToBeDeploy);
            return false;
        }

        m_inifTime = Time.time;
        m_deployerEnable = true;
        return true;
    }

    
    void Start() {
        Inif();
    }

    void Inif() {
        o_player = GameObject.Find("Player");
    }

    
    void Update() {
        CheckDeployStatus();
    }

    private void CheckDeployStatus() {
        if (!m_deployerEnable || Time.time < m_inifTime + mc_magicDelay)
            return;

        //魔法を使う
        if (Input.GetMouseButtonDown(0)) {
            m_magic_readToBeDeploy.GetComponent<Magic_Base>().UseThis();
            o_player.GetComponent<MagicSystem>().
                UseMagic(m_magic_readToBeDeploy.GetComponent<Magic_Base>().ReferMC());
            m_deployerEnable = false;

            m_magic_readToBeDeploy = default;
            m_inifTime = 0f;
        }

        if (Input.GetMouseButtonDown(1)) {
            Destroy(m_magic_readToBeDeploy);

            m_deployerEnable = false;
            m_inifTime = 0f;
        }
    }

    public void UseMagicHere() {
        if (!m_deployerEnable)
            return;

        m_magic_readToBeDeploy.GetComponent<Magic_Base>().UseThis();
        o_player.GetComponent<MagicSystem>().
            UseMagic(m_magic_readToBeDeploy.GetComponent<Magic_Base>().ReferMC());
        m_deployerEnable = false;

        m_magic_readToBeDeploy = default;

    }

    public void CancelDeploy() {
        Destroy(m_magic_readToBeDeploy);

        m_deployerEnable = false;
        m_inifTime = 0f;
    }
}
