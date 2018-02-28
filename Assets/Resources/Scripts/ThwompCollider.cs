using UnityEngine;
using System.Collections;

public class ThwompCollider : MonoBehaviour {
    //code for the collider on the smashing cylinder enemy. cyllinder falls when this touches player.
    public TestThwomp thwomp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") {
            thwomp.Smash();

        }
            
    }
}
