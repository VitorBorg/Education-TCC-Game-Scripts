using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{

    Transform camera;

    public float SensitivityX = 1.7f;
    public float SensitivityY = 1.7f;

    public float yRotate = 0;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation();
        yRotation();
    }

    public void xRotation()
    {
        float x = Input.GetAxis("Mouse X") * SensitivityX;
        transform.Rotate(Vector3.up * x);
    }

    public void yRotation()
    {
        float y = Input.GetAxis("Mouse Y") * SensitivityY;

        yRotate -= y;
        yRotate = Mathf.Clamp(yRotate, -90f, 90f);

        camera.localRotation = Quaternion.Euler(yRotate, 0f, 0f);
    }
}
