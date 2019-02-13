using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{	

	public bool isPlayer; // adding online functionality later (because I am horribly confused), this determines if this this specific script belongs to this comp
	public bool isBuilding; // determines if player is attempting to build something
	public PlayerStat player;
	public PlayerBuild build;
	public Vector3 target;
    
    void Update(){

		if(isPlayer){

			if(Input.GetKeyDown(KeyCode.Mouse1)){

				if(isBuilding){

					isBuilding = false;

				}
					
				target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			}

			if(Mathf.Abs((target - transform.position).magnitude) > 0.5){

				if(isBuilding && Mathf.Abs((target - transform.position).magnitude) < 1.0){

					//build.BuildSelected();

				}

				transform.Translate(target * Time.deltaTime * 8);

			}
				
		}
    }

}
