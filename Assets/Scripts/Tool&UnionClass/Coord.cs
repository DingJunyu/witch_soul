using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coord {
    public Coord() {
        x = 0;
        z = 0;
        end = false;
    }

    public float x;
    public float z;
    private const float y = 0;

    public bool end;//終りマーク

    public void Copy(Coord func_coord) {
        x = func_coord.x;
        z = func_coord.z;
        end = func_coord.end;
    }

    public void Reset() {
        x = 0; z = 0; end = false;
    }

    public void SetPoint(Vector2 func_vector) {
        x = func_vector.x;
        z = func_vector.y;
    }

    public void SetPoint(Vector3 func_vector) {
        x = func_vector.x;
        z = func_vector.z;
    }

    public float CalDis(Vector2 func_vector) {
        return Mathf.Sqrt((Mathf.Pow(x - func_vector.x, 2)) +
            (Mathf.Pow(z - func_vector.y, 2)));
    }

    public float CalDis(Vector3 func_vector) {
        return Mathf.Sqrt((Mathf.Pow(x - func_vector.x, 2)) +
            (Mathf.Pow(z - func_vector.z, 2)));
    }

    public Vector3 ReferVector3() {
        return new Vector3(x, y, z);
    }

    public Vector3 ReferVector3(float func_y) {
        return new Vector3(x, func_y, z);
    }
}
