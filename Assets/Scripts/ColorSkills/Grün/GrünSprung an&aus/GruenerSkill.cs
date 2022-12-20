using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruenerSkill : MonoBehaviour
{
    private PolygonCollider2D GreenColliderSkill;
    public float bounce = 20f;
    private SpriteRenderer GreenSkill;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    void Start()
    {
        GreenColliderSkill = GetComponent<PolygonCollider2D>();
        GreenSkill = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GreenColliderSkill.enabled = true;
            GreenSkill.enabled = true;
            
        }
        
            if (Input.GetKeyUp(KeyCode.U) || Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyUp(KeyCode.K) || Input.GetKeyDown(KeyCode.Joystick1Button1) || (Input.GetKeyUp(KeyCode.H) || Input.GetKeyDown(KeyCode.Joystick1Button2)) )
        {
            GreenColliderSkill.enabled = false;
            GreenSkill.enabled = false;
        }
    }
}
