using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemyManager : MonoBehaviour
{

	public EnemyStat target;
	public List<EnemyStat> targets;
    
	void OnTriggerEnter(Collider hit){

		if(hit.tag.Equals("Enemy")){
			
			if(target == null)
				target = hit.gameObject.GetComponent<EnemyStat>();
			else
				targets.Add(hit.gameObject.GetComponent<EnemyStat>());
					
		}

	}

	void OnTriggerExit(Collider hit){

		if(hit.tag.Equals("Enemy")){
			if(hit.gameObject == target.gameObject){

				foreach(EnemyStat x in targets){

					if(x == null)
						targets.Remove(x);

				}

				if(targets.Count > 0)
					target = targets[0];
				else
					target = null;

			}else{

				targets.Remove(hit.gameObject.GetComponent<EnemyStat>());

			}
		}

	}

}
