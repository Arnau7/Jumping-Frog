using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraSmooth = .1f;

    private Vector3 offset;
    private Vector3 offsetR;
    Vector3 leftTurn;
    Vector3 rightTurn;

    // Use this for initialization
    void Start () {
        offset = (transform.position - player.transform.position);
       
        //leftTurn = new Vector3(0, -0.5f, 0);
        //rightTurn = new Vector3(0, +0.5f, 0);
    }
	
	// Runs every frame, after all items have been processed
	void LateUpdate ()
    {
        
        Vector3 desiredPosition = (player.transform.position + offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSmooth);

        float angle = Mathf.Acos(Vector3.Dot(Vector3.forward, player.transform.forward));

        //transform.position = smoothedPosition;
        transform.RotateAround(player.transform.position, player.transform.up, -angle);
        transform.LookAt(player.transform.position);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Rotate(leftTurn,Space.World);

        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Rotate(rightTurn, Space.World);
        //}
        //transform.position = player.transform.position + offset;


    }
}
