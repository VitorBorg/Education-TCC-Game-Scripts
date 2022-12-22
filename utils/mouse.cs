using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public bool CursorVisible = false;

    void Start()
    {
        CursorVisible = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void setCursorVisible()
    {
        CursorVisible = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void setCursorNotVisible()
    {
        CursorVisible = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
