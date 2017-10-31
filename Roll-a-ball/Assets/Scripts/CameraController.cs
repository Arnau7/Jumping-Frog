using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private Vector3 offsetR;
    Vector3 leftTurn;
    Vector3 rightTurn;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
       
        leftTurn = new Vector3(0, -0.5f, 0);
        rightTurn = new Vector3(0, +0.5f, 0);
    }
	
	// Runs every frame, after all items have been processed
	void LateUpdate ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(leftTurn,Space.World);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(rightTurn, Space.World);
        }
        transform.position = player.transform.position + offset;
      

    }
}
