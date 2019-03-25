using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
	public static Transform Red, Blue, Teal, Orange, Purple, Yellow, Green, Pink, Gray;
	public Transform Reds, Blues, Teals, Oranges, Purples, Yellows, Greens, Pinks, Grays;

	void Start(){

		Red = Reds;
		Blue = Blues;
		Teal = Teals;
		Orange = Oranges;
		Purple = Purples;
		Yellow = Yellows;
		Green = Greens;
		Pink = Pinks;
		Gray = Grays;

	}

}
