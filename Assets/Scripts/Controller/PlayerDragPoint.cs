using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragPoint : MonoBehaviour {
    GameObject o_gameManager;
    Vector3 m_myPos;
    Vector3 m_randPos;

    // Start is called before the first frame update
    void Start() {
        o_gameManager = GameObject.Find("GameManager");
        m_myPos = new Vector3(0f, 3.3f, 0f);
        m_randPos = new Vector3(1f, 3.3f, 1f);
    }

    private void Update() {
        //原因不明のドラッグバッグがあったが、座標をたまに変更するとこのバッグが解決できる。
        //バッグがなくなった理由はまだ分かりません。
        transform.localPosition = m_randPos;
        transform.localPosition = m_myPos;
    }

    private void OnMouseDown() {
        o_gameManager.GetComponent<GameManager>().ChangeSelectStatus(true);
    }
}
