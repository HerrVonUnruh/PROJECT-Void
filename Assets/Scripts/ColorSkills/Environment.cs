using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{

    public Material[] material;
    Renderer rende;
    // Start is called before the first frame update
    void Start()
    {
        rende = GetComponent<Renderer>();
        rende.enabled = true;
        rende.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            rende.sharedMaterial = material[1];
        }

        //Grüne Fähigkeit
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            rende.sharedMaterial = material[0];
        }


        //Blaue Fähigkeit
        if (Input.GetKeyUp(KeyCode.H) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            rende.sharedMaterial = material[1];
        }

        //Gelbe Fähigkeit
        if (Input.GetKeyUp(KeyCode.U) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            rende.sharedMaterial = material[1];
        }
    }
}
