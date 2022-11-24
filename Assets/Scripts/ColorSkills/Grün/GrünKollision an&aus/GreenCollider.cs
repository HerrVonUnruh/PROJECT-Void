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
        if (Input.GetKeyUp(KeyCode.E))
        {
            GreenColliderSkill.enabled = !GreenColliderSkill.enabled;
        }
    }
}
