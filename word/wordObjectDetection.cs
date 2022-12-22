using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordObjectDetection : MonoBehaviour
{
    private bool proximityPlayer;
    private float timer;

    private void Start()
    {
        proximityPlayer = false;
        timer = 0;
    }

    public void setProximity(bool proximity)
    {
        proximityPlayer = proximity;
    }

    private void FixedUpdate()
    {
        if (proximityPlayer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                timer += Time.deltaTime;
                
                if(timer > 1)
                {
                    Debug.Log("HORA DE ENTRAR NO MUNDO INVERSO DAS SILABAS!");
                    wordGlobalController controller = GameObject.Find("Global").GetComponent<wordGlobalController>();
                    controller.setSceneWord(this.gameObject);
                }
            } else
            {
                timer = 0;
            }
        } else
        {
            timer = 0;
        }
        
        setProximity(false);
    }
}
