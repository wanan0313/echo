using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransmitPlatform : MonoBehaviour
{
    public GameObject platformA;
    public int cameraIndexA;
    public GameObject platformB;
    public int cameraIndexB;
    public float disappearDelay = 0.5f; // ��ʧ�ӳ�ʱ��
    public float teleportDelay = 0.5f; // �����ӳ�ʱ��
    public bool onPlatform;
    private void OnCollisionEnter(Collision collision)
    {
        // ����Ƿ�����Ҵ��Ϸ���ײ
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // ���Ϸ���ײ
        {
            onPlatform = true;
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
    public void Teleport(GameObject player, int targetIndex)
    {
        Debug.Log(targetIndex);
        if (platformA != null && player != null)
        {
            if (targetIndex == cameraIndexA)
            {
                Debug.Log(111111);
                // ��ȡ����B��λ�ã����Լ���ƫ������
                Vector3 targetPosition = platformA.transform.position;
                targetPosition.y += player.transform.localScale.y / 2f; // ȷ�����վ�ڷ�����

                // �������
                player.transform.position = targetPosition;
            }
            else if (targetIndex == cameraIndexB)
            {// ��ȡ����B��λ�ã����Լ���ƫ������
                Vector3 targetPosition = platformB.transform.position;
                targetPosition.y += player.transform.localScale.y / 2f; // ȷ�����վ�ڷ�����

                // �������
                player.transform.position = targetPosition;
            }


        }
    }
    private System.Collections.IEnumerator DisappearAndTeleport(GameObject player)
    {
        // �ӳٺ���ʧ
        yield return new WaitForSeconds(disappearDelay);

        // �ӳٺ������
        yield return new WaitForSeconds(teleportDelay);

        if (platformB != null && player != null)
        {
            // ��ȡ����B��λ�ã����Լ���ƫ������
            Vector3 targetPosition = platformB.transform.position;
            targetPosition.y += player.transform.localScale.y / 2f; // ȷ�����վ�ڷ�����

            // �������
            player.transform.position = targetPosition;
            Debug.Log(targetPosition);
            // ��ѡ�����Ŵ�����Ч
            // Instantiate(teleportEffect, player.transform.position, Quaternion.identity);
        }


    }
}
