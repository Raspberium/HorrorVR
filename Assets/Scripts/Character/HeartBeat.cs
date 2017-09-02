using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartBeat : MonoBehaviour {

    public GameObject OwnerObject;
    public List<GameObject> Enemies = new List<GameObject>();
    int[] FrameInterval = { 10, 20, 30, 40, 50, 60 };

    float[] SoundPitch = { 3, 2.6f, 2.3f, 2, 1.7f, 1.3f };

    public AudioSource Source;

    enum FrameIntervalRank {
        S,
        A,
        B,
        C,
        D,
        E,
    }
    FrameIntervalRank Rank;

    // Use this for initialization
    void Start () {
        StartCoroutine("HeartSearch");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator HeartSearch() {
        
        int i, j, rank;
        float Dis;
        while(true) {
            Dis = 100;
            rank = -1;
            for (j = 0; j < Enemies.Count; j++) {
                Dis = GetDifferenceDistance(Enemies[j]);
                //Debug.Log(Dis);
                for (i = 0; i < FrameInterval.Length; i++) {
                    if(Dis < FrameInterval[i]) {
                        rank = i;
                        Dis = FrameInterval[i];
                        j = Enemies.Count;
                        break;
                    }
                }
            }

            BeatChange(rank);
            yield return new WaitForSeconds(0.1f);
        }
    }




    private float GetDifferenceDistance(GameObject Target) {
        return Vector3.Distance(OwnerObject.transform.position, Target.transform.position);
    }


    private void BeatChange(int Level) {
        switch(Level) {
            case (int)FrameIntervalRank.S:
                {
                    if (Source.pitch != SoundPitch[0]) Source.pitch = SoundPitch[0];
                    break;
                }
            case (int)FrameIntervalRank.A:
                {
                    if (Source.pitch != SoundPitch[1]) Source.pitch = SoundPitch[1];
                    break;
                }
            case (int)FrameIntervalRank.B:
                {
                    if (Source.pitch != SoundPitch[2]) Source.pitch = SoundPitch[2];
                    break;
                }
            case (int)FrameIntervalRank.C:
                {
                    if (Source.pitch != SoundPitch[3]) Source.pitch = SoundPitch[3];
                    break;
                }
            case (int)FrameIntervalRank.D:
                {
                    if (Source.pitch != SoundPitch[4]) Source.pitch = SoundPitch[4];
                    break;
                }
            case (int)FrameIntervalRank.E:
                {
                    if (Source.pitch != SoundPitch[5]) Source.pitch = SoundPitch[5];
                    break;
                }
            default: {
                    if (Source.pitch != 1) Source.pitch = 1;
                    break;
            }
        }
    }


}
