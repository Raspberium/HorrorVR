using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OuterFenceInstance : MonoBehaviour {


    public GameObject InstanceObject;
    public int InstanceNumber = 0;
    public int DistanceInteval = 10;

    private GameObject obj;

    public void Instance() {
        if (InstanceNumber == 0) {
            Debug.LogError("InstanceNumberが0だよ");
            return;
        }
        else if(InstanceObject == null) {
            Debug.LogError("InstanceObjectがNullです");
            return;
        }
        for(int i = 0; i < InstanceNumber;i++) {
            obj = Instantiate(InstanceObject, new Vector3(transform.position.x + (DistanceInteval * i), transform.position.y, transform.position.z), transform.rotation);
            Undo.RegisterCreatedObjectUndo(obj, "FenceObjを生成");
            obj.transform.parent = transform.root;
        }
        Debug.Log("生成しました");
    }

}
