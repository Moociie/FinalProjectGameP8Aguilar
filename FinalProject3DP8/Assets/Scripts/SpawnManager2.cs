using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private Vector3 spawnPos = new Vector3(35, 0, 8);

    private float startDelay = 1.5f;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    private int randomObstacle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomObstacle], spawnPos, obstaclePrefabs[randomObstacle].transform.rotation);
        }

    }

}
