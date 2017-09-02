using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] ItemObjects;


    [System.Serializable]
    public class SpawnPoints {
        public List<SpawnPoint> ItemSpawnPoints = new List<SpawnPoint>();
    }
    [System.Serializable]
    public class SpawnPoint {
        public List<GameObject> Point = new List<GameObject>();
    }

    public SpawnPoints ItemSpawnPoints;


	// Use this for initialization
	void Start () {

        Spawn();


    }
	
	// Update is called once per frame
	void Update () {
		
	}


    GameObject obj;
    void Spawn() {


        for (int i = 0; i < ItemObjects.Length; i++) {

            if (ItemObjects[i] != null) {
                Debug.Log("アイテム生成"+i);
                obj = Instantiate(ItemObjects[i], ItemSpawnPoints.ItemSpawnPoints[i].Point[Random.Range(0, ItemSpawnPoints.ItemSpawnPoints[i].Point.Count)].transform);
            }
            else {
                Debug.LogError("ItemObjectが設定されていません");
            }
        }


    }

}
