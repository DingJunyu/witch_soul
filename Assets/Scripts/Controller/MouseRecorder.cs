using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このクラスはマウスの移動ルートを記録します
public class MouseRecorder : MonoBehaviour {
    public float pu_pathLength = 20f;//設定できるマウスルート記録長さ
    private const float mc_maxPathLength = 100f;//プログラムの規制
    private const float mc_minPathLength = mc_interval;

    private const float mc_interval = 5f;//マウスを記録する間隔
    private int m_pointAmount;//記録ポイントの数
    private int t_nextPointNum;//次に取るデータ
    private int m_pointNumCount;

    private Coord[] m_pos;//座標を記録する

    private bool m_recording = false;
    private bool m_recorded = false;    

    private Camera o_mainCamera;

    //メソッド
    public void RecordStart() {
        m_recording = true;
        m_recorded = true;
    }

    public void RecordEnd() {
        m_recording = false;
    }

    public Coord ReferNextPoint() {
        if (t_nextPointNum < m_pointNumCount) {
            t_nextPointNum++;//制限を超えなければ次のポイントに行く
        }
        return m_pos[t_nextPointNum];
    }

    public void ResetRecorder() {
        for (int i = 0; i < m_pointNumCount; i++) {
            m_pos[m_pointNumCount].end = false;
        }
        m_pointNumCount = 0;
    }

    // Start is called before the first frame update
    void Start() {
        Inif();
        CalPointAmount();
    }

    //初期化関連
    private void CalPointAmount() {
        m_pointAmount = (int)(pu_pathLength / mc_interval);//unityから取ったデータでポイントの数を計算する
        m_pos = new Coord[m_pointAmount];
    }

    private void Inif() {
        o_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        Test_MousePush();
//        Record();
    }

    private void Record() {
        if (!m_recorded)//記録状態でなければそこで終わり
            return;

        Vector3 t_mousePos = o_mainCamera.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            o_mainCamera.transform.position.y));

        if (m_pointNumCount == 0 || m_pos[m_pointNumCount].CalDis(t_mousePos) > mc_interval) {
            m_pos[m_pointNumCount].SetPoint(t_mousePos);//実際の座標を渡す
        }
        if (!m_recording || m_pointAmount == m_pointNumCount) {
            m_pos[m_pointNumCount].end = true;
            m_recorded = false;
        }
    }

    

    public bool test_mousePushed;
    private void Test_MousePush() {
        if (Input.GetMouseButtonDown(0)) {
            test_mousePushed = true;
            RecordStart();
        }
        if (Input.GetMouseButtonUp(0)) {
            test_mousePushed = false;
            RecordEnd();
        }
    }
}