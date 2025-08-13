using UnityEngine;

public class FezCameraController : MonoBehaviour
{
    public Transform target; // 玩家角色
    public float rotationSpeed = 90f; // 每次旋转的角度(90度)
    public float smoothTime = 0.3f; // 旋转平滑时间
    private bool is2D =false;
    public GameObject[] hiddenangles;

    private Vector3[] viewDirections = {
        new Vector3(0, 0, -1),  // 前
        new Vector3(1, 0, 0),   // 右
        new Vector3(0, 0, 1),   // 后
        new Vector3(-1, 0, 0)    // 左
    };

    [HideInInspector] public int currentViewIndex;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        currentViewIndex = 2;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentViewIndex = (currentViewIndex + 3) % 4; // 逆时针
            RotateCamera();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentViewIndex = (currentViewIndex + 1) % 4; // 顺时针
            RotateCamera();
        }
        bool isRightView = viewDirections[currentViewIndex] == new Vector3(1, 0, 0);
        hiddenangles[0].SetActive(isRightView);//右

        bool isLeftView = viewDirections[currentViewIndex] == new Vector3(-1, 0, 0);
        hiddenangles[1].SetActive(isLeftView);//左

        bool isFrontView = viewDirections[currentViewIndex] == new Vector3(0, 0, -1);
        hiddenangles[2].SetActive(isFrontView);//前

        bool isBackView = viewDirections[currentViewIndex] == new Vector3(0, 0, 1);
        hiddenangles[3].SetActive(isBackView);//后
        
        // 平滑跟随玩家
        Vector3 targetPosition = target.position - viewDirections[currentViewIndex] * 10;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // 始终看向玩家
        transform.LookAt(target);
    }

    void RotateCamera()
    {
        GameObject[] tempGround = GameObject.FindGameObjectsWithTag("TempGround");
        foreach (GameObject go in tempGround)
        {
            if (go.GetComponent<DisappearingPlatformA>() != null)
            {
                if (go.GetComponent<DisappearingPlatformA>().onPlatform)
                {
                    go.GetComponent<DisappearingPlatformA>().Teleport(target.gameObject);
                }
            }
            if (go.GetComponent<TransmitPlatform>() != null)
            {
                if (go.GetComponent<TransmitPlatform>().onPlatform)
                {
                    go.GetComponent<TransmitPlatform>().Teleport(target.gameObject,currentViewIndex);
                }
            }
        }
    }
}