using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {
    public GameObject pu_recovery;
    public GameObject pu_damage;
    public GameObject pu_buff;

    public void NewEffect_Recovery(GameObject func_father) {
        Instantiate(pu_recovery, func_father.transform);
    }
}
