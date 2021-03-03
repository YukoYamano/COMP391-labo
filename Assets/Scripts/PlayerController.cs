using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    public float minX, maxX, minY, maxY;
    public GameObject laser, laserSpawnLocation;
    public float fireRate = 0.25f;
    
    private float timer =0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        float horiz, vert;

        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horiz, vert);
        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;


        //Restrict the player from leaving the play area  

        float newX, newY;

        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent <Rigidbody2D>().position.y, minY, maxY);

        //Debug.Log("Clamped x: " + newX + "Clamped Y : " + newY);

        GetComponent< Rigidbody2D > ().position = new Vector2(newX, newY);

        //Add laser fire code
        if (Input.GetAxis("Fire1")>0 && timer>fireRate) 
        {
            //Instantiation : what do I instantiate ? where is it instantiated ? What is its rotation?
            GameObject gobj;
            gobj = GameObject.Instantiate(laser, laserSpawnLocation.transform.position, laserSpawnLocation.transform.rotation);
            gobj.transform.Rotate(new Vector3(0, 0, 90));

            timer = 0;
        }

        // timer = timer + Time.deltaTime; 
        timer += Time.deltaTime;

    }
}
