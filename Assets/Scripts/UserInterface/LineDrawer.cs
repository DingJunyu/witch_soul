using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LineDrawer : MonoBehaviour {
    private LineRenderer m_lineRenderer;
    private MouseRecorder o_mouseRecorder;

    private const int m_maxLineLength = 100;
    private int m_lineLength;
    private Vector3[] m_pos;

    private bool m_cleared;
    private bool m_dataReaded;

    // Start is called before the first frame update
    void Start() {
        Inif();
    }

    private void Inif() {
        m_lineRenderer = transform.GetComponent<LineRenderer>();
        o_mouseRecorder = GameObject.Find("MouseRecorder").
           GetComponent<MouseRecorder>();
        m_lineRenderer.enabled = false;

        /*空間確保*/
        m_pos = new Vector3[m_maxLineLength];
        for (int i = 0; i < m_maxLineLength; i++) {
            m_pos[i] = new Vector3();
        }

        m_cleared = true;
        m_dataReaded = false;
    }


    // Update is called once per frame
    void Update() {
        if (o_mouseRecorder.HasRecordData()) {
            if (m_cleared)
                ReadLine();
        }
        else if(!m_cleared) {
            ClearTheLine();
        }
    }

    private void ReadLine() {
        if (m_dataReaded)
            return;

        m_lineRenderer.enabled = true;
        m_lineLength = o_mouseRecorder.ReferPointNumCount();

        for (int i = 0; i < m_lineLength; i++) {
            Vector3 t_pos = o_mouseRecorder.ReferNextPointAll().ReferVector3();

            m_pos[i].x = t_pos.x;
            m_pos[i].y = t_pos.y;
            m_pos[i].z = t_pos.z;
        }

        m_lineRenderer.positionCount = m_lineLength - 1;
        
        for (int i = 0; i < m_lineLength - 1; i++) {
            m_lineRenderer.SetPosition(i, m_pos[i]);
        }

        m_cleared = false;
    }

    private void ClearTheLine() {
        for (int i = 0; i < m_maxLineLength; i++) {
            m_pos[i].x = 0;
            m_pos[i].y = 0;
            m_pos[i].z = 0;
        }
        m_cleared = true;
        m_dataReaded = false;
        m_lineRenderer.enabled = false;
    }
}
