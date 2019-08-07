using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;

    public float life;
    public GameObject lazerShot;
    public GameObject lazerShotSide;

    public Transform gunPosition;
    public Transform gunPositionLeft;
    public Transform gunPositionRight;

    public float shotSpeed;
    

    public float shotDelay;

    private float nextShotTime;
    private float nextShotTimeSide;

    public GameObject playerExplosion;

    void Start()
    {
    }

    public void LoseLife()
    {
        // life -= 1;
        // Debug.Log("Lost life");
        // if (life <= 0)
        // {
        //     life = 1;
         Instantiate(playerExplosion, this.transform.position, Quaternion.identity);
        //Destroy(gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            GameObject shot = Instantiate(lazerShot, gunPosition.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().velocity = Vector3.forward * shotSpeed;
            nextShotTime = Time.time + shotDelay;
        }
        if (Time.time > nextShotTimeSide && Input.GetButton("Fire2"))
        {
            GameObject lShot = Instantiate(lazerShotSide, gunPositionLeft.position, Quaternion.Euler(0, -45, 0));
            GameObject rShot= Instantiate(lazerShotSide, gunPositionRight.position, Quaternion.Euler(0, 45, 0));
            lShot.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * shotSpeed;
            rShot.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * shotSpeed;       

            nextShotTimeSide = Time.time + shotDelay / 2;
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
