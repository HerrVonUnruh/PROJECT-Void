using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float Geschwindigkeit = 8f; // Erstellt einen öffentlichen Float namens "Geschwindigkeit"
    public float SprungGeschwindigkeit = 50f; // Erstellt öffentlichen Float namens "SprungGeschwindigkeit"
    private float Direction = 0f; // erstellt einen privaten Float namens "Direction" auf 0
    private float DirectionVertical = 0f;
    public float maxSpeed = 150f;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 1f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public float flipSteigerung = 10f;



    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D Player; // Bezug zu Rigidbody2D namens Player
    [SerializeField] public Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    //private float triggerLength = 2f;
    //private float triggerCounter;



    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>(); // Erstellt am Anfang des Games einen Bezug zum Rigidbody namens "Player"

    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }


        // JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!
        // ______________________________________________________________________________________________________
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Player.velocity = new Vector2(Player.velocity.x, SprungGeschwindigkeit);
        }

        if (Input.GetButtonUp("Jump") && Player.velocity.y > 0f)
        {
            Player.velocity = new Vector2(Player.velocity.x, Player.velocity.y * 0.5f);
        }



        dashingPower = 1f * Geschwindigkeit;

        Direction = Input.GetAxis("Horizontal"); // schaltet den Unity Bezug der Tasteneingaben zu "Horizontal" Voreinstellung von Unity frei
        DirectionVertical = Input.GetAxis("Vertical");

        Flip(); // HIER IST DIE STEIGERUNG FUER DIE GESCHWINDIGKEIT PRO SEKUNDE!!!!!!


        if (Geschwindigkeit < maxSpeed)
        {
            Geschwindigkeit += flipSteigerung * Time.deltaTime;
        }

        if (Direction > 0f) // wenn die Richtung der gedrückten Tasten ( a oder d ) auf der Y Achse über 0 sind
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
        }
       
        else if (Direction < 0f) // wenn die Richtung der gedrückten Tasten(a oder d ) auf der Y Achse unter 0 sind
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
        }
        else // "Andernfalls", also wenn gar keine Taste A oder D gedrückt wird, dann bedeutet das, dass auf der X Achse 0 Bewegung stattfindet!
        {
            Player.velocity = new Vector2(0, Player.velocity.y);
        }
        if(Direction == 0)
        { Geschwindigkeit = 8f; }


        //JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!
        //____________________________________________________________________________________
        if (Input.GetButtonDown("Jump"))
        {
            Player.velocity = new Vector2(Player.velocity.x, 16f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash || canDash && Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            StartCoroutine(Dash());

        }
        //if (triggerCounter > 0)
        //{
        //    triggerCounter -= Time.deltaTime;
        //}





    }
    //public void OnTriggerEnter2D(Collider2D collision)
    //{



    //        if(collision.tag == "Trigger" && triggerCounter <= 0)
    //    {

    //            transform.Translate(new Vector3(0, jumpSpeed, 0) * Time.deltaTime * jumpSpeed);
    //            triggerCounter = triggerLength;

    //        //{
    //        //if (collision.tag == "Trigger")
    //        //{

    //        //    transform.Translate(new Vector3(0, jumpSpeed, 0) * Time.deltaTime * jumpSpeed);

    //        //}
    //    }
    //    Debug.Log("GameObject2 collided with " + collision.name);
    //}


    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }

        Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && Direction < 0f || !isFacingRight && Direction > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = Player.gravityScale;
        Player.gravityScale = 0f;
        Player.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        Player.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;    
    }
}
