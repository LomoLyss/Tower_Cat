using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    [SerializeField] LayerMask LayerMask;
    [SerializeField] GameObject Casting_Object;
    public float range = 100f;
    public float offset = 0.01f;
    public BoxCollider Casting_Box;
    // Vector3 Rayoffset;
    

    
    //CharacterController characterController;
    RaycastHit hit;

    private void Awake()
    {
        Casting_Object = gameObject;
        Casting_Box = Casting_Object.gameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
        
        Ray ray = new Ray(Casting_Object.transform.position, Casting_Object.transform.forward);
        

       // Rayoffset = new Vector3(0f,offset,0f);
       // characterController = GetComponent<CharacterController>();
       // Ray ray = new Ray(characterController.transform.position, characterController.transform.forward);
        Casting_Box.Raycast(ray, out hit, range);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

    }
}
