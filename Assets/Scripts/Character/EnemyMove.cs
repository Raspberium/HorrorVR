using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {


    public GameObject PlayerObject;
    private NavMeshAgent Agent;


	// Use this for initialization
	void Start () {
        Agent = GetComponent<NavMeshAgent>();
        //Agent.Move(PlayerObject.transform.position);
        //Agent.SetDestination(PlayerObject.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        //var move = Agent.desiredVelocity;
        //move = transform.InverseTransformDirection(move);
        Agent.SetDestination(PlayerObject.transform.position);
    }
}
