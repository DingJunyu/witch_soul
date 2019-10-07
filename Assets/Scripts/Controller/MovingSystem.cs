using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトの移動を実現するクラス
public abstract class MovingSystem : MonoBehaviour {
    public float pu_speed = 5f;
    public float pu_high = 0f;

    private const float m_rotateSpeed = 0.5f;

    protected Coord m_nextPos;
    protected bool m_moving;
    public bool ReferMoving() { return m_moving; }
    private Quaternion m_targetRotation;
    private Rigidbody m_rigidBody;

    private Camera test_mainCamera;

    protected abstract void GetNextPos();

    // Start is called before the first frame update
    void Start() {
        Inif();
        SonInif();
    }

    private void Inif() {
        m_nextPos = new Coord();
        m_targetRotation = new Quaternion();

        test_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_nextPos.SetPoint(transform.position);

        m_rigidBody = GetComponent<Rigidbody>();
    }

    protected abstract void SonInif();

    // Update is called once per frame
    void Update() {
        if (!m_moving)
            GetNextPos();
        PosCheck();
        Move();
        SonUpdate();
        DeActiveRigid();//rigidbodyの機能を無効化する
    }

    private void DeActiveRigid() {
        m_rigidBody.angularVelocity = new Vector3(0, 0, 0);
        m_rigidBody.velocity = new Vector3(0, 0, 0);
    }

    private void PosCheck() {
        if (m_nextPos.CalDis(transform.position)
            < 0.01) {//0に近くなると移動を止まる
            //ウェイポイントに着かなければ移動を継続する
            m_moving = false;
        }
        else
            m_moving = true;
    }

    protected abstract void SonUpdate();

    private void Move() {
        if (!m_moving)
            return;

        ////ターゲットに移動する
        transform.position = Vector3.MoveTowards(transform.position,
              m_nextPos.ReferVector3(pu_high), pu_speed * Time.deltaTime);

        //角度を設定して回る
        Vector3 t_vector3 = m_nextPos.ReferVector3(pu_high) -
            transform.position;

        m_targetRotation = Quaternion.LookRotation(t_vector3);

        transform.rotation = Quaternion.Slerp(transform.rotation,
            m_targetRotation, m_rotateSpeed);

        if (m_nextPos.CalDis(transform.position) < .1f) {
            transform.position = m_nextPos.ReferVector3(pu_high);
        }
    }

    protected void Test_ShowPos() {
        Debug.Log(m_nextPos.x + "," + m_nextPos.z);
    }

    protected float CalRadian(Vector2 func_from, Vector2 func_to) {
        float x = func_from.x - func_to.x;
        float y = func_from.y - func_to.y;

        float hypotenuse = Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f));

        float cos = x / hypotenuse;
        float radian = Mathf.Acos(cos);

        radian = Mathf.Atan2(x, y);

        return radian;
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("hit");
        m_moving = false;
        m_nextPos.SetPoint(transform.position);
        OtherCollisionReact();
    }

    protected abstract void OtherCollisionReact();
}
