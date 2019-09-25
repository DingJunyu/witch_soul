using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDeployer : MonoBehaviour {
    private GameObject m_magic_readToBeDeploy;

    private bool m_deployerEnable = false;
    public bool ReferDeployerEnable() { return m_deployerEnable; }

    public void SetMagic(GameObject func_magic_readToBeDeploy) {
        m_magic_readToBeDeploy = Instantiate(func_magic_readToBeDeploy, transform);
        m_deployerEnable = true;
    }

    // Start is called before the first frame update
    void Start() {

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
            m_deployerEnable = false;
        }
    }
}
