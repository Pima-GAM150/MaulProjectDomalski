using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerBuild : MonoBehaviour
{

    public GameObject BuildMenu, StandardMenu, cancelMenu, mouseInd;
    public PlayerStat stats;
    public List<GameObject> Towers;
	public List<Button> buttons;
	public List<int> prices;
    public int selectedTower;
    public bool isBuilding;

    public void Build() { BuildMenu.SetActive(true); StandardMenu.SetActive(false); }
	public void Cancel() { BuildMenu.SetActive(false); StandardMenu.SetActive(true); isBuilding = false; mouseInd.SetActive(false);}
	public void CancelIn() { BuildMenu.SetActive(true);  cancelMenu.SetActive(false); isBuilding = false; mouseInd.SetActive(false);}
	public void BuildX(int x) { BuildMenu.SetActive(false); cancelMenu.SetActive(true); isBuilding = true; selectedTower = x;  mouseInd.SetActive(true);}

    private void Update()
    {

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

                GameObject temp = PhotonNetwork.Instantiate(Towers[selectedTower].name, mouseInd.transform.position, Quaternion.identity);
                temp.GetComponent<SpriteRenderer>().color = stats.playerColor;
                temp.GetComponent<TowerStat>().owner = stats;
            
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
