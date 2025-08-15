using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destroy;
    public void BallCrash()
    {

        StartCoroutine(waitSecondsBeforeCrash());
    }
    IEnumerator waitSecondsBeforeCrash()
    {
        yield return new WaitForSeconds(3);
        Instantiate(destroy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
