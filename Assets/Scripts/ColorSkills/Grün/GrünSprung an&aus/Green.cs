using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    private CapsuleCollider2D GREENSkill;

    void Start()
    {
        GREENSkill = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
           GREENSkill.enabled = !GREENSkill.enabled;
        }
    }
}