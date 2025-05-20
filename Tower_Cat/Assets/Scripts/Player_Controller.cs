using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5.0f;
    [SerializeField] float RotationSpeed = 500.0f;

    Quaternion targetRotation;

    Camera_Controller cameraController;
    Animator animator;
    private void Awake()
    {
       cameraController = Camera.main.GetComponent<Camera_Controller>();
       animator = GetComponent<Animator>();
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
            transform.position += MoveDir * MoveSpeed * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(MoveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        animator.SetFloat("moveAmount", MoveAmount, 0.2f, Time.deltaTime);
    }
}
