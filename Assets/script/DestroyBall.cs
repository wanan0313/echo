using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destroy;
    public void BallCrash()
    {

        Instantiate(destroy, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
