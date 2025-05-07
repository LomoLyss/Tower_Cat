using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float distance = 5;
    [SerializeField] bool invertX;
    [SerializeField] bool invertY;

    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;

    [SerializeField] Vector2 FramingOffset;

    float rotateX;
    float rotateY;

    float invertXVal;
    float invertYVal;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotateY += Input.GetAxis("Mouse X") * rotationSpeed;
        rotateX += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotateX = Mathf.Clamp(rotateX, minVerticalAngle, maxVerticalAngle);

        var TargetRotation = Quaternion.Euler(rotateX, rotateY, 0);
        var FocusPosition = followTarget.position + new Vector3(FramingOffset.x,FramingOffset.y);

        transform.position = FocusPosition - TargetRotation * new Vector3(0, 0, distance);
        transform.rotation = TargetRotation;

    }
}
