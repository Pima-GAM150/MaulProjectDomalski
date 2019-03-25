using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviour, IPunObservable
{
    //public int curEnemies;
	public bool inwave = false;
    public int wave;
    public List<GameObject> waves;
	public GameObject curWave;
    public int lives;
	public float timer;
	public PlayerStat player;

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){



	}

	void Update(){

		timer += Time.deltaTime;

		if(inwave){

			if(timer > 10f){

				bool j = true;

				for(int i = 0; i < curWave.transform.childCount; i++){

					Transform temp = curWave.transform.GetChild(i);
					if(temp.childCount > 0)
						j = false;

				}

				if(j){

					inwave = false;

					player.gold = 20 + wave * 3;
					wave++;

				}
				timer = 0;

			}

		}
		else{

			if(timer > 30f){



			}

		}

	}

}
