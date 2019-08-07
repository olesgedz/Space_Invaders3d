using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float speed;
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    public GameObject Player;


    void Start()
    {
        
    }

    void  Update()
    {
        // if (GetComponent<Rigidbody>().position.z > 30)
        //     Destroy(gameObject); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundry" || other.tag == "EnemyShipDiagonal")
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
}
