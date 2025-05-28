using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    [SerializeField] LayerMask LayerMask;
   // [SerializeField] GameObject Object;
    public float range = 100f;
    public float offset = 0.01f;
   // Vector3 Rayoffset;
    

    CharacterController characterController;
    RaycastHit hit;
    
    void Update()
    {

       // Rayoffset = new Vector3(0f,offset,0f);
        characterController = GetComponent<CharacterController>();
        Ray ray = new Ray(characterController.transform.position, characterController.transform.forward);
        characterController.Raycast(ray, out hit, range);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
}
