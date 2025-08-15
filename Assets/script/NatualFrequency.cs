using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class NatualFrequency : MonoBehaviour
{
    public Slider slider;
    public DestroyBall ball;
    public GameObject smashtext;
    public int max;
    public int min;
    public bool isRandom;
    bool isdone;
    bool inRange;
    bool isCounting;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (isRandom)
        {
            max = Random.Range(10, 100);
            min = max - 10;
        }
        transform.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0.1f), 5, 90, false, false).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        //float target = Mathf.Abs(slider.value - (max + min) / 2) / 100;

        if (inRange&&!isCounting)
        {
            StartShake();
        }
        if (!inRange)
        {
            timer = 0;
            isCounting = false;
            return;
        }
        if (isCounting)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                ball.BallCrash();
                smashtext.SetActive(false);
                transform.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0.1f), 5, 90, false, false).SetLoops(-1);
            }
        }
    }
    public void StartShake()
    {
        transform.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0.1f), 40, 60, false, false).SetLoops(-1);
        isCounting = true;
        
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

