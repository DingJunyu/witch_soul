using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトの移動を実現するクラス
public abstract class MovingSystem : MonoBehaviour {
    public float pu_speed;

    private Coord m_nextPos;
    private bool moving;
    private Quaternion targetRotation;

    protected abstract void GetNextPos();

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void PosCheck() {
        if (m_nextPos.CalDis(transform.position) < 1.0f) {//ウェイポイントに着かなければ移動を継続する
            moving = false;
        }
    }

    private void Move() {
        if (!moving)
            return;

        
    }
}
