using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic_Base : MonoBehaviour {
    protected GameObject o_player;

    public float pu_continueTime;
    public bool pu_oneTime = false;
    private float m_startTime;

    public float pu_coolDownTime = 0f;
    public float pu_magicConsumption = 0f;//魔力使う量

    private void OnTriggerStay(Collider func_other) {
        TakeEffectStay(ref func_other);
    }

    private void OnTriggerEnter(Collider func_other) {
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
    }
    protected abstract void SonInif();

    private void UseMagic() {
        //マジックのところの関数を使う

        UseMagic_Son();
    }

    protected abstract void UseMagic_Son();

    // Update is called once per frame
    void Update() {
        MagicEffectUpdate();
        ContinueTimeCheck();
    }

    private void ContinueTimeCheck() {
        if (Time.time > m_startTime + pu_continueTime)
            Destroy(gameObject);
    }

    protected abstract void MagicEffectUpdate();
}
