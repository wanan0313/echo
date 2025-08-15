using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DirectTeleport : MonoBehaviour
{
    public GameObject platformA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // ����Ƿ�����Ҵ��Ϸ���ײ
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // ���Ϸ���ײ
        {
            Teleport(collision.gameObject);
        }
    }
    public void Teleport(GameObject player)
    {

        if (player != null)
        {

            Vector3 targetPosition = platformA.transform.position;
            targetPosition.y += player.transform.localScale.y; // ȷ�����վ�ڷ�����

            // �������
            player.transform.position = targetPosition;

        }
    }
}
