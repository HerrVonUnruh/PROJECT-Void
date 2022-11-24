using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarbwechselRot : MonoBehaviour
{

    public Renderer RotRenderer;
    public GameObject Wand;
    [SerializeField] private Color newColor;
    [SerializeField] private Color[] colors;
    private int colorValue;

    // Start is called before the first frame update
    void Start()
    {
        RotRenderer = Wand.GetComponent<Renderer>();  
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangeColor()
    {
            //newColor = Random.ColorHSV();


            //RotRenderer.material.color = newColor;

            colorValue++;

        if (Input.GetKeyUp(KeyCode.Q))
        {
            
           colorValue = 0;
        }

        RotRenderer.material.color = colors[Random.Range(0,2)];
    }
    
}
