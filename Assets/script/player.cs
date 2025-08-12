using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    [Header("Jump")]
    public float jumpForce = 8f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private FezCameraController cameraController;
    public Rigidbody rb;
    private bool isGrounded;
    public Animator animator;

    void Start()
    {
        // 获取相机控制器（确保相机挂载了FezCameraController脚本）
        cameraController = Camera.main.GetComponent<FezCameraController>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }
    void HandleMovement()
    {
        if (cameraController == null) return;

        // 根据当前视角方向计算移动轴
        Vector3 moveDirection = GetMovementDirection();

        if (moveDirection.magnitude > 0.1f)
        {
            transform.Translate(-moveDirection.normalized * speed * Time.deltaTime, Space.World);
        }
    }
    void HandleJump()
    {
        // 地面检测（从脚部向下发射射线）
        isGrounded = Physics.Raycast(
            groundCheck.position,
            Vector3.down,
            groundCheckDistance,
            groundLayer

        );

        //Debug.Log(isGrounded);

        // 跳跃输入（空格键）
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(rb.velocity);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            print("111");
        }
    }


    Vector3 GetMovementDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // 根据当前视角方向返回移动向量（修正反向问题）
        switch (cameraController.currentViewIndex)
        {
            case 0: // 前视角：A=左，D=右
                return new Vector3(horizontalInput, 0, 0);
            case 1: // 右视角：A=远离相机（负Z），D=靠近相机（正Z）
                return new Vector3(0, 0, horizontalInput);
            case 2: // 后视角：A=右，D=左（需要反转）
                return new Vector3(-horizontalInput, 0, 0);
            case 3: // 左视角：A=靠近相机（正Z），D=远离相机（负Z）
                return new Vector3(0, 0, -horizontalInput);
            default:
                return Vector3.zero;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
