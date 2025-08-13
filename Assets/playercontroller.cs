using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 5f;
    public CharacterController controller; // �������CharacterController�ƶ�

    void Update()
    {
        // ��·�߼�����ѡ��
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        controller.Move(move * walkSpeed * Time.deltaTime);

        animator.SetBool("isWalking", move.magnitude > 0.1f);

        // ������ -> Adjust
        if (Input.mouseScrollDelta.y != 0)
        {
            animator.SetTrigger("Trigger_Adjust");
        }

        // ������ -> Smash
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Trigger_Smash");
        }

        // �ո� -> Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Trigger_Jump");
        }
    }
}
