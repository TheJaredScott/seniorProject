using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controller : MonoBehaviour {

    //character controller to handle restart
    public Player player;
    private Scene scene;

	void Start () {
	
	}
	
	void Update () {

        if (Input.GetKey("r"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


    }
}
