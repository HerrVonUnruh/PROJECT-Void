using System.Collections;
using UnityEngine;

public class DashScript : MonoBehaviour
{



    public float Direction = 0f;// erstellt einen privaten Float namens "Direction" auf 0
    public float DirectionVertical = 0f; // erstellt einen privaten Float für namens "DirectionVertical" auf 0
    private PlayerController DashControll;
    public bool isFacingRight = true;

    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Transform groundCheck;
    //[SerializeField] private LayerMask groundLayer;
    [SerializeField] public TrailRenderer tr;




    private void Start()
    {
        DashControll = GetComponent<PlayerController>();
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            DashControll.Geschwindigkeit = 60f;
            return;
        }

        //if (Input.GetKeyDown(KeyCode.LeftShift) && canDash || Input.GetKeyDown(KeyCode.Joystick1Button5) && canDash)
        //{
        //    DashControll.enabled = false;

        //}


        //rb.velocity = new Vector2(Direction * Geschwindigkeit.Geschwindigkeit * 2, rb.velocity.y);

        //if (Input.GetKeyUp(KeyCode.Joystick1Button5) && Direction > 0f && canDash)
        //{
        //    rb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y);
        //}
        //if (Input.GetKeyUp(KeyCode.Joystick1Button5) && Direction < 0f && canDash)
        //{
        //    rb.velocity = new Vector2(-transform.localScale.x * -dashingPower, -transform.localScale.y);
        //}
        //if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical > 0f && canDash)
        //{
        //    rb.velocity = new Vector2(transform.localScale.x, transform.localScale.y * dashingPower);
        //}
        //if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical < 0f && canDash && Input.GetKey("Horizontal"))
        //{
        //    rb.velocity = new Vector2(transform.localScale.x, transform.localScale.y * -dashingPower);
        //}
        //__________________________________
        //if (Input.GetKey(KeyCode.Joystick1Button5) && Direction == 0f && canDash && DirectionVertical == 0f)
        //{
        //    Player.velocity = new Vector2(transform.localScale.x * dashingPower * 10, transform.localScale.y);
        //}



    }
    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        //rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        rb.AddForce(new Vector3(transform.localScale.x * dashingPower, 0f, 0f), ForceMode2D.Impulse);
        //rb.AddForce(transform.right * dashingPower, ForceMode2D.Impulse);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVertical()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0f, transform.localScale.y * DashControll.Geschwindigkeit * 5f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalRechtsHoch()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashControll.Geschwindigkeit, transform.localScale.y * DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalRechtsRunter()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashControll.Geschwindigkeit, transform.localScale.y * -DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalLinksHoch()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * -DashControll.Geschwindigkeit, transform.localScale.y * DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalLinksRunter()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(-transform.localScale.x * -DashControll.Geschwindigkeit, transform.localScale.y * -DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


    private void Flip()
    {
        if (isFacingRight && Direction < 0f || !isFacingRight && Direction > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        Direction = Input.GetAxisRaw("Horizontal");
        DirectionVertical = Input.GetAxisRaw("Vertical");

        Flip();

        //if (Input.GetButtonDown("Jump") && IsGrounded())
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        //}

        //if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && Direction > 0f && DirectionVertical == 0f || Input.GetKeyDown(KeyCode.Joystick1Button5) && canDash && Direction > 0f && DirectionVertical == 0f || Input.GetKeyDown(KeyCode.LeftShift) && canDash && Direction < 0f && DirectionVertical == 0f || Input.GetKeyDown(KeyCode.Joystick1Button5) && canDash && Direction < 0f && DirectionVertical == 0f)
        {
            DashControll.Geschwindigkeit = DashControll.StandartGeschwindigkeit;
            StartCoroutine(Dash());
        }



        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical > 0f && Direction == 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical > 0f && Direction == 0f /*|| Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical < 0f && Direction == 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical < 0f && Direction == 0f*/)
        {
            StartCoroutine(DashVertical());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical > 0f && Direction > 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical > 0f && Direction > 0f)
        {
            StartCoroutine(DashVerticalRechtsHoch());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical < 0f && Direction > 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical < 0f && Direction > 0f)
        {
            StartCoroutine(DashVerticalRechtsRunter());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical > 0f && Direction < 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical > 0f && Direction < 0f)
        {
            StartCoroutine(DashVerticalLinksHoch());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical < 0f && Direction < 0f|| Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical < 0f && Direction < 0f)
        {
            StartCoroutine(DashVerticalLinksRunter());
        }
    }
}

    

    

    

   









//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DashScript : MonoBehaviour
//{

//    private bool canDash = true; // Bool für "Kann Dashen" ist auf "Start" - wahr
//    private bool isDashing;
//    public float dashingPower = 24f;
//    public float dashingTime = 0.2f;
//    public float dashingCooldown = 1f;

//    [SerializeField] private Rigidbody2D Player;
//    [SerializeField] private TrailRenderer tr;


//    // Start is called before the first frame update
//    void Start()
//    {
//        Player = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (isDashing)
//        {
            
//            return;
//        }

//        if (Input.GetKeyUp(KeyCode.LeftShift) && canDash && Input.GetKeyUp("a") || Input.GetKey(KeyCode.Joystick1Button5) && canDash || (Input.GetKeyUp(KeyCode.LeftShift) && canDash && Input.GetKeyUp("d")) || (Input.GetKeyUp("s") && Input.GetKeyUp(KeyCode.LeftShift)) && canDash || Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKeyUp("w")) && canDash)

//        {
//            StartCoroutine(Dash());


//        }
//    }

//    private void FixedUpdate()
//    {
//        if (Input.GetKeyUp(KeyCode.Joystick1Button5)/* && Direction > 0f*/ && canDash)
//        {
//            Player.velocity = new Vector2(transform.localScale.x + dashingPower, transform.localScale.y);
//        }
//        //if (Input.GetKeyUp(KeyCode.Joystick1Button5) && Direction < 0f && canDash)
//        //{
//        //    Player.velocity = new Vector2(-transform.localScale.x * -dashingPower, -transform.localScale.y);
//        //}
//        //if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical > 0f && canDash)
//        //{
//        //    Player.velocity = new Vector2(transform.localScale.x, transform.localScale.y * dashingPower);
//        //}
//        //if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical < 0f && canDash && Input.GetKey("Horizontal"))
//        //{
//        //    Player.velocity = new Vector2(transform.localScale.x, transform.localScale.y * -dashingPower);
//        //}
//        ////__________________________________
//        //if (Input.GetKey(KeyCode.Joystick1Button5) && Direction == 0f && canDash && DirectionVertical == 0f)
//        //{
//        //    Player.velocity = new Vector2(transform.localScale.x * dashingPower * 10, transform.localScale.y);
//        //}
//    }

//    private IEnumerator Dash()
//    {
//        canDash = false;
//        isDashing = true;
//        float originalGravity = Player.gravityScale;
//        Player.gravityScale = 0f;
//        tr.emitting = true;
//        yield return new WaitForSeconds(dashingTime);
//        tr.emitting = false;
//        Player.gravityScale = originalGravity;
//        isDashing = false;
//        yield return new WaitForSeconds(dashingCooldown);
//        canDash = true;

//    }

//}
