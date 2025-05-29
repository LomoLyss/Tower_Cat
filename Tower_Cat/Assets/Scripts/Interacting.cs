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
    public GameObject Picked_Up_Object;
    // Vector3 Rayoffset;



    //CharacterController characterController;

    private void Awake()
    {
        // getting components from our empty casting object
        Casting_Object = gameObject;
        Casting_Box = Casting_Object.gameObject.GetComponent<BoxCollider>();
        CheckingLayer = LayerMask.GetMask("Interacting");
        
    }

    void Update()
    {

        // drawing ray from casting object
        Ray ray = new Ray(Casting_Object.transform.position, Casting_Object.transform.forward);
        Casting_Box.Raycast(ray, out hit, range);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        // on key press check if raycast is hitting an interactable object
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("Key Down");
            // raycast now checking
            if(Physics.Raycast(ray, out hit, range, CheckingLayer))
            {
                Debug.Log("Found Object");
                if(hit.collider)
                {
                    Picked_Up_Object = hit.collider.gameObject;
                    Picked_Up_Object.tag = "Interactable";
                    Picked_Up_Object.transform.SetParent(Casting_Object.transform);
                }

            }


        }

    }

   
}
