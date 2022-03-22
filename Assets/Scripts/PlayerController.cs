using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed = 0f;
    private float turnSpeed = 80f;
    private float horizontalInput;
    private float forwardInput;
    private float a = 0.1f; // Acceleration
    public float maxSpeed = 40f;
    private Vector3 initialPosition;
    private Quaternion initialRotation;



    // Start is called before the first frame update
    void Start()
    {
        initialPosition = player.transform.position;
        initialRotation = player.transform.rotation;
    }

    private void LateUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Velocidad positiva o negativa, corrección de la dirección en marcha atrás.
        if (speed > 0.5)
        {
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
            //Traqueteo();
        } else if (speed < -0.5) {
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime * -1);
            //Traqueteo();
        }

        // Se suma aceleración a la velocidad.
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            if (speed <= maxSpeed)
            {
                speed = a + speed;
            }
               
        } 
        
        // SDisminuye velocidad si se deja de pulsar W.
        else
        {
            if (speed > 0)
            {
                speed = speed - a / 2;
            }
        }


        // Disminuye velocidad al girar.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            speed = speed - a / 2;
        }

        
        // Menor velocidad marcha atrás.
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            
            if (speed >= -maxSpeed/2)
            {
                speed = speed - a / 2;
            }

        } else {
            if (speed < 0)
            {
                speed = speed + a / 2;
            }
        }

        if(Input.GetKey(KeyCode.R))
        {
            player.transform.position = initialPosition;
            player.transform.rotation = initialRotation;
        }
    }
    
    void Traqueteo()
    {
        // Traqueteo - todo REVISAR speed

        if (((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)) && speed > 1.5f)
        {
            transform.Translate(0, 0.0035f, 0);
        }
    }
}
