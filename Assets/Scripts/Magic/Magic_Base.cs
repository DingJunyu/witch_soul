using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic_Base : MonoBehaviour {
    protected GameObject o_player;
    private Camera o_mainCamera;

    private bool m_display = true;

    public float pu_continueTime;
    public bool pu_oneTime = false;
    private float m_startTime;
    private bool m_firstTimeContact = true;

    public float pu_coolDownTime = 0f;
    [Range(1, 4)] public int pu_magicComsumption;
    private float m_magicConsumption = 1f;//魔力使う量

    public void UseThis() {
        m_display = false;
        m_startTime = Time.fixedTime;
    }

    public float ReferCD() {
        return pu_coolDownTime;
    }

    public float ReferMC() {
        return m_magicConsumption;
    }

    private void OnTriggerStay(Collider func_other) {
        if (m_display)
            return;

        TakeEffectStay(ref func_other);
    }

    private void OnTriggerEnter(Collider func_other) {
        if (m_display)
            return;

        TakeEffectEnter(ref func_other);
    }

    protected abstract void TakeEffectStay(ref Collider func_other);
    protected abstract void TakeEffectEnter(ref Collider func_other);

    
    void Start() {
        Inif();
        SonInif();
    }

    private void Inif() {
        o_player = GameObject.FindGameObjectWithTag("Player");

        o_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").
            GetComponent<Camera>();

        m_firstTimeContact = true;
        m_magicConsumption = (int)pu_magicComsumption;
    }
    protected abstract void SonInif();

    protected void UseMagic() {
        //マジックのところの関数を使う

        if (m_display)
            return;

        UseMagic_Son();
    }

    protected abstract void UseMagic_Son();
    
    void FixedUpdate() {
        if (m_display) {
            MouseFollower();
            UpdateBeforeUse();
            return;
        }

        MagicEffectUpdate();
        ContinueTimeCheck();
    }

    private void ContinueTimeCheck() {
        if (Time.fixedTime > m_startTime + pu_continueTime)
            Destroy(gameObject);
    }

    protected abstract void MagicEffectUpdate();
    protected abstract void UpdateBeforeUse();

    private void MouseFollower() {
        Vector3 t_mousePos = new Vector3();

        t_mousePos =
           o_mainCamera.ScreenToWorldPoint(
           new Vector3(Input.mousePosition.x, Input.mousePosition.y,
           o_mainCamera.transform.position.y));//上から見る時のマウスの座標

        Coord t_coord = new Coord();
        t_coord.SetPoint(t_mousePos);

        transform.position = t_coord.ReferVector3(0f);
    }
}
