using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BasicCameraFollow : MonoBehaviour
{
    public Transform player;  // ���Transform
    public Vector3 offset = new Vector3(0, 2, -10);  // ���ƫ����
    public float smoothSpeed = 5f;  // ����ƽ����

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
        transform.position = smoothedPosition;

        //transform.LookAt(player);  // ʼ�տ������
    }
}