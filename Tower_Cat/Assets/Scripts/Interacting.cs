using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    [SerializeField] LayerMask LayerMask;
   // [SerializeField] GameObject Object;
    public float range = 100f;

    CharacterController characterController;
    RaycastHit hit;
    
    void Update()
    {
        characterController = GetComponent<CharacterController>();
        Ray ray = new Ray(characterController.transform.position, characterController.transform.forward);
        characterController.Raycast(ray, out hit, range);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
}
