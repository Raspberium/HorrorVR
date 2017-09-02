using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public SE_DataBase SE;
    public int Num_GotItems;


    public AudioSource Source;


    public GameManager Manager;


    public bool IsDead = false;
    public bool IsEscape = false;

    // Use this for initialization
    void Awake() {
        IsDead = false;
        IsEscape = false;
    }

    void Start () {
        Num_GotItems = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnTriggerEnter(Collider other) {
        if(IsDead) return;

        if(other.gameObject.tag == "Enemy") {
            Manager.SceneChange_GameOver();
            IsDead = true;
        }

        if(other.gameObject.tag == "EscapePoint") {
            Manager.SceneChange_Title();
            IsEscape = true;
        }


        if(other.gameObject.tag == "KeyItem") {
            Num_GotItems++;
            Source.PlayOneShot(SE.GetKeyItem);
            Manager.RemainingKeyItemsUpdate(-1);
            Destroy(other.gameObject);
        }

    }

}
