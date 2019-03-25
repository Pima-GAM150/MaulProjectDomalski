using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

	public GameObject playerPrefab;
	public static GameManager Instance;

	void Start(){

		Instance = this;

	}

	public void StartGame(){

		LoadArena();

	}

	void LoadArena(){

		if(PhotonNetwork.IsMasterClient){

			PhotonNetwork.CurrentRoom.MaxPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
			PhotonNetwork.LoadLevel("test scene");

		}

	}

	public override void OnLeftRoom(){

		SceneManager.LoadScene(0);

	}

	public void LeaveRoom(){

		PhotonNetwork.LeaveRoom();

	}
    
}
