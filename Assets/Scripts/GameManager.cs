using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

	//public GameObject playerPrefab;
	public static GameManager Instance;
	public Text numPlayers;
	public Button HostButton;
	public GameObject panel;


	void Start(){

		Instance = this;

	}

	void Update(){

		if(PhotonNetwork.IsMasterClient){


			numPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount + " players connected";

		}
		else{

			numPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount + " players connected\nWaiting for host to start game...";

		}

	}

	public void newPanel(){

		panel.SetActive(true);

		if(PhotonNetwork.IsMasterClient){

			numPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount + " players connected";

		}
		else{

			HostButton.gameObject.SetActive(false);


		}

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
