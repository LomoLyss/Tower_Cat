using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Hold : MonoBehaviour
{
    public GameObject Object;
   // public Transform Raycast_Looking;
   // public Camera Camera;
    public float range = 3f;
    public float Go = 100f;
   
    
    

    [SerializeField] Camera Camera;
    [SerializeField] Transform Raycast_Looking;

    public void Awake()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("E"))
        {
            StartPickUp();
        }

        if (Input.GetKeyUp("f"))
        {
            Drop();
        }
    }

    public void StartPickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.transform.position,Camera.transform.forward, out hit, range))
        {
            
            Target target = hit.transform.GetComponent<Target>();
            if(target != null )
            {
                PickUp();
            }
            
        }
    }

    public void PickUp()
    {
        Object.transform.SetParent( Raycast_Looking );
    }

    public void Drop()
    {
        Raycast_Looking.DetachChildren();
    }
}
