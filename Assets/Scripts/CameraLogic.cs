using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public float tiltAngle = 0f;

    public float mouseSens = 100f;

    public float mouseVert, mouseHorz;

    public Transform playerCan;

    public Transform cameraObject;

    public float rotateSpeed, swivelAngle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        mouseVert = Input.GetAxis("Mouse Y") * mouseSens;
        mouseHorz = Input.GetAxis("Mouse X") * mouseSens;

    }

    public void FixedUpdate()
    {
        swivelAngle += mouseHorz * rotateSpeed;
        tiltAngle += mouseVert * rotateSpeed;

        //Debug.Log("Swivel : " + swivelAngle);
        //Debug.Log("tilt : " + tiltAngle);

        tiltAngle = Mathf.Clamp(tiltAngle, -45, 45);

        Vector3 eulerRot = new Vector3(-swivelAngle, tiltAngle, 0);

        //playerCan.position = Vector3.Lerp(playerCan.position, cameraObject.position, 0.1f);
        //cameraObject.Rotate(tiltAngle, 0, 0);
        playerCan.Rotate(0, swivelAngle, 0);

        //Debug.Log(eulerRot);
    }

        //tiltAngle -= mouseVert;
        //tiltAngle = Mathf.Clamp(tiltAngle, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(0f, tiltAngle, 0f);
        //playerCan.Rotate(Vector3.right* mouseHorz);
}
