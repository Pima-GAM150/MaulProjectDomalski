using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    
	public Transform goal;
	public List<Transform> goals;
	public EnemyStat me;
	public GameController controller;
	public NavMeshAgent agent;

	void Start () {
		
		agent = GetComponent<NavMeshAgent>();
		goal = goals[0];
		agent.destination = goal.position; 

	}

	void Update(){

		if(Vector3.Distance(transform.position, goal.position) < 5){

			goals.Remove(goal);

			if(goals.Count > 0){

				goal = goals[0];
				agent.destination = goal.position;

			}
			else{

				controller.lives--;
				me.Death();

			}

		}

	}

}
