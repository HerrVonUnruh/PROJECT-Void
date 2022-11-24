using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Geschwindigkeit = 5f; // Erstellt einen öffentlichen Float namens "Geschwindigkeit"
    public float SprungGeschwindigkeit = 8f; // Erstellt öffentlichen Float namens "SprungGeschwindigkeit"  
    public float jumpSpeed = 5f; // Erstellt einen öffentlichen Float namens "jumpSpeed"
    private float Direction = 0f; // erstellt einen privaten Float namens "Direction" auf 0 
    private Rigidbody2D Player; // Bezug zu Rigidbody2D namens Player
    private bool wasTriggerd;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>(); // Erstellt am Anfang des Games einen Bezug zum Rigidbody namens "Player"

    }

    // Update is called once per frame
    void Update()
    {
        Direction = Input.GetAxis("Horizontal"); // schaltet den Unity Bezug der Tasteneingaben zu "Horizontal" Voreinstellung von Unity frei

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
        if (Input.GetButtonDown("Jump"))
        {
            Player.velocity = new Vector2(Player.velocity.x, SprungGeschwindigkeit);
        }

       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {


        
            if(collision.tag == "Trigger" && wasTriggerd != true)
        {

                transform.Translate(new Vector3(0, jumpSpeed, 0) * Time.deltaTime * jumpSpeed);
                wasTriggerd = true;

                //{
            //if (collision.tag == "Trigger")
            //{

            //    transform.Translate(new Vector3(0, jumpSpeed, 0) * Time.deltaTime * jumpSpeed);

            //}
        }
        Debug.Log("GameObject2 collided with " + collision.name);
    }


}

