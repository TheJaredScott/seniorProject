using UnityEngine;
using System.Collections;

public class PowerJump : GenericPowerup {

    //controls high jump powerup
    public Player player;
    private Renderer rend;
    private Collider collide;


    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        collide = GetComponent<Collider>();
    }
	
   void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.PowerupHandle("Jump");
            StartCoroutine(Intangible(rend, collide));
        }
    }
}
