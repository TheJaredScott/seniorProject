using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    //code to determine camera position
    public Player player;
    private Vector3 offset;

	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
