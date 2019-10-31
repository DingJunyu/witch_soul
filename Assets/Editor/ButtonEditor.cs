using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Button))]
public class ButtonEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
    }
}