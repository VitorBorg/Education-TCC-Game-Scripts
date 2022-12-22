using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetection : MonoBehaviour
{
    public LayerMask layer;
    private GameObject player;
    public float radius = 2;

    private MeshRenderer mesh;
    private Material originalMaterial;
    public Material redMaterial;

    void Start()
    {
        player = GameObject.Find("Player");
        mesh = gameObject.GetComponent<MeshRenderer>();
        originalMaterial = mesh.material;
    }

    void FixedUpdate()
    {
        playerDetection();
    }

    void playerDetection()
    {
        bool detection = Physics.CheckSphere(transform.position, radius, layer);

        if (detection)
        {
            mesh.material = redMaterial;
        } else
        {
            mesh.material = originalMaterial;
        }
    }
}
