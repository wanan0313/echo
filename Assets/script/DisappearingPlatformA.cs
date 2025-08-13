using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisappearingPlatformA : MonoBehaviour
{
    public GameObject platformA;
    public float disappearDelay = 0.5f; // ��ʧ�ӳ�ʱ��
    public float teleportDelay = 0.5f; // �����ӳ�ʱ��
    public bool onPlatform;
    private void OnCollisionEnter(Collision collision)
    {
        // ����Ƿ�����Ҵ��Ϸ���ײ
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // ���Ϸ���ײ
        {
            onPlatform = true ;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // ����Ƿ�����Ҵ��Ϸ���ײ
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // ���Ϸ���ײ
        {
            onPlatform = false;
        }
    }
    public void Teleport(GameObject player)
    {
        if (platformA != null && player != null)
        {
            // ��ȡ����B��λ�ã����Լ���ƫ������
            Vector3 targetPosition = platformA.transform.position;
            targetPosition.y += player.transform.localScale.y / 2f; // ȷ�����վ�ڷ�����

            // �������
            player.transform.position = targetPosition;          
        }
    }
}
