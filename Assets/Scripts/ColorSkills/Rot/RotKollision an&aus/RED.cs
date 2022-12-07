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
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            REDSkill.enabled = !REDSkill.enabled;
            REDSkill2.enabled = !REDSkill2.enabled;

        }

        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            REDSkill.enabled = false;
            REDSkill2.enabled = false;
        }
    }
}