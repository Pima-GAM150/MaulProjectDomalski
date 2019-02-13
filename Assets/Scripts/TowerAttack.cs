using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
	
	public TowerEnemyManager targeter;
	public TowerStat stats;
	public GameObject bullet;
	public bool isPlayer; // adding online functionality later (because I am horribly confused), this determines if this this specific script belongs to this comp
	public float timer;

	void Update(){


		if(isPlayer && timer >= 1 && targeter.target != null){

			GameObject x = Instantiate(bullet, transform, Quaternion.Identity);
			x.GetComponent<Bullet>().target = targeter.target.transform.position;

			int dmg = stats.dmg;
			float mod = 1.0;

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
				targeter.target.Death();

			}

			timer = 0;

		}

		timer += Time.deltaTime * stats.spd;

	}

}
