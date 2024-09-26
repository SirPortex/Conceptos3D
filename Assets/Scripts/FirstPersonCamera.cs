using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public float mouseSens, CameraLim;
    public Transform playerTransform;

    private float mouseYRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Desaparece el cursor.
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        mouseYRotation -= mouseY;

        if (CameraLim < mouseYRotation || -CameraLim > mouseYRotation )
        {
            mouseYRotation = Mathf.Clamp(mouseYRotation, -CameraLim, CameraLim);
        }
        else
        {
            transform.localEulerAngles = Vector3.right * mouseYRotation;
        }


        playerTransform.Rotate(Vector3.up * mouseX); // es lo mismo que "new Vector3 (0, mousex, 0)" que esta en el script de CC
    }
}
