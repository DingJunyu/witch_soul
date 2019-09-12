using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    GameObject o_player;

    private void Start() {
        Inif();
    }

    private void Inif() {
        o_player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        MoveCamera();
    }

    private void MoveCamera() {
        Vector3 t_vector3 = new Vector3(o_player.transform.position.x+3f,
            transform.position.y,transform.position.z);

        transform.position = t_vector3;
    }
}
