using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerBuild : MonoBehaviourPunCallbacks
{

    public GameObject BuildMenu, StandardMenu, cancelMenu, mouseInd;
    public PlayerStat stats;
    public List<GameObject> Towers;
	public List<Button> buttons;
	public List<int> prices;
    public int selectedTower;
    public bool isBuilding;

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
			mouseInd.transform.position = new Vector3(Waypoints.Gray.position.x, 0, Waypoints.Gray.position.z);
			break;
		case 1:
			mouseInd.transform.position = new Vector3(Waypoints.Red.position.x, 0, Waypoints.Red.position.z);
			break;
		case 2:
			mouseInd.transform.position = new Vector3(Waypoints.Blue.position.x, 0, Waypoints.Blue.position.z);
			break;
		case 3:
			mouseInd.transform.position = new Vector3(Waypoints.Teal.position.x, 0, Waypoints.Teal.position.z);
			break;
		case 4:
			mouseInd.transform.position = new Vector3(Waypoints.Yellow.position.x, 0, Waypoints.Yellow.position.z);
			break;
		case 5:
			mouseInd.transform.position = new Vector3(Waypoints.Orange.position.x, 0, Waypoints.Orange.position.z);
			break;
		case 6:
			mouseInd.transform.position = new Vector3(Waypoints.Purple.position.x, 0, Waypoints.Purple.position.z);
			break;
		case 7:
			mouseInd.transform.position = new Vector3(Waypoints.Green.position.x, 0, Waypoints.Green.position.z);
			break;
		case 8:
			mouseInd.transform.position = new Vector3(Waypoints.Pink.position.x, 0, Waypoints.Pink.position.z);
			break;


		}

	}

    public void Build() { BuildMenu.SetActive(true); StandardMenu.SetActive(false); }
	public void Cancel() { BuildMenu.SetActive(false); StandardMenu.SetActive(true); isBuilding = false; mouseInd.SetActive(false);}
	public void CancelIn() { BuildMenu.SetActive(true);  cancelMenu.SetActive(false); isBuilding = false; mouseInd.SetActive(false);}
	public void BuildX(int x) { BuildMenu.SetActive(false); cancelMenu.SetActive(true); isBuilding = true; selectedTower = x;  mouseInd.SetActive(true);}

    private void Update()
    {
		//if(photonView.IsMine == false && PhotonNetwork.IsConnected == true)
		//	return;
        if (isBuilding) {

			int t = 0;
			foreach(Button x in buttons){

				if(prices[t] > stats.gold)
					x.interactable = false;
				else
					x.interactable = true;

			}

            mouseInd.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return)) {

				bool ispaid = false;

				switch(selectedTower){

					case 0:
					if(stats.gold >= 7){
						stats.gold-= 7;
						ispaid = true;
					}
					break;
					case 1:
					if(stats.gold >= 80){
						stats.gold-= 80;
						ispaid = true;
					}
					break;
					case 2:
					if(stats.gold >= 120){
						stats.gold-= 120;
						ispaid = true;
					}
					break;
					case 3:
					if(stats.gold >= 170){
						stats.gold-= 170;
						ispaid = true;
					}
					break;
					case 4:
					if(stats.gold >= 250){
						stats.gold-= 250;
						ispaid = true;
					}
					break;
					case 5:
					if(stats.gold >= 310){
						stats.gold-= 310;
						ispaid = true;
					}
					break;


				}

				if(ispaid){
               		GameObject temp = PhotonNetwork.Instantiate(Towers[selectedTower].name, mouseInd.transform.position, Quaternion.identity);
                	temp.GetComponent<MeshRenderer>().material = stats.playerColor;
               	 	temp.GetComponent<TowerStat>().owner = stats;
				}
            
            }
			else if(Input.GetKeyDown(KeyCode.A)){

				mouseInd.transform.Translate(-1, 0, 0);

			}
			else if(Input.GetKeyDown(KeyCode.D)){

				mouseInd.transform.Translate(1, 0, 0);

			}
			else if(Input.GetKeyDown(KeyCode.S)){

				mouseInd.transform.Translate(0, 0, -1);

			}
			else if(Input.GetKeyDown(KeyCode.W)){

				mouseInd.transform.Translate(0, 0, 1);

			}

        }

    }

}
