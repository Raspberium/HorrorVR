using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyObject;

    //出現までのキーアイテム取得数
    public int SpawnKeyItem = 1;

    //出現までの時間
    public float SpawnTime = 60;

    //出現する最短距離
    public int MinDistance = 60;

    //出現条件
    public bool KeyItemNum;
    public bool Time;

    public GameObject[] SpawnPoint;

    public GameManager Manager;

    private GameObject Player;
    private int SpawnPoint_i;
    private float Distance;

    // Use this for initialization
    void Start() {

        Player = GameObject.FindGameObjectWithTag("Player");

        if (KeyItemNum) StartCoroutine("KeyItemCheker");
        if (Time) StartCoroutine("TimeCheker");

    }

    // Update is called once per frame
    void Update() {

    }



    IEnumerator KeyItemCheker() {
        while (EnemyObject.activeInHierarchy == false) {
            yield return new WaitForSeconds(1);
            if (Manager.RemainingKeyItems < SpawnKeyItem) {
                SpawnEnemy();
            }
        }
    }

    IEnumerator TimeCheker() {
        yield return new WaitForSeconds(SpawnTime);
        if (EnemyObject.activeInHierarchy == false) {
            SpawnEnemy();
        }
    }


    private void SpawnEnemy() {


        if (EnemyObject.activeInHierarchy == false) {

            Distance = Mathf.Infinity;
            for (int i = 0; i < SpawnPoint.Length; i++) {
                var dis = GetDifferenceDistance(SpawnPoint[i]);
                if (dis > MinDistance) {
                    if (dis < Distance) {
                        Distance = GetDifferenceDistance(Player);
                        SpawnPoint_i = i;
                    }
                }
            }


            for (int i = 0; i < SpawnPoint.Length; i++) {
                var dis = GetDifferenceDistance(SpawnPoint[i]);
                if (dis > MinDistance) {
                    if (dis < Distance) {
                        Distance = GetDifferenceDistance(Player);
                        SpawnPoint_i = i;
                    }
                }
            }

            EnemyObject.transform.position = SpawnPoint[SpawnPoint_i].transform.position;
            EnemyObject.SetActive(true);
        }

    }

    private float GetDifferenceDistance(GameObject Point) {
        return Vector3.Distance(Point.transform.position, Player.transform.position);
    }

}
