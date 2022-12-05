using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RED : MonoBehaviour
{
    private BoxCollider2D REDSkill;

    void Start()
    {
        REDSkill = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            REDSkill.enabled = !REDSkill.enabled;
        }
    }
}
