using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSound : MonoBehaviour {

    public SE_DataBase DataBase;
    //public SphereCollider FootCollider;
    public PlayerMove MoveScripts;

    private AudioSource Source;

    public float FootInterval = 0.4f;
    public bool OnGround = true;

    int FootSteps_i = 0;


    private void Start() {
        OnGround = true;
        StartCoroutine("FootSteps");
        Source = GetComponent<AudioSource>();
    }


    IEnumerator FootSteps() {
        while(true) {

            if (MoveScripts.OnMove && OnGround) {
                Source.PlayOneShot(DataBase.FootSteps.FootStepsSound[FootSteps_i].FootStepsSound[Random.Range(0, DataBase.FootSteps.FootStepsSound[FootSteps_i].FootStepsSound.Length)]);
                yield return new WaitForSeconds(FootInterval);
            }

            yield return null;
        }
    }



    private void OnCollisionStay(Collision other) {

        if (!other.gameObject.GetComponent<GroundTags>()) return;
        if (!OnGround) OnGround = true;
        var sc = other.gameObject.GetComponent<GroundTags>();
        for (int i = 0; i < System.Enum.GetNames(typeof(GroundTags.GroundTagsEnum)).Length; i++) {
            if ((int)sc.Tag == i) {
                if(FootSteps_i != i) FootSteps_i = i;
                return;
            }
        }
        FootSteps_i = 0;
    }



    private void OnCollisionExit(Collision collision) {
        if (OnGround) OnGround = false;

    }






}
