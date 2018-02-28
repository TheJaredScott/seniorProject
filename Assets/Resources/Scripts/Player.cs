using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //code to control player
    private float speed;
    private float maxspeed;
    private float jump;
    public string Powerup;
    private Vector3 jumpchange;
    private Vector3 speedchange;
    private bool jumpcheck = true;
    private Rigidbody rb;
    private Collider collide;
    private MeshRenderer render;
    private Texture hold;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collide = GetComponent<Collider>();
        render = GetComponent<MeshRenderer>();
        speed = 2;
        maxspeed = 20;
        jump = 12;
        Powerup = "None";
    }

    void Update () {
	}

    void FixedUpdate()
    {

        if (Input.GetKey("w") && rb.velocity.z < maxspeed)
        {
            speedchange = new Vector3(0.0f, 0.0f, speed);
            rb.velocity = rb.velocity + speedchange;
        }

        if (Input.GetKey("s") && rb.velocity.z > -maxspeed)
        {
            speedchange = new Vector3(-0.0f, 0.0f, -speed);
            rb.velocity = rb.velocity + speedchange;
        }

        if (Input.GetKey("d") && rb.velocity.x < maxspeed)
        {
            speedchange = new Vector3(speed, 0.0f, 0.0f);
            rb.velocity = rb.velocity + speedchange;
        }

        if (Input.GetKey("a") && rb.velocity.x > -maxspeed)
        {
            speedchange = new Vector3(-speed, 0.0f, 0.0f);
            rb.velocity = rb.velocity + speedchange;
        }

        if (Input.GetKeyDown("space") && jumpcheck == true)
        {
            jumpchange = new Vector3(0.0f, jump, 0.0f);
            rb.velocity = rb.velocity + jumpchange;
            jumpcheck = false;
        }

        if (Input.GetKey("z"))
        {
            StartCoroutine(DoPowerup());
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            jumpcheck = true;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void OnCollsionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpcheck = false;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Warp")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }

    public void PowerupHandle(string type)
    {
        Powerup = type;
    }

    IEnumerator DoPowerup()
    {
        if (Powerup == "None")
            yield return null;
        if (Powerup == "Jump")
        {
            rb.velocity = new Vector3(rb.velocity.x, jump * 2, rb.velocity.z);
            Powerup = "None";
            yield return null;
        }
        if (Powerup == "Bouncy")
        {
            collide.material = (PhysicMaterial)Resources.Load("BouncyMaterial");
            render.material = (Material)Resources.Load("bouncy");
            yield return StartCoroutine(PowerupTimer());
            collide.material = (PhysicMaterial)Resources.Load("NormalPlayer");
            render.material = (Material)Resources.Load("ball");
            Powerup = "None";
        }
    }

    IEnumerator PowerupTimer()
    {
        yield return new WaitForSeconds(5);
    }
}
