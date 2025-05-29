using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    [SerializeField] LayerMask CheckingLayer;
    [SerializeField] GameObject Casting_Object;
    public float range = 100f;
    public float offset = 0.01f;
    public BoxCollider Casting_Box;
    public Ray ray;
    public RaycastHit hit;
    // Vector3 Rayoffset;



    //CharacterController characterController;

    private void Awake()
    {
        Casting_Object = gameObject;
        Casting_Box = Casting_Object.gameObject.GetComponent<BoxCollider>();
        
    }

    void Update()
    {

        
        Ray ray = new Ray(Casting_Object.transform.position, Casting_Object.transform.forward);
        Casting_Box.Raycast(ray, out hit, range);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Input.GetKeyDown("e"))
        {
            Debug.Log("Key Down");
            if(Physics.Raycast(ray, out hit, CheckingLayer))
            {
                Debug.Log("Found Object");
            }
        }

    }

   
}
