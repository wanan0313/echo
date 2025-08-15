using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BasicCameraFollow : MonoBehaviour
{
    public Transform player;  // 玩家Transform
    public Vector3 offset = new Vector3(0, 2, -10);  // 相机偏移量
    public float smoothSpeed = 5f;  // 跟随平滑度

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

        //transform.LookAt(player);  // 始终看向玩家
    }
}