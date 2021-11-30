using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject laserShot;
    public GameObject laserGun;
    public float shotDelay;

    public GameObject asteroidExplotion;

    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    Rigidbody playerShip;

    float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isStarted == false)
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal"); //-1 ... +1 вправо/влево
        float moveVertical = Input.GetAxis("Vertical"); //-1 ... +1 вперёд/назад
        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float xPosition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);
        playerShip.position = new Vector3(xPosition, 0, zPosition);

        playerShip.rotation = Quaternion.Euler(playerShip.velocity.z * tilt, 0, - playerShip.velocity.x * tilt);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(laserShot, laserGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        if (Input.GetButton("Fire2"))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach(GameObject asteroid in gameObjects)
            {
                Destroy(asteroid);
                Instantiate(asteroidExplotion, asteroid.transform.position, Quaternion.identity);
                GameController.instance.incrementScore();
            }
        }
    }
}
