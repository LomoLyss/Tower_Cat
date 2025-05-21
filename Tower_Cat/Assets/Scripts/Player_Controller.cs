using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5.0f;
    [SerializeField] float RotationSpeed = 500.0f;
    [SerializeField] float GroundCheckRadius = 0.2f;
    [SerializeField] Vector3 GroundCheckOffset;
    [SerializeField] LayerMask GroundLayer; 

    Quaternion targetRotation;

    Camera_Controller cameraController;
    Animator animator;
    CharacterController characterController;
    private void Awake()
    {
       cameraController = Camera.main.GetComponent<Camera_Controller>();
       animator = GetComponent<Animator>();
       characterController = GetComponent<CharacterController>();
       
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float MoveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var MoveInput = (new Vector3(h, 0, v)).normalized;
        var MoveDir = cameraController.PlanerRotation * MoveInput;

        if (MoveAmount > 0)
        {
            characterController.Move(MoveDir * MoveSpeed * Time.deltaTime);
            
            targetRotation = Quaternion.LookRotation(MoveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        animator.SetFloat("moveAmount", MoveAmount, 0.2f, Time.deltaTime);
    }

    void GroundCheck()
    {
        Physics.CheckSphere(transform.TransformPoint(GroundCheckOffset), GroundCheckRadius, GroundLayer);
    }
}
