using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(OuterFenceInstance))]
public class OuterFenceInstanceEditor : Editor {

    OuterFenceInstance Script;

    public void OnEnable() {
        if(Selection.gameObjects[0].GetComponent<OuterFenceInstance>()) {
            Script = Selection.gameObjects[0].GetComponent<OuterFenceInstance>();
        }
        else {
            if(Script != null) Script = null;
        }
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
        if(GUILayout.Button("生成")) {
            if(Script != null) {
                Script.Instance();
            }
            else {
                Debug.Log("<OuterFenceInstance>がアタッチされているgameobjectを選択してください");
            }
        }
        
    }



}
