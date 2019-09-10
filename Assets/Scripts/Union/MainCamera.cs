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
//        MoveCamera();
    }

    private void MoveCamera() {
        transform.position = o_player.transform.position;
        Vector3 t_vector3 = new Vector3();
        t_vector3 = transform.position;
        t_vector3.z += 35f;

        transform.position = t_vector3;
    }
}
