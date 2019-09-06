using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このクラスはマウスの移動ルートを記録します
public class MouseRecorder : MonoBehaviour {
    public float pu_pathLength;//設定できるマウスルート記録長さ
    private const float mc_maxPathLength = 100f;//プログラムの規制
    private const float mc_minPathLength = mc_interval;

    private const float mc_interval = 5f;//マウスを記録する間隔
    private int m_pointAmount;//記録ポイントの数
    private int t_nextPointNum;//次に取るデータ
    private int m_pointNumCount;

    private Coord[] m_pos;//座標を記録する

    private bool m_recording = false;
    private bool m_recorded = false;

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
        CalPointAmount();
    }

    //初期化関連
    private void CalPointAmount() {
        m_pointAmount = (int)(pu_pathLength / mc_interval);//unityから取ったデータでポイントの数を計算する
        m_pos = new Coord[m_pointAmount];
        m_pos[m_pointAmount].end = true;//最後の一個に終わりマークを付ける
    }

    // Update is called once per frame
    void Update() {
        Record();
    }

    private void Record() {
        if (!m_recorded)//記録状態でなければそこで終わり
            return;
        if (m_pointNumCount == 0 || m_pos[m_pointNumCount].CalDis(Input.mousePosition) > mc_interval) {
            m_pos[m_pointNumCount].SetPoint(Input.mousePosition);
        }
        if (!m_recording) {
            m_pos[m_pointNumCount].end = true;
            m_recorded = false;
        }
    }
}