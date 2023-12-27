using UnityEngine;
// using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    private const float sensitivity = 4;
    private const float speed = 10;

    private const float camera_y_max = 5.0f;
    private const float camera_y_min = 1.0f;

    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        // Move the camera forward, backward, left, and right
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Honor scene bounds
        float temp_max_x = MainScene.max_x;
        float temp_max_z = MainScene.max_z;

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
        
        if (Camera.main.transform.position.x > temp_max_x)
        {
            Camera.main.transform.position =
                new Vector3(temp_max_x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        if (Camera.main.transform.position.x < -temp_max_x)
        {
            Camera.main.transform.position =
                new Vector3(-temp_max_x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        
        if (Camera.main.transform.position.z > temp_max_z)
        {
            Camera.main.transform.position =
                new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, temp_max_z);
        }
        if (Camera.main.transform.position.z < -temp_max_z)
        {
            Camera.main.transform.position =
                new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -temp_max_z);
        }
        
        // Rotate the camera based on the mouse movement
        if (Input.GetMouseButton(1)){
            // Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
        }

        else if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }

    }
}
