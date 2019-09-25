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

    public float pu_coolDownTime = 0f;
    public float pu_magicConsumption = 0f;//魔力使う量

    public void UseThis() {
        m_display = false;
    }

    public float ReferCD() {
        return pu_coolDownTime;
    }

    public float ReferMC() {
        return pu_magicConsumption;
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

    // Start is called before the first frame update
    void Start() {
        Inif();
        SonInif();
    }

    private void Inif() {
        o_player = GameObject.FindGameObjectWithTag("Player");
        m_startTime = Time.time;

        o_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").
            GetComponent<Camera>();
    }
    protected abstract void SonInif();

    private void UseMagic() {
        //マジックのところの関数を使う

        if (m_display)
            return;

        UseMagic_Son();
    }

    protected abstract void UseMagic_Son();

    // Update is called once per frame
    void Update() {


        if (m_display) {
            MouseFollower();
            return;
        }

        MagicEffectUpdate();
        ContinueTimeCheck();
    }

    private void ContinueTimeCheck() {
        if (Time.time > m_startTime + pu_continueTime)
            Destroy(gameObject);
    }

    protected abstract void MagicEffectUpdate();

    private void MouseFollower() {
        Vector3 t_mousePos = new Vector3();

        t_mousePos =
           o_mainCamera.ScreenToWorldPoint(
           new Vector3(Input.mousePosition.x, Input.mousePosition.y,
           o_mainCamera.transform.position.y));//上から見る時のマウスの座標

        Coord t_coord = new Coord();
        t_coord.SetPoint(t_mousePos);

        transform.position = t_coord.ReferVector3();
    }
}
