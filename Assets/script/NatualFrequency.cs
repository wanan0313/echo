using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NatualFrequency : MonoBehaviour
{
    public Slider slider;
    public DestroyBall ball;
    public GameObject smashtext;
    public int max;
    public int min;
    public bool isRandom;

    bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        if (isRandom)
        {
            max = Random.Range(10, 100);
            min = max - 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(1);
                ball.BallCrash();
                smashtext.SetActive(false);
            }
        }
    }
 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && slider.value<max && slider.value>min)
        {
            smashtext.SetActive(true);
            inRange = true;
            
                
        }
        else
        {
            smashtext.SetActive(false);
            inRange = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            smashtext.SetActive(false);
            inRange = false;

        }
    }
}

