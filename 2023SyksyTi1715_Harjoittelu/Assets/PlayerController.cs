using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4.5f;
    public CharacterController controller;
    public float mouseSpeed = 3f;
    public CursorLockMode cursorLock;
    private float mouseMovementX = 0f;
    private float mouseMovementY = 0f;
    Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = cursorLock;
        Cursor.visible =(CursorLockMode.Locked != cursorLock);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        mouseMovementX += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseMovementY -= Input.GetAxis("Mouse Y") * mouseSpeed;

        Camera.main.transform.localRotation = Quaternion.Euler(mouseMovementY, 0, 0);

        transform.localRotation = Quaternion.Euler(0,mouseMovementX,0);

        moveDir = new Vector3(horizontal,0,vertical);
        moveDir = transform.rotation * moveDir;

        controller.SimpleMove(moveDir * moveSpeed);

    }
}
