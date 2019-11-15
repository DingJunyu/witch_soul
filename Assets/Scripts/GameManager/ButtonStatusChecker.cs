using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonStatusChecker : MonoBehaviour {
    Transform my_son;

    protected int m_status = 0;

    private void Start() {
        my_son = transform.Find("Mark");

        CheckStatus();
    }

    private void Update() {
        CheckStatus();
    }

    public abstract void CheckStatus();

    public void SetOn() {
        my_son.gameObject.SetActive(true);
    }

    public void SetOff() {
        my_son.gameObject.SetActive(false);
    }
}
