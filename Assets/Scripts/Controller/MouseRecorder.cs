using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このクラスはマウスの移動ルートを記録します
public class MouseRecorder : MonoBehaviour {
    public float pu_pathLength = 20f;//設定できるマウスルート記録長さ
    private const float mc_maxPathLength = 100f;//プログラムの規制
    private const float mc_minPathLength = mc_interval;

    private const float mc_interval = 0.5f;//マウスを記録する間隔
    private int m_pointAmount;//記録ポイントの数
    private int t_nextPointNum;//次に取るデータ
    private int t_nextPointNumReadOnly;
    private int m_pointNumCount;

    private Coord[] m_pos;//座標を記録する
    Vector3 t_mousePos;

    private bool m_recording = false;
    private bool m_recorded = false;
    private bool m_readed = true;
    private bool m_endMark = false;

    private Camera o_mainCamera;
    GameObject o_gameManager;
    GameObject o_player;

    //メソッド
    public void RecordStart() {
        if (!m_readed || m_recording)
            return;

        m_recording = true;
        m_recorded = true;
        m_readed = false;
        m_pointNumCount = 0;
    }

    public void RecordEnd() {
        m_recording = false;
        t_nextPointNum = 0;
        o_gameManager.GetComponent<GameManager>().ChangeSelectStatus(false);
    }

    public void EndReading() {
        m_readed = true;
    }

    public Coord ReferNextPoint(bool func_readOnly) {
        if (t_nextPointNum < m_pointNumCount) {
            t_nextPointNum++;//制限を超えなければ次のポイントに行く
        }
        //最後の時にすべてのデータを消す
        if (!func_readOnly)
            if (t_nextPointNum == m_pointNumCount) {
                m_readed = true;
                t_nextPointNum--;
            }
        return m_pos[t_nextPointNum];
    }

    public Coord ReferNextPointAll() {
        if (t_nextPointNumReadOnly < m_pointNumCount) {
            t_nextPointNumReadOnly++;//制限を超えなければ次のポイントに行く
        }
        if (t_nextPointNumReadOnly == m_pointNumCount) {
            t_nextPointNumReadOnly = 0;
        }
        return m_pos[t_nextPointNumReadOnly];
    }

    public int ReferPointNumCount() {
        return m_pointNumCount;
    }

    public void ResetRecorder() {
        for (int i = 0; i < m_pointNumCount; i++) {
            m_pos[i].Reset();
        }
        m_pointNumCount = 0;
        m_endMark = false;
    }

    public bool HasRecordData() {
        return (!m_readed && m_endMark);
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
        for (int i = 0; i < m_pointAmount; i++) {
            m_pos[i] = new Coord();
        }
    }

    private void Inif() {
        o_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").
            GetComponent<Camera>();
        o_gameManager = GameObject.Find("GameManager");
        o_player = GameObject.FindGameObjectWithTag("Player");

        t_mousePos = new Vector3();
        t_nextPointNum = 0;
    }

    // Update is called once per frame
    void Update() {
        Test_MousePush();
        Record();
    }

    private void LateUpdate() {
        CheckStatus();
    }

    private void Record() {
        if (!m_recorded)//記録状態でなければそこで終わり
            return;

        t_mousePos =
            o_mainCamera.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            o_mainCamera.transform.position.y));//上から見る時のマウスの座標

        //起動用処理
        if (m_pointNumCount == 0) {
            m_pos[0].SetPoint(o_player.transform.position);
            m_pointNumCount++;
        }
        //記録処理
        if (m_pointNumCount != 0 &&
            m_pos[m_pointNumCount - 1].CalDis(t_mousePos) > mc_interval) {
            m_pos[m_pointNumCount].SetPoint(t_mousePos);//実際の座標を渡す
            m_pointNumCount++;
        }
        //終了処理
        if (!m_recording || m_pointNumCount == m_pointAmount - 1) {
            m_pos[m_pointNumCount].end = true;
            m_recorded = false;
            m_endMark = true;
            RecordEnd();
        }
    }

    private void CheckStatus() {
        if (m_readed && m_pointNumCount != 0)
            ResetRecorder();
    }

    public bool test_mousePushed;
    private void Test_MousePush() {
        if (!m_recorded)
            return;

        if (Input.GetMouseButtonUp(0) && !m_readed) {
            m_pos[m_pointNumCount].end = true;
            m_endMark = true;
            m_recorded = false;
            test_mousePushed = false;
            RecordEnd();
        }
    }

    public bool endOfMove() {
        return m_readed;
    }
}