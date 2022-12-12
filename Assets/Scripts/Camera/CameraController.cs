using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset_x;
    public float offset_y;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    [SerializeField] public Camera CameraZoom;
    public PlayerController KameraZoom;

    // Start is called before the first frame update
    void Start()
    {

       
        CameraZoom = GetComponent<Camera>();
        Debug.Log(KameraZoom.Geschwindigkeit.ToString("F4"));
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset_x, playerPosition.y + offset_y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset_x, playerPosition.y + offset_y, playerPosition.z);
        }
        if (player.transform.localScale.y > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset_x, playerPosition.y + offset_y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset_x, playerPosition.y - offset_y, playerPosition.z);
        }

        CameraZoom.orthographicSize = 8f;
       
        

        if(KameraZoom.Geschwindigkeit > 20f)
        {
            
            CameraZoom.orthographicSize = KameraZoom.Geschwindigkeit * 0.3f;
            if (CameraZoom.orthographicSize < 8f)
            {
                CameraZoom.orthographicSize = 8f;
            }
        }
        
        
        


    transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}