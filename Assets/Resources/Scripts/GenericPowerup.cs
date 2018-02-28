using UnityEngine;
using System.Collections;

public class GenericPowerup : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    public IEnumerator Intangible(Renderer rend, Collider col)
    {
        rend.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(5);
        col.enabled = true;
        rend.enabled = true;

    }
}
