using UnityEngine; // 解决 Transform 找不到的问题

public class HelmetScale : MonoBehaviour
{
    public Transform helmetFront; // 头盔前端可伸缩部分
    public float scrollSpeed = 1f;
    public float minLength = 1f;
    public float maxLength = 3f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 scale = helmetFront.localScale;
            scale.z = Mathf.Clamp(scale.z + scroll * scrollSpeed, minLength, maxLength);
            helmetFront.localScale = scale;
        }
    }
}
