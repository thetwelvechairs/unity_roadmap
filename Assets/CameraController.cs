using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float sensitivity = 2;
    const float speed = 10;
    private const float camera_y_max = 5.0f;
    private const float camera_y_min = 1.0f;

    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Move the camera forward, backward, left, and right
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (Camera.main.transform.position.y < camera_y_min)
        {
            Camera.main.transform.position =
                new Vector3(Camera.main.transform.position.x, camera_y_min, Camera.main.transform.position.z);
        }
        if (Camera.main.transform.position.y > camera_y_max)
        {
            Camera.main.transform.position =
                new Vector3(Camera.main.transform.position.x, camera_y_max, Camera.main.transform.position.z);
        }
        
        if (Camera.main.transform.position.x > MainScene.max_x)
        {
            Camera.main.transform.position =
                new Vector3(MainScene.max_x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        
        if (Camera.main.transform.position.x < -MainScene.max_x)
        {
            Camera.main.transform.position =
                new Vector3(-MainScene.max_x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        
        if (Camera.main.transform.position.z > MainScene.max_z)
        {
            Camera.main.transform.position =
                new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, MainScene.max_z);
        }
        
        if (Camera.main.transform.position.z < -MainScene.max_z)
        {
            Camera.main.transform.position =
                new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -MainScene.max_z);
        }
        
        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
        
    }
}
