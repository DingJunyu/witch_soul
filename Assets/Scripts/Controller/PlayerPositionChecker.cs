using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionChecker : MonoBehaviour {
    public float pu_startMovingAtX = 11f;
    public float pu_removeAtX = 30f;

    private GameObject o_player;

    // Start is called before the first frame update
    void Start() {
        o_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        CheckStartMoving();
        CheckDestroy();
    }

    private void CheckStartMoving() {
        if (pu_startMovingAtX < o_player.transform.position.x) {
            GetComponent<MovingSystem_Enemy_Base>().StartMove();
        }
    }

    private void CheckDestroy() {
        if (pu_removeAtX < o_player.transform.position.x) {
            Destroy(gameObject);
        }
    }
}
