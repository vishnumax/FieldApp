using Unity.Cinemachine;
using UnityEngine;

public class LookCam : MonoBehaviour
{
    [Header("Cinemachine")]
    public CinemachineCamera orbitCam;                       // New CinemachineCamera
    public CinemachineCamera otherCam;                       // Optional: another camera to switch
    public KeyCode switchKey = KeyCode.C;

    [Header("Target & Orbit")]
    public Transform target;
    public float distance = 5f;                              // Initial zoom distance
    public float xSpeed = 120f;
    public float ySpeed = 120f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    [Header("Zoom")]
    public float zoomSpeed = 5f;
    public float minDistance = 2f;
    public float maxDistance = 15f;

    [Header("Pan")]
    public float panSpeed = 0.5f;

    private float x, y;
    [SerializeField] CinemachineCameraOffset camOffset;

    void Start()
    {
        if (orbitCam == null)
            orbitCam = GetComponent<CinemachineCamera>();

        camOffset = orbitCam.GetComponent<CinemachineCameraOffset>();
        if (camOffset == null)
            camOffset = orbitCam.gameObject.AddComponent<CinemachineCameraOffset>();

        // Default offset (Z = -distance)
        camOffset.Offset = new Vector3(0, 0, -distance);

        if (target == null)
        {
            GameObject t = new GameObject("Orbit Target");
            t.transform.position = Vector3.zero;
            target = t.transform;
        }

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void Update()
    {
         HandlePan();
    }

    void LateUpdate()
    {
        HandleOrbit();
        HandleZoom();
       
        HandlePrioritySwitch();
        UpdateCameraRig();
    }

    void HandleOrbit()
    {
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.0001f)
        {
            // Adjust the Z offset to zoom in/out
            Vector3 offset = camOffset.Offset;
            offset.z = Mathf.Clamp(offset.z - scroll * zoomSpeed, -maxDistance, -minDistance);
            camOffset.Offset = offset;
        }
    }

    void HandlePan()
    {
        if (Input.GetMouseButton(2))
        {
            float panX = -Input.GetAxis("Mouse X") * panSpeed;
            float panY = -Input.GetAxis("Mouse Y") * panSpeed;

            Vector3 offset = camOffset.Offset;
            offset.x += panX;
            offset.y += panY;
            camOffset.Offset = offset;

            // Debug log to verify the value is actually changing
            Debug.Log($"Offset updated: {camOffset.Offset}");
        }
    }

    void HandlePrioritySwitch()
    {
        if (orbitCam == null) return;

        if (Input.GetKeyDown(switchKey))
        {
            int currentPriority = orbitCam.Priority;

            if (otherCam != null)
            {
                int otherPriority = otherCam.Priority;
                orbitCam.Priority = otherPriority;
                otherCam.Priority = currentPriority;
            }
            else
            {
                orbitCam.Priority = (currentPriority == 10) ? 0 : 10;
            }
        }
    }

    void UpdateCameraRig()
    {
        // Update orbit camera position around target (rotation only)
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        transform.rotation = rotation;
        transform.position = target.position;
    }


    public void SetDrop(bool enable)
    {
        orbitCam.Priority = enable ? 20 : 10;
    }

}
