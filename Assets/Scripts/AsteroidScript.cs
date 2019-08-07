using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody Asteroid;
    public float rotationSpeed;

    public float minSpeed, maxSpeed;

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public GameObject Player;


    void Start()
    {
        Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundry")
        {
            return;
        }    
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        if (other.tag == "Player")
        {
            Player.GetComponent<Player>().LoseLife();          

        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    void Update()
    {

    }
}
