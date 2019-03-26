using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks{


	private byte maxPlayersPerRoom = 9;

	bool isConnecting;

	void Awake(){PhotonNetwork.AutomaticallySyncScene = true;}
		
	public override void OnConnectedToMaster(){

		if(isConnecting)
			PhotonNetwork.JoinRandomRoom();

	}

	public override void OnDisconnected(DisconnectCause cause){}

	public override void OnJoinRandomFailed(short returnCode, string message){

		PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers= maxPlayersPerRoom});

	}

	public void Connect(){

		isConnecting = true;

		if (PhotonNetwork.IsConnected){

			PhotonNetwork.JoinRandomRoom();

		}

		else{

			PhotonNetwork.ConnectUsingSettings();

		}
	}

	public override void OnJoinedRoom(){
		


	}

}
