using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;

    public GameObject lazerShot;
    public Transform gunPosition;

    public float shotDelay;

    private float nextShotTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(lazerShot, gunPosition.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Rigidbody Ship = GetComponent<Rigidbody>();
       Ship.velocity = new Vector3(moveHorizontal, 0 , moveVertical) * speed;
       Ship.rotation = Quaternion.Euler(-tilt * Ship.velocity.z, 0, -tilt * Ship.velocity.x);

        float xPosition = Mathf.Clamp(Ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(Ship.position.z, zMin, zMax);
        Ship.position = new Vector3(xPosition, 0, zPosition);
    }
}
