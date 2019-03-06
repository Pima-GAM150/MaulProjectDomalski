using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMove : MonoBehaviourPun
{	

	public bool isBuilding; // determines if player is attempting to build something
	public PlayerStat player;
	public PlayerBuild build;
	public Vector3 target;
    
    void Update(){

		if(photonView.IsMine){

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
