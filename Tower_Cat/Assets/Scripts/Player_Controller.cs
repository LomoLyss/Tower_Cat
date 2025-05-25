using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5.0f;
    [SerializeField] float RotationSpeed = 500.0f;
    [Header("Ground Check Settings")]
    [SerializeField] float GroundCheckRadius = 0.2f;
    [SerializeField] Vector3 GroundCheckOffset;
    [SerializeField] LayerMask GroundLayer;

    bool isGrounded;
    float ySpeed;

    Quaternion targetRotation;

    Camera_Controller cameraController;
    Animator animator;
    CharacterController characterController;
    private void Awake()
    {
        //Getting components from engine
       cameraController = Camera.main.GetComponent<Camera_Controller>();
       animator = GetComponent<Animator>();
       characterController = GetComponent<CharacterController>();
        //character controller radius and ground radius need to be the same or close
       
    }
    private void Update()
    {
        //Defining axis
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //limiting movement amount
        float MoveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        //determining movement
        var MoveInput = (new Vector3(h, 0, v)).normalized;
        var MoveDir = cameraController.PlanerRotation * MoveInput;
        var velocity = MoveDir * MoveSpeed;
        velocity.y = ySpeed;

        //are they on ground
        GroundCheck();
        characterController.Move( velocity * Time.deltaTime);

        if (isGrounded)
        {
            //if not falling dont count velocity
            ySpeed = 0.05f;
        }
        else
        {
            //if falling apply gravity
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        //player rotation
        if (MoveAmount > 0)
        {
            
            
            targetRotation = Quaternion.LookRotation(MoveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        animator.SetFloat("moveAmount", MoveAmount, 0.2f, Time.deltaTime);
    }

    void GroundCheck()
    {
        
        Debug.Log("IsGrounded =" + isGrounded);
        isGrounded = Physics.CheckSphere(transform.TransformPoint(GroundCheckOffset), GroundCheckRadius, GroundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        //creating green grounding gizmo
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(GroundCheckOffset), GroundCheckRadius);
    }

}
