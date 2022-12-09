using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float Geschwindigkeit = 50f;// Erstellt einen öffentlichen Float namens "Geschwindigkeit"
    public float StandartGeschwindigkeit = 50f;
    public float FallGeschwindigkeit = 9.85f;
    //public float SprungGeschwindigkeit = 50f; // Erstellt öffentlichen Float namens "SprungGeschwindigkeit"
    public float maxSpeed = 150f; // Erstellt einen öffentlichen Float für die Maximalgeschwindigkeit
    public float flipSteigerung = 10f;

    private float Direction = 0f;// erstellt einen privaten Float namens "Direction" auf 0
    private float DirectionVertical = 0f; // erstellt einen privaten Float für namens "DirectionVertical" auf 0
    

    private bool canDash = true; // Bool für "Kann Dashen" ist auf "Start" - wahr
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    


    public Material[] material;
    Renderer rend;

    [SerializeField] Transform spawnPoint;
    
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D Player; // Bezug zu Rigidbody2D namens Player
    //[SerializeField] public Transform groundCheck;
    //[SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    
    
    //private float triggerLength = 2f;
    //private float triggerCounter;



    
    void Start()
    {
        Player = GetComponent<Rigidbody2D>(); // Erstellt am Anfang des Games einen Bezug zum Rigidbody namens "Player"
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        

    }



    void Update()
    {
        

        //Movement
        //__________________________________________________________________________________________________________

        Direction = Input.GetAxis("Horizontal"); // schaltet den Unity Bezug der Tasteneingaben zu "Horizontal" Voreinstellung von Unity frei
        DirectionVertical = Input.GetAxis("Vertical");

        if (Direction == 0f)
        { Geschwindigkeit = Geschwindigkeit - 30 * Time.deltaTime;

            if (Geschwindigkeit < StandartGeschwindigkeit)
            { Geschwindigkeit = StandartGeschwindigkeit; }
           
        }

       

        if (Direction > 0f) // wenn die Richtung der gedrückten Tasten ( a oder d ) auf der Y Achse über 0 sind
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
            if (Geschwindigkeit < maxSpeed)
            {
                Geschwindigkeit += flipSteigerung * Time.deltaTime;
            }
        }

        else if (Direction < 0f) // wenn die Richtung der gedrückten Tasten(a oder d ) auf der Y Achse unter 0 sind
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
            if (Geschwindigkeit < maxSpeed)
            {
                Geschwindigkeit += flipSteigerung * Time.deltaTime;
            }
        }
        else // "Andernfalls", also wenn gar keine Taste A oder D gedrückt wird, dann bedeutet das, dass auf der X Achse 0 Bewegung stattfindet!
        {
            Player.velocity = new Vector2(0, Player.velocity.y);
        }

        if (Direction > 1.1f)
        {
            Direction = 1.1f;
        }

        if (Direction < -1.1f)
        {
            Direction = -1.1f;
        }

        if (DirectionVertical > 1.1f)
        {
            DirectionVertical = 1.1f;
        }
        if (DirectionVertical < -1.1f)
        {
            DirectionVertical = -1.1f;
        }


        if (DirectionVertical == 0f && Input.GetKeyDown(KeyCode.S) || DirectionVertical <0f && Input.GetKey(KeyCode.Joystick1Button4))
        {
            Player.gravityScale = 5f + Player.gravityScale + 1f * Time.deltaTime;

            if (Player.gravityScale > 50f)
            {
                Player.gravityScale = 5f;
            }
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Player.gravityScale = 5f;
        }

        



        Flip(); // HIER IST DIE FUNKTION FÜR DIE STEIGERUNG FUER DIE GESCHWINDIGKEIT PRO SEKUNDE!!!!!!

        //__________________________________________________________________________________________________________


        //RESPAWN
        //__________________________________________________________________________________________________________

        Spawn();// Spawn natürlich
        //__________________________________________________________________________________________________________

        //SKILLS
        //__________________________________________________________________________________________________________


        //Rote Fähigkeit
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            rend.sharedMaterial = material[1];
        }

        //Grüne Fähigkeit
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            rend.sharedMaterial = material[0];
        }


        //Blaue Fähigkeit
        if (Input.GetKeyUp(KeyCode.H) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            rend.sharedMaterial = material[2];
        }

        //Gelbe Fähigkeit
        if (Input.GetKeyUp(KeyCode.U) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            rend.sharedMaterial = material[3];
        }
        //__________________________________________________________________________________________________________

        //Dash
        //__________________________________________________________________________________________________________
        if (isDashing)
        {
            Geschwindigkeit = 70f;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && Input.GetKey("a") || canDash && Input.GetKeyDown(KeyCode.Joystick1Button5) || (Input.GetKeyDown(KeyCode.LeftShift) && canDash && Input.GetKey("d")) || (Input.GetKey("s") && Input.GetKey(KeyCode.LeftShift)) && canDash || Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey("w")) && canDash )

        {
            StartCoroutine(Dash());

        }

       

        //__________________________________________________________________________________________________________


        //if (triggerCounter > 0)
        //{
        //    triggerCounter -= Time.deltaTime;
        //}




        // JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!JUMP!!!
        // ______________________________________________________________________________________________________
        //if (Input.GetButtonDown("Jump") && IsGrounded())
        //{
        //    Player.velocity = new Vector2(Player.velocity.x, SprungGeschwindigkeit);
        //}

        //if (Input.GetButtonUp("Jump") && Player.velocity.y > 0f)
        //{
        //    Player.velocity = new Vector2(Player.velocity.x, Player.velocity.y * 0.5f);
        //}
        //_________________________________________________________________________________________________________
        //if (isDashing && (Input.GetKeyDown(KeyCode.LeftShift) &&  Input.GetKey("a")) || Input.GetKeyDown(KeyCode.Joystick1Button5) && Input.GetKeyDown("Horizontal")|| Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("d"))
        //{
        //    Player.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y);
        //}

        
    }

    //__________________________________________________________________________________________________________________________________________
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && Direction > 0f )
        {
            Player.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && Direction < 0f )
        {
            Player.velocity = new Vector2(-transform.localScale.x * -dashingPower, -transform.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical > 0f)
        {
            Player.velocity = new Vector2(transform.localScale.x , transform.localScale.y * dashingPower);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical < 0f)
        {
            Player.velocity = new Vector2(transform.localScale.x, transform.localScale.y * -dashingPower);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = Player.gravityScale;
        Player.gravityScale = 0f;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        Player.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
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

    private void Spawn()
    { //SPAWN
        //______________________________________________________       
        if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            transform.CompareTag("Player");
            transform.position = spawnPoint.position;
            return;
        }
    }

    //private bool IsGrounded()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    //}











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
}
