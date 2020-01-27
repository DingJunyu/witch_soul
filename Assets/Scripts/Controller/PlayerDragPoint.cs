using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragPoint : MonoBehaviour {
    GameObject o_gameManager;

    // Start is called before the first frame update
    void Start() {
        o_gameManager = GameObject.Find("GameManager");
    }

    private void OnMouseDown() {
        o_gameManager.GetComponent<GameManager>().ChangeSelectStatus(true);
    }
}
