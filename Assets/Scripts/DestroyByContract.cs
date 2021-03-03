using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContract : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //something has collided

        //create an explosion
        Instantiate(explosion, transform.position, transform.rotation);

        //Delete the other (laser) object to avoid erase everything before executing the last code.
        Destroy(other.gameObject);
        //Delete this(asteroid)object
        Destroy(this.gameObject);
    }
}
