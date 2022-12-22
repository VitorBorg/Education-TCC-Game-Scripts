using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensors : MonoBehaviour
{
    public LayerMask layerMask;
    private RaycastHit hit;

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, layerMask))
        {
            // Debug.Log("Did Hit");
            hit.collider.GetComponent<wordObjectDetection>().setProximity(true);
        }
    }
}
