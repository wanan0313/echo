using UnityEngine;

public class FezCameraController : MonoBehaviour
{
    public Transform target; // ��ҽ�ɫ
    public float rotationSpeed = 90f; // ÿ����ת�ĽǶ�(90��)
    public float smoothTime = 0.3f; // ��תƽ��ʱ��
    private bool is2D =false;
    public GameObject[] hiddenangles;

    private Vector3[] viewDirections = {
        new Vector3(0, 0, -1),  // ǰ
        new Vector3(1, 0, 0),   // ��
        new Vector3(0, 0, 1),   // ��
        new Vector3(-1, 0, 0)    // ��
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
            currentViewIndex = (currentViewIndex + 3) % 4; // ��ʱ��
            RotateCamera();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentViewIndex = (currentViewIndex + 1) % 4; // ˳ʱ��
            RotateCamera();
        }
        bool isRightView = viewDirections[currentViewIndex] == new Vector3(1, 0, 0);
        hiddenangles[0].SetActive(isRightView);//��

        bool isLeftView = viewDirections[currentViewIndex] == new Vector3(-1, 0, 0);
        hiddenangles[1].SetActive(isLeftView);//��

        bool isFrontView = viewDirections[currentViewIndex] == new Vector3(0, 0, -1);
        hiddenangles[2].SetActive(isFrontView);//ǰ

        bool isBackView = viewDirections[currentViewIndex] == new Vector3(0, 0, 1);
        hiddenangles[3].SetActive(isBackView);//��
        
        // ƽ���������
        Vector3 targetPosition = target.position - viewDirections[currentViewIndex] * 10;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // ʼ�տ������
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