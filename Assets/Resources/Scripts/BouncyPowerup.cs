using UnityEngine;
using System.Collections;

public class BouncyPowerup : GenericPowerup
{

    //code to control bouncy material powerup
    public Player player;
    private Renderer rend;
    private Collider collide;


    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        collide = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.PowerupHandle("Bouncy");
            StartCoroutine(Intangible(rend, collide));
        }
    }
}