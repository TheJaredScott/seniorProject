using UnityEngine;
using System.Collections;

public class TestThwomp : MonoBehaviour {

    //code to control quick smashing cylinder enemy
    public ThwompCollider hitbox;
    public int oheight;
    private Rigidbody rb;
    private Vector3 smashvector;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Smash()
    {
        smashvector = -this.transform.up * -20.0f;
        rb.velocity = -smashvector;
    }

}
