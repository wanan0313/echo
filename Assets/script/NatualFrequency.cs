using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NatualFrequency : MonoBehaviour
{
    public Slider slider;
    public DestroyBall ball;
    public GameObject smashtext;

    bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        
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
            }
        }
    }
 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && slider.value<40 && slider.value>30)
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

