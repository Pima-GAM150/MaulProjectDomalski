using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * to clarify def type vs attack type i've built myself this handy dandy chart Damage reduction
 * 	++ = 50% dmg, + = 75% dmg, | = 100% dmg, - = 150% dmg, -- = 200% dmg
 * 
 * 		def:	light	|	medium	|	heavy	|	fortified
 * atk		|			|			|			|
 * normal	|	  +		|	  |		|	  -		|	  --
 * piercing	|	  -		|	  +		|	  +		|	  -
 * crushing	|	 --		|     /		|	  +		|	  ++
 * heroic	|	  +		|	  +		|	  +		|	  |
 * 
 * 	i.e. if a normal attack of 20 hits a medium def of 5, the outcome is (20 - (5 * 1.00)) = 15 dmg
 * if a piercing attack of 20 hits a heavy def of 5, the outcome is (20 - (5 * 0.75)) = 18.75, rounds down to 18 dmg
 * 
 */

public class EnemyStat : MonoBehaviour
{
   
	public int hp;	// amount of hp
	public int def;	// type of defense (0 - light, 1 - medium, 2 - heavy, 3 - fortified)
	public int defMagnitude;	// amount of def, determines damage reduction

}
