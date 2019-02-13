using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 target;

    private void Update()
    {

        transform.Translate(target * Time.deltaTime * 10);

    }

}
