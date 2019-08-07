using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody Asteroid;
    public float rotationSpeed;

    public float minSpeed, maxSpeed;

    public GameObject Player;
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float shotDelay;

    private float nextShotTime;

    public GameObject enemyShot;

    public Transform gunPosition;

    public float shotSpeed;

    public float rotationSp;
    void Start()
    {
        Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundry" || other.tag == "EnemyShot")
        {
            return;
        }    
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        if (other.tag == "Player")
        {
          Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    // Vector3 RotateToStep (Transform obj, Transform target)
    // {
    //     Vector3 targetDir = target.position - transform.position;

    //     // The step size is equal to speed times frame time.
    //     float step = rotationSp * Time.deltaTime;
    //     Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1f, 0.0f);
    //     Debug.DrawRay(transform.position, newDir, Color.red);

    //     // Move our position a step closer to the target.
    //     transform.rotation = Quaternion.LookRotation(newDir);

    //     return newDir;
    // }

    // Vector3 RotateTo (Transform obj, Transform target)
    // {
    //     Vector3 targetDir = target.position - transform.position;
    //     Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.0f, 0.0f);
    //     return newDir;

    // }

    void Update()
    {
        if (gameObject.tag == "EnemyShipDiagonal")
            gameObject.transform.LookAt(Player.transform);

        if (Time.time > nextShotTime && Time.time > 1f)
        {
            GameObject shot = Instantiate(enemyShot, gunPosition.position, Quaternion.identity);

            if (gameObject.tag == "EnemyShipDiagonal")
            {   
                shot.transform.LookAt(Player.transform);
                shot.GetComponent<Rigidbody>().velocity =  (Player.transform.position - gameObject.transform.position).normalized  * -shotSpeed;
            }
            else
            {
                shot.GetComponent<Rigidbody>().velocity = Vector3.forward * shotSpeed;
            }
            nextShotTime = Time.time + shotDelay;
        }
        //Player.transform.position);
        //RotateToStep (gameObject.transform, Player.transform);
    }
}