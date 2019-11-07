using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Shield : Magic_WallType {

    protected override void OtherEffect(ref Collider func_other) {
        if (func_other.tag == "Bullet") {
            Destroy(func_other.gameObject);
        }
    }

    protected override void SonInif() {
        
    }

    protected override void UpdateBeforeUse() {

    }

    protected override void MagicEffectUpdate() {
        transform.LookAt(o_player.transform.position);
    }

    protected override void UseMagic_Son() {
        
    }
}
