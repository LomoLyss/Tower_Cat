using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObject_Hold : MonoBehaviour
{
    public float range = 10f;
   // public float Go = 100f;




   // [SerializeField] Camera Camera;
    [SerializeField] Transform Raycast_Looking;
   // [SerializeField] GameObject Object;
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
            Ray ray = new Ray(Raycast_Looking.transform.position, Raycast_Looking.transform.forward);

            if (Physics.Raycast(ray, out hit, range, LayerMask))
            {
                Debug.Log(hit.collider);
            }

            else
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red);

                Debug.Log("Did not Hit");
            }
        }
    }
}
