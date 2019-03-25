using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

	public float cameraspeed;
    
    void Update()
    {
        
		if(Input.GetKey(KeyCode.UpArrow)){

			transform.Translate(new Vector3(0, Time.deltaTime* cameraspeed, 0));

		}
		if(Input.GetKey(KeyCode.DownArrow)){

			transform.Translate(new Vector3(0, Time.deltaTime* cameraspeed * -1), 0);

		}
		if(Input.GetKey(KeyCode.RightArrow)){

			transform.Translate(new Vector3(Time.deltaTime* cameraspeed, 0, 0));

		}
		if(Input.GetKey(KeyCode.LeftArrow)){

			transform.Translate(new Vector3(Time.deltaTime* cameraspeed * -1, 0, 0));

		}

    }

}
