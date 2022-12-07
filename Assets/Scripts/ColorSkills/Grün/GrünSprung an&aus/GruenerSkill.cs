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
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GreenColliderSkill.enabled = !GreenColliderSkill.enabled;
            GreenSkill.enabled = !GreenSkill.enabled;

        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            GreenColliderSkill.enabled = false;
            GreenSkill.enabled = false;
        }
    }
}
