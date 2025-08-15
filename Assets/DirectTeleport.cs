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
        // 检测是否是玩家从上方碰撞
        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y < -0.5f) // 从上方碰撞
        {
            Teleport(collision.gameObject);
        }
    }
    public void Teleport(GameObject player)
    {

        if (player != null)
        {

            Vector3 targetPosition = platformA.transform.position;
            targetPosition.y += player.transform.localScale.y; // 确保玩家站在方块上

            // 传送玩家
            player.transform.position = targetPosition;

        }
    }
}
