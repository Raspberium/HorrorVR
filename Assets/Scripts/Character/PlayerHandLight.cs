using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandLight : MonoBehaviour {


    public GameObject HandLight;



    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;


    // Use this for initialization
    void Start () {
		
	}
	


    //懐中電灯の更新をおこないます
	// Update is called once per frame
	void Update () {
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        HandLight.transform.LookAt(screenToWorldPointPosition);
    }
}
