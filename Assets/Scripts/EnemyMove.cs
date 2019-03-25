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


		string temp = parent.gameObject.name;
		goals = new List<Transform>();

		if(temp.Contains("Red")){

			goals.Add(Waypoints.Orange);
			goals.Add(Waypoints.Green);
			goals.Add(Waypoints.Gray);

		}
		else if(temp.Contains("Teal")){

			goals.Add(Waypoints.Purple);
			goals.Add(Waypoints.Pink);
			goals.Add(Waypoints.Gray);

		}
		else if(temp.Contains("Blue")){

			int tempf = Random.Range(0, 2);
			if(tempf == 1){
				goals.Add(Waypoints.Purple);
				goals.Add(Waypoints.Pink);
			}
			else{

				goals.Add(Waypoints.Orange);
				goals.Add(Waypoints.Green);

			}
			goals.Add(Waypoints.Gray);

		}

		else if(temp.Contains("Orange")){

			goals.Add(Waypoints.Orange);
			goals.Add(Waypoints.Green);
			goals.Add(Waypoints.Gray);

		}
		else if(temp.Contains("Purple")){

			goals.Add(Waypoints.Purple);
			goals.Add(Waypoints.Pink);
			goals.Add(Waypoints.Gray);

		}

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
