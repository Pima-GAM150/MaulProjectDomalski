using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks{
	
	private byte maxPlayersPerRoom = 9;

	void Awake(){PhotonNetwork.AutomaticallySyncScene = true;}
		
	public override void OnConnectedToMaster(){

		PhotonNetwork.JoinRandomRoom();

	}

	public override void OnDisconnected(DisconnectCause cause){}

	public override void OnJoinRandomFailed(short returnCode, string message){

		PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayer = maxPlayersPerRoom});

	}

	public override void OnJoinedRoom(){
		


	}

}
