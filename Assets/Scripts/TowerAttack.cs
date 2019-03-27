using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TowerAttack : MonoBehaviourPunCallbacks
{
	
	public TowerEnemyManager targeter;
	public TowerStat stats;
	public GameObject bullet;
	//public bool isPlayer; // adding online functionality later (because I am horribly confused), this determines if this this specific script belongs to this comp
	public float timer;

    private void Start()
    {
        Destroy(gameObject.GetComponent<PhotonTransformView>());
        Destroy(photonView);


    }



    void Update(){



		if(timer >= 1 && targeter.target != null){

			GameObject x = Instantiate(bullet, transform.position, Quaternion.identity);
			x.GetComponent<Bullet>().target = targeter.target.transform.position;

			int dmg = stats.dmg;
			float mod = 1.0f;

			switch(stats.atk){

				case 0:
				switch(targeter.target.def){

					case 0:
					mod = 1.5f;
					break;
					case 2:
					mod = 0.75f;
					break;
					case 3:
					mod = 0.5f;
					break;
					default:
					break;

				}
				break;
				case 1:
				switch(targeter.target.def){

				case 0:
					mod = 0.75f;
					break;
				case 1:
					mod = 1.5f;
					break;
				case 2:
					mod = 1.5f;
					break;
				case 3:
					mod = 0.75f;
					break;
				default:
					break;

				}
				break;
				case 2:
				switch(targeter.target.def){

				case 0:
					mod = 0.5f;
					break;
				case 2:
					mod = 1.5f;
					break;
				case 3:
					mod = 2f;
					break;
				default:
					break;

				}
				break;
				case 3:
				switch(targeter.target.def){

				case 0:
					mod = 1.5f;
					break;
				case 2:
					mod = 1.5f;
					break;
				case 1:
					mod = 1.5f;
					break;
				default:
					break;

				}
				break;
				default:
				break;

			}

			dmg = dmg - (int)(mod * (float)targeter.target.defMagnitude);
			targeter.target.hp = targeter.target.hp - dmg;

			if(targeter.target.hp <= 0){

				stats.owner.gold += targeter.target.goldValue;
				//PhotonView tar
				targeter.target.Death();

			}

			timer = 0;

		}

		timer += Time.deltaTime * stats.spd;

	}

}
