using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisappearingPlatformA : MonoBehaviour
{
    public GameObject platformA;
    public float disappearDelay = 0.5f; // 消失延迟时间
    public float teleportDelay = 0.5f; // 传送延迟时间
    public bool onPlatform;
    private void OnCollisionEnter(Collision collision)
    {
        // 检测是否是玩家从上方碰撞
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // 从上方碰撞
        {
            onPlatform = true ;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // 检测是否是玩家从上方碰撞
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // 从上方碰撞
        {
            onPlatform = false;
        }
    }
    public void Teleport(GameObject player)
    {
        if (platformA != null && player != null)
        {
            // 获取方块B的位置（可以加上偏移量）
            Vector3 targetPosition = platformA.transform.position;
            targetPosition.y += player.transform.localScale.y / 2f; // 确保玩家站在方块上

            // 传送玩家
            player.transform.position = targetPosition;          
        }
    }
}
