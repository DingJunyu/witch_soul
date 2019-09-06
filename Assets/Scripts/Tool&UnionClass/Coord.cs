using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coord {
    public Coord() {
        end = false;
    }

    public float x;
    public float z;

    public bool end;//終りマーク

    public void SetPoint(Vector2 vector) {
        x = vector.x;
        z = vector.y;
    }

    public void SetPoint(Vector3 vector) {
        x = vector.x;
        z = vector.z;
    }

    public float CalDis(Vector2 vector) {
        return Mathf.Sqrt((Mathf.Pow(x - vector.x, 2)) +
            (Mathf.Pow(z - vector.y, 2)));
    }

    public float CalDis(Vector3 vector) {
        return Mathf.Sqrt((Mathf.Pow(x - vector.x, 2)) +
            (Mathf.Pow(z - vector.z, 2)));
    }

    public Vector3 ReferVector3() {
        return new Vector3(x, 0, z);
    }

    public Vector3 ReferVector3(float y) {
        return new Vector3(x, y, z);
    }
}
