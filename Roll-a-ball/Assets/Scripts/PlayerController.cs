using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    //public bool isMoving;
    Animator animation;
    Vector3 leftTurn;
    Vector3 rightTurn;
    private Rigidbody rb;
    public GameObject resetButton;

    private Vector3 inicialPosition;
    private Quaternion inicialRotation;

    private float rotationAngle;
    private float angle;
    private Quaternion rot;

    void Start()
    {
        inicialPosition = transform.position;
        inicialRotation = transform.rotation;

        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        leftTurn = new Vector3(0, -0.5f, 0);
        rightTurn = new Vector3(0, +0.5f, 0);

        rotationAngle = 5.0f;
    }
    //Before rendering a frame
    void Update()
    {
        if (InputManager.Up())
        {
            //rb.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
            rb.velocity = Vector3.forward * speed;
            animation.SetBool("Moving", true);
        }
        else if (InputManager.Down())
        {
            //rb.AddForce(Vector3.forward * -speed, ForceMode.VelocityChange);
            rb.velocity = Vector3.forward * -speed;
            animation.SetBool("Moving", true);
        }
        else if (InputManager.Left())
        {
            angle += rotationAngle;
            animation.SetBool("Moving", false);

        }
        else if (InputManager.Right())
        {
            angle -= rotationAngle;
            animation.SetBool("Moving", false);
        }
        else
        {
            animation.SetBool("Moving", false);
        }
        rot = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = rot;
    }
    //public void ResetPosition()
    //{
    //    transform.position = inicialPosition;
    //    transform.rotation = inicialRotation;
    //}   
    
    //Before performing physics calculations
    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, .0f, moveVertical);

    //    rb.AddForce(movement * speed);

    //}

}
