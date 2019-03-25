using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

	public float cameraspeed;
    
    void Update()
    {
        
		if(Input.GetKey(KeyCode.Up)){

			transform.Translate(new Vector3(0, 0, Time.deltaTime* cameraspeed));

		}
		if(Input.GetKey(KeyCode.Down)){

			transform.Translate(new Vector3(0, 0, Time.deltaTime* cameraspeed * -1));

		}
		if(Input.GetKey(KeyCode.Right)){

			transform.Translate(new Vector3(Time.deltaTime* cameraspeed, 0, 0));

		}
		if(Input.GetKey(KeyCode.Left)){

			transform.Translate(new Vector3(Time.deltaTime* cameraspeed * -1, 0, 0));

		}

    }

}
