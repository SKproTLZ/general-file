using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_movement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform PlayerBody; //make camera sync to the player

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        /*Cursor.lockState = CursorLockMode.Locked; //lock cursor */
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //make sure to not over rotate

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        PlayerBody.Rotate(Vector3.up * mousex);
        
    }
}
