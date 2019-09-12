using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem_ForEnemy_Alpha : MovingSystem {
    public List<Vector2> pu_movingPoint;
    private Vector2 m_nextPointOnList;

    protected override void GetNextPos() {
        
    }

    protected override void SonInif() {
        pu_movingPoint = new List<Vector2>();
    }
}
