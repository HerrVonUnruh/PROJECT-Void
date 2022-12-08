using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RED : MonoBehaviour
{
    private PolygonCollider2D REDSkill;
    private SpriteRenderer REDSkill2;
    


    void Start()
    {
        REDSkill = GetComponent<PolygonCollider2D>();
        REDSkill2 = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            REDSkill.enabled = true;
            REDSkill2.enabled = true;

        }

        if (Input.GetKeyUp(KeyCode.U) || Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyUp(KeyCode.J) || Input.GetKeyDown(KeyCode.Joystick1Button0) || (Input.GetKeyUp(KeyCode.H) || Input.GetKeyDown(KeyCode.Joystick1Button2)))
        {
            REDSkill.enabled = false;
            REDSkill2.enabled = false;
        }
    }
}