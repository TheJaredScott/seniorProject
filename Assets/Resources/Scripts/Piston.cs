using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour {

    //script to control quick-rising piston
    private Rigidbody rb;
    public int push;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
        transform.rotation = Quaternion.Euler(0, 0, 0);
	}

    void OnCollisionEnter(Collision col)
    {


        if(col.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
            rb.velocity = new Vector3(0.0f, push, 0.0f);
        }
    }
}
