using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトの移動を実現するクラス
public abstract class MovingSystem : MonoBehaviour {
    public float pu_speed = 5f;

    private Coord m_nextPos;
    public bool m_moving;
    private Quaternion m_targetRotation;

    private Camera test_mainCamera;

    protected abstract void GetNextPos();

    // Start is called before the first frame update
    void Start() {
        Inif();
    }

    private void Inif() {
        m_nextPos = new Coord();
        m_targetRotation = new Quaternion();

        test_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        Test_StartMoving();
        PosCheck();
        Move();
    }

    private void PosCheck() {
        if (m_nextPos.CalDis(test_mainCamera.ScreenToWorldPoint(Input.mousePosition)) < 1.0f) {
            //ウェイポイントに着かなければ移動を継続する
            m_moving = false;
        }
        m_moving = true;
    }

    private void Test_StartMoving() {
        Vector3 t_mousePos = test_mainCamera.ScreenToWorldPoint(
           new Vector3(Input.mousePosition.x, Input.mousePosition.y,
           test_mainCamera.transform.position.y));
        m_nextPos.SetPoint(t_mousePos);
    }

    private void Move() {
        if (!m_moving)
            return;

        //角度を設定する
        m_targetRotation.SetFromToRotation(transform.position, 
            m_nextPos.ReferVector3(transform.position.y));
        //ターゲットに移動する
        transform.position = Vector3.Lerp(transform.position,
            m_nextPos.ReferVector3(transform.position.y), pu_speed * Time.deltaTime);
        //回転する
        transform.rotation = m_targetRotation * transform.rotation;
    }

}
