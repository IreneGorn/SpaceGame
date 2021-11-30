 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplotion;
    public GameObject playerExplotion;
    public float rotationSpeed;
    public float maxSpeed, minSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        float zSpeed = Random.Range(minSpeed, maxSpeed);

        asteroid.velocity = new Vector3(0, 0, - zSpeed);
    }

    //срабатывает при столкновении
    private void OnTriggerEnter(Collider other) //параметр - второй объект
    {
        if (other.tag == "GameBoundery")
        {
            return;
        }

        if (other.tag == "Laser")
        {
            GameController.instance.incrementScore();
        }

        if (other.tag != "Asteroid")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(asteroidExplotion, transform.position, Quaternion.identity);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplotion, other.transform.position, Quaternion.identity);
        }
    }
}
