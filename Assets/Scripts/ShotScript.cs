using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float speed;
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;


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
          Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
