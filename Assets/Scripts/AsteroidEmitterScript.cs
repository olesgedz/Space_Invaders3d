using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public GameObject[] asteroidArr;
    public GameObject asteroid;
    public float minDelay, maxDelay;
    private float nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            float yPosition = transform.position.y;
            float zPosition = transform.position.z;
            float xPosition = Random.Range(-transform.localScale.x/2, transform.localScale.x/2);
            Debug.Log(xPosition);
            Vector3 newPosition = new Vector3(xPosition, yPosition, zPosition);
            int randomNum = Random.Range(0, asteroidArr.Length);
            Instantiate(asteroidArr[randomNum], newPosition, Quaternion.identity);
            nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
