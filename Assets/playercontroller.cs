using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 5f;
    public CharacterController controller; // 如果你用CharacterController移动

    void Update()
    {
        // 走路逻辑（可选）
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        controller.Move(move * walkSpeed * Time.deltaTime);

        animator.SetBool("isWalking", move.magnitude > 0.1f);

        // 鼠标滚轮 -> Adjust
        if (Input.mouseScrollDelta.y != 0)
        {
            animator.SetTrigger("Trigger_Adjust");
        }

        // 鼠标左键 -> Smash
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Trigger_Smash");
        }

        // 空格 -> Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Trigger_Jump");
        }
    }
}
