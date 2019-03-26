using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
	public Text time;
	public PlayerStat player;

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		if(stream.IsWriting){

			stream.SendNext(timer);
			stream.SendNext(lives);

		}
		else{

			timer = (float)stream.ReceiveNext();
			lives = (int)stream.ReceiveNext();
		}

	}

	void Update(){

		timer += Time.deltaTime;

		if(inwave){

			time.gameObject.SetActive(false);

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

			time.gameObject.SetActive(true);
			time.text = "" + timer;

			if(timer > 30f){

				curWave = PhotonNetwork.Instantiate(waves[wave].name, new Vector3(), Quaternion.identity);

			}

		}

	}

}
