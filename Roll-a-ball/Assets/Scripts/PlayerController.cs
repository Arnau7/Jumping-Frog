using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    //public bool isMoving;
    Animator animation;
    Vector3 leftTurn;
    Vector3 rightTurn;
    public Rigidbody rb;
    public GameObject resetButton;

    private Vector3 inicialPosition;
    private Quaternion inicialRotation;

    void Start()
    {
        inicialPosition = transform.position;
        inicialRotation = transform.rotation;

        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        leftTurn = new Vector3(0, -0.5f, 0);
        rightTurn = new Vector3(0, +0.5f, 0);
    }
    //Before rendering a frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.transform.position += Vector3.forward * speed * Time.deltaTime;
            //isMoving = true;
            animation.SetBool("Moving", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.transform.position += Vector3.back * speed * Time.deltaTime;
            //isMoving = true;
            animation.SetBool("Moving", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.Rotate(leftTurn,Space.World);
            animation.SetBool("Moving", false);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.Rotate(rightTurn,Space.World);
            animation.SetBool("Moving", false);
        }
        else
        {
            animation.SetBool("Moving", false);
           // isMoving = false;
        }
 
    }
    public void ResetPosition()
    {
        transform.position = inicialPosition;
        transform.rotation = inicialRotation;
    }   
    //Before performing physics calculations
    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, .0f, moveVertical);

    //    rb.AddForce(movement * speed);

    //}

}
