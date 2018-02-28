using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

    //code to control moving square enemy
    private Rigidbody rb;
    private float startposition;
    private Vector3 movevector;
    public float speed;
    private string relevantdirection;
    public float movelimit;
    public string direction;

	// Use this for initialization
	void Start (){
        rb = GetComponent<Rigidbody>();
        if (direction.Equals("horizontal", StringComparison.InvariantCultureIgnoreCase))
        {
            movevector = new Vector3(speed, 0.0f, 0.0f);
            startposition = transform.position.x;
            relevantdirection = "x";
        }
        if (direction.Equals("vertical", StringComparison.InvariantCultureIgnoreCase))
        {
            movevector = new Vector3(0.0f, speed, 0.0f);
            startposition = transform.position.y;
            relevantdirection = "y";
        }
        if (direction.Equals("forward", StringComparison.InvariantCultureIgnoreCase))
        {
            movevector = new Vector3(0.0f, 0.0f, speed);
            startposition = transform.position.z;
            relevantdirection = "z";
        }
        rb.velocity = movevector;
    }
	
	// Update is called once per frame
	void FixedUpdate (){

        if (relevantdirection == "x")
        {
            if (transform.position.x >= startposition + movelimit)
            {
                rb.velocity = -movevector;
            }
            if (transform.position.x <= startposition - movelimit)
            {
                rb.velocity = movevector;
            }
        }
        if (relevantdirection == "y")
        {
            if (transform.position.y >= startposition + movelimit)
            {
                rb.velocity = -movevector;
            }
            if (transform.position.y <= startposition - movelimit)
            {
                rb.velocity = movevector;
            }
        }
        if (relevantdirection == "z")
        {
            if (transform.position.z >= startposition + movelimit)
            {
                rb.velocity = -movevector;
            }
            if (transform.position.z <= startposition - movelimit)
            {
                rb.velocity = movevector;
            }
        }

    }
}
