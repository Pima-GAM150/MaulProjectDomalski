using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Camera : MonoBehaviour
{

	public float cameraspeed;

	void Start(){

		int index = 0;

		foreach(Player p in PhotonNetwork.CurrentRoom.Players.Values){

			if(p.UserId.Equals(PhotonNetwork.LocalPlayer.UserId)){

				break;

			}
			index++;
		}


		switch(index){

		case 0:
			transform.position = new Vector3(Waypoints.Gray.position.x, 10, Waypoints.Gray.position.z);
			break;
		case 1:
			transform.position = new Vector3(Waypoints.Red.position.x, 10, Waypoints.Red.position.z);
			break;
		case 2:
			transform.position = new Vector3(Waypoints.Blue.position.x, 10, Waypoints.Blue.position.z);
			break;
		case 3:
			transform.position = new Vector3(Waypoints.Teal.position.x, 10, Waypoints.Teal.position.z);
			break;
		case 4:
			transform.position = new Vector3(Waypoints.Yellow.position.x, 10, Waypoints.Yellow.position.z);
			break;
		case 5:
			transform.position = new Vector3(Waypoints.Orange.position.x, 10, Waypoints.Orange.position.z);
			break;
		case 6:
			transform.position = new Vector3(Waypoints.Purple.position.x, 10, Waypoints.Purple.position.z);
			break;
		case 7:
			transform.position = new Vector3(Waypoints.Green.position.x, 10, Waypoints.Green.position.z);
			break;
		case 8:
			transform.position = new Vector3(Waypoints.Pink.position.x, 10, Waypoints.Pink.position.z);
			break;


		}

	}
    
    void Update()
    {
        
		if(Input.GetKey(KeyCode.UpArrow)){

			transform.Translate(new Vector3(0, Time.deltaTime* cameraspeed, 0));

		}
		if(Input.GetKey(KeyCode.DownArrow)){

			transform.Translate(new Vector3(0, Time.deltaTime* cameraspeed * -1, 0));

		}
		if(Input.GetKey(KeyCode.RightArrow)){

			transform.Translate(new Vector3(Time.deltaTime* cameraspeed, 0, 0));

		}
		if(Input.GetKey(KeyCode.LeftArrow)){

			transform.Translate(new Vector3(Time.deltaTime* cameraspeed * -1, 0, 0));

		}

    }

}
