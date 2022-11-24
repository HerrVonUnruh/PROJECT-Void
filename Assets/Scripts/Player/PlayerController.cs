using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Geschwindigkeit = 5f; // Erstellt einen �ffentlichen Float namens "Geschwindigkeit"
    public float SprungGeschwindigkeit = 8f; // Erstellt �ffentlichen Float namens "SprungGeschwindigkeit"  
    private float Direction = 0f; // erstellt einen privaten Float namens "Direction" auf 0 
    private Rigidbody2D Player; // Bezug zu Rigidbody2D namens Player
        

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>(); // Erstellt am Anfang des Games einen Bezug zum Rigidbody namens "Player"

    }

    // Update is called once per frame
    void Update()
    {
        Direction = Input.GetAxis("Horizontal"); // schaltet den Unity Bezug der Tasteneingaben zu "Horizontal" Voreinstellung von Unity frei

        if(Direction > 0f) // wenn die Richtung der gedr�ckten Tasten ( a oder d ) auf der Y Achse �ber 0 sind 
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y); 

        }
        else if(Direction < 0f) // wenn die Richtung der gedr�ckten Tasten(a oder d ) auf der Y Achse unter 0 sind
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
        }
        else // "Andernfalls", also wenn gar keine Taste A oder D gedr�ckt wird, dann bedeutet das, dass auf der X Achse 0 Bewegung stattfindet!
        {
            Player.velocity = new Vector2(0, Player.velocity.y);
        }
        if (Input.GetButtonDown("Jump"))
        {
            Player.velocity = new Vector2(Player.velocity.x, SprungGeschwindigkeit);
        }

    }
}
