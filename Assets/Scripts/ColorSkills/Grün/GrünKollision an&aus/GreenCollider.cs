using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCollider : MonoBehaviour
{
    private BoxCollider2D GreenColliderSkill;



    void Start()
    {
        GreenColliderSkill = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GreenColliderSkill.enabled = !GreenColliderSkill.enabled;

        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            GreenColliderSkill.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            GreenColliderSkill.enabled = false;
        }
    }
}