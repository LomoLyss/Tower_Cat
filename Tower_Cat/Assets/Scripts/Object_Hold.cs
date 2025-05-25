using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Hold : MonoBehaviour
{
    //public GameObject Object;
   // public Transform Raycast_Looking;
   // public Camera Camera;
    public float range = 5f;
    public float Go = 100f;
    
    
    

    [SerializeField] Camera Camera;
    [SerializeField] Transform Raycast_Looking;
    [SerializeField] GameObject Object;
    [SerializeField] LayerMask LayerMask;

    public void Awake()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("Key Down");
            // StartPickUp();
            RaycastHit hit;
            Ray ray = new Ray(Camera.transform.position,Camera.transform.forward);
           
            if(Physics.Raycast(ray, out hit, range, LayerMask))
            {
                Debug.Log(hit.collider);
            }

            else
            {
                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

                Debug.Log("Did not Hit");
            }
        }

        if (Input.GetKeyUp("e"))
        {
           // Drop();
        }
    }

    public void StartPickUp()
    {
        //Debug.Log("Pick up start");
       // RaycastHit hit;
        //if(Physics.Raycast(Camera.transform.position,Camera.transform.forward, out hit, range))
       // {
          //  Debug.DrawRay(Camera.transform.position, Camera.transform.forward,Color.green);
          //  Debug.Log("Raycast hit");
           // Target target = hit.transform.GetComponent<Target>();
            
           // Debug.Log("Target hit");

          //  if (target != null)
           // {
           //     Debug.Log("Pickup");
           //     PickUp();
           // }

          //  if (target = null)
          //  {
          //      Debug.Log("Returning Null");
          //  }


            
       // }
    }

  //  public void PickUp()
   // {
     //   Debug.Log("Picking up");
     //   Object.transform.SetParent( Raycast_Looking );
   // }

   // public void Drop()
   // {
      //  Raycast_Looking.DetachChildren();
  //  }
}
