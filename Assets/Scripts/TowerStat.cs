using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStat : MonoBehaviour
{
    
	public int dmg;		// amount of damage sent to target
	public int atk;		// type of damage (used for damage reduction calculation) (0 - normal, 1 - piercing, 2 - crushing, 3 - heroic)
	public int range;	// how far the tower can attack, 1 point of range correlates to 1 grid pace of range (with most towers being 2x2)
	public float spd;	// how fast the tower attacks, higher = faster, 1 = 1 atk ps, 2 = 2 atk ps, etc

	public int fx;		// what effect the tower might employ (requires further thought)
	public float fxMagnitude; // how powerful/long the effect lasts

	public PlayerStat owner;

}
