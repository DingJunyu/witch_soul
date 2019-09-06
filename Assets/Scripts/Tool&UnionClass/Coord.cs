using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coord {
    public float x;
    public float y;

    public bool end = false;//終りマーク

    public void SetPoint(Vector2 vector) {
        x = vector.x;
        y = vector.y;
    }

    public float CalDis(Vector2 vector) {
        return Mathf.Sqrt((Mathf.Pow(x - vector.x, 2)) +
            (Mathf.Pow(y - vector.y, 2)));
    }

    public float CalDis(Vector3 vector) {
        return Mathf.Sqrt((Mathf.Pow(x - vector.x, 2)) +
            (Mathf.Pow(y - vector.y, 2)));
    }
}
