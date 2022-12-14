using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public PlayerController spawning;
    public bool willSpawn = false; 
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = spawnPoint.position;
            willSpawn = true;
            spawning.Spawn();
            
        }
            
    }
    

}
