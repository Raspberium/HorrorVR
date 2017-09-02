using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePoint : MonoBehaviour {

    public bool CanEscape = false;
    public SphereCollider Collider;
    public ParticleSystem ParticleEffect;

	// Use this for initialization
	void Start () {
        CanEscape = false;
        Collider.enabled = false;
        if(ParticleEffect)ParticleEffect.Stop();

    }


    public void CanEscapeOn() {
        CanEscape = true;
        Collider.enabled = true;
        if (ParticleEffect) ParticleEffect.Play();
    }

}
