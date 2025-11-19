using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public CubeManager cubeManager;   
    public Camera mainCamera;        

    [Header("Camera Movement Settings")]
    public float distancePerCube = 0.2f; 
    public float baseDistance = 10f;     
    public float smoothSpeed = 5f;       

    private float targetZ;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (cubeManager == null)
            Debug.LogWarning("CameraAutoZoom: CubeManager reference not set!");

        UpdateCameraTarget();
    }

    private void Update()
    {
        Vector3 pos = mainCamera.transform.position;
        pos.z = Mathf.Lerp(pos.z, targetZ, smoothSpeed * Time.deltaTime);
        mainCamera.transform.position = pos;
    }


    public void UpdateCameraTarget()
    {
        if (cubeManager == null) return;

        int cubeCount = cubeManager.cubeAmount;

        targetZ = -(baseDistance + cubeCount * distancePerCube);
    }
}
