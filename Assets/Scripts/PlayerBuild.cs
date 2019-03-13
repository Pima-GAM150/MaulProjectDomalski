﻿using System.Collections;
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
    public int selectedTower;
    public bool isBuilding;

    public void Build() { BuildMenu.SetActive(true); StandardMenu.SetActive(false); }
	public void Cancel() { BuildMenu.SetActive(false); StandardMenu.SetActive(true); isBuilding = false; mouseInd.SetActive(false);}
	public void CancelIn() { BuildMenu.SetActive(true);  cancelMenu.SetActive(false); isBuilding = false; mouseInd.SetActive(false);}
	public void BuildX(int x) { BuildMenu.SetActive(false); cancelMenu.SetActive(true); isBuilding = true; selectedTower = x;  mouseInd.SetActive(true);}

    private void Update()
    {

        if (isBuilding) {

            mouseInd.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return)) {

                GameObject temp = PhotonNetwork.Instantiate(Towers[selectedTower], mouseInd.transform.position, Quaternion.identity);
                temp.GetComponent<SpriteRenderer>().color = stats.playerColor;
                temp.GetComponent<TowerStat>().owner = stats;
            
            }
			else if(Input.GetKeyDown(KeyCode.A)){

				mousInd.transofm.Translate(-1. 0, 0);

			}
			else if(Input.GetKeyDown(KeyCode.D)){

				mousInd.transofm.Translate(1. 0, 0);

			}
			else if(Input.GetKeyDown(KeyCode.S)){

				mousInd.transofm.Translate(0. 0, -1);

			}
			else if(Input.GetKeyDown(KeyCode.W)){

				mousInd.transofm.Translate(0. 0, 1);

			}

        }

    }

}
