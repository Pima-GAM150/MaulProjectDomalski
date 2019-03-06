using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    
	public int playerNum;	// player number (as a weird decision, player numbers have been reversed from standard rules) (any number greater than 9 will be considered a spectator)
	public Color playerColor; // color assoiciated with player (follows standard 9 player wintermaul rules)

	public int type; // what series of towers that player is able to build, (0 - none has to choose, 1 - tech ) more races will be added if/when developed
	public int gold; // amount of currency the player has available

}
