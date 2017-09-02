using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {

    //public NavMeshAgent Agent;

    public float ForwardSpeed = 10;      //前進速度
    public float BackSpeed = 5;         //後進速度
    public float RotationalSpeed = 60;   //旋回速度
    public float ParallelSpeed = 10;     //左右並行速度


    public bool OnMove = false;

    private float DeltaTime = 0;
    //private Vector3 Direction;


    public bool OnOculusMode;
    public GameObject OVRCamera;
    public Light HandLight;
    [SerializeField]private bool OnHandTrigger;

    // Use this for initialization
    void Start () {
        OnHandTrigger = false;
    }
	
	// Update is called once per frame
	void Update () {
        DeltaTime = Time.deltaTime;
        Move();
        //Rotate();
    }


    private void Move() {

        if (OnMove) { OnMove = false; }





        if (OnOculusMode) {
            Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);


            if(stickR.y > 0) {
                transform.position += new Vector3(OVRCamera.transform.forward.x, 0, OVRCamera.transform.forward.z) * ForwardSpeed * DeltaTime * stickR.y;
                if (!OnMove) { OnMove = true; }
            }
            else if (stickR.y < 0) {
                transform.position += new Vector3(OVRCamera.transform.forward.x, 0, OVRCamera.transform.forward.z) * BackSpeed * DeltaTime * stickR.y;
                if (!OnMove) { OnMove = true; }
            }

            if (stickR.x > 0.4) {
                transform.position += OVRCamera.transform.right * ParallelSpeed * DeltaTime;
                if (!OnMove) { OnMove = true; }
            }
            else if (stickR.x < -0.4) {
                transform.position -= OVRCamera.transform.right * ParallelSpeed * DeltaTime;
                if (!OnMove) { OnMove = true; }
            }




            if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.5f && !OnHandTrigger) {
                HandLight.enabled = !HandLight.enabled;
                OnHandTrigger = true;
            }
            else if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) == 0 && OnHandTrigger) {
                OnHandTrigger = false;
            }

        }


        else {
            if (Input.GetKey("w")) {
                transform.position += new Vector3(transform.forward.x, 0, transform.forward.z) * ForwardSpeed * DeltaTime;
                if (!OnMove) { OnMove = true; }
            }
            if (Input.GetKey("s")) {
                transform.position += new Vector3(transform.forward.x, 0, transform.forward.z) * -BackSpeed * DeltaTime;
                if (!OnMove) { OnMove = true; }
            }
            if (Input.GetKey("d")) {
                transform.Rotate(new Vector3(0, RotationalSpeed * DeltaTime, 0));
            }
            if (Input.GetKey("a")) {
                transform.Rotate(new Vector3(0, -RotationalSpeed * DeltaTime, 0));
            }
        }


    }


    //private void Rotate() {
    //    if (Input.GetAxis("Mouse X") > 0 && Input.GetKey(KeyCode.Mouse0)) {
    //        transform.Rotate(new Vector3(0, RotationalSpeed * DeltaTime, 0));
    //    }
    //    if (Input.GetAxis("Mouse X") < 0 && Input.GetKey(KeyCode.Mouse0)) {
    //        transform.Rotate(new Vector3(0, -RotationalSpeed * DeltaTime, 0));
    //    }
    //}


}
